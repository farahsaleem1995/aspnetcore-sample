using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspTodo.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspTodo.Infra.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> ApplySpecification<TEntity>(this IQueryable<TEntity> queryable,
            AbstractSpecification<TEntity> abstractSpecification, out IQueryable<TEntity> totalQuery)
            where TEntity : class, IEntity
        {
            var query = queryable;

            query = query.ApplySpecificationWithoutPaging(abstractSpecification);

            totalQuery = query;

            return query.ApplyPaging(abstractSpecification);
        }

        public static IQueryable<TEntity> ApplySpecification<TEntity>(this IQueryable<TEntity> queryable,
            AbstractSpecification<TEntity> abstractSpecification)
            where TEntity : class, IEntity
        {
            var query = queryable;

            query = query.ApplySpecificationWithoutPaging(abstractSpecification);

            return query.ApplyPaging(abstractSpecification);
        }
        
        private static IQueryable<TEntity> ApplySpecificationWithoutPaging<TEntity>(this IQueryable<TEntity> queryable,
            AbstractSpecification<TEntity> abstractSpecification)
            where TEntity : class, IEntity
        {
            var query = queryable;

            // modify the IQueryable using the specification's criteria expression
            if (abstractSpecification.Criteria != null)
            {
                query = query.Where(abstractSpecification.Criteria);
            }

            // filter by all filter expressions
            query = abstractSpecification.Filters.Aggregate(query,
                (current, filter) => current.Where(filter));

            // Includes all expression-based includes
            query = abstractSpecification.Includes.Aggregate(query,
                (current, include) => current.Include(include));

            // Include any string-based include statements
            query = abstractSpecification.IncludeStrings.Aggregate(query,
                (current, include) => current.Include(include));


            // Apply ordering if expressions are set
            if (abstractSpecification.OrderBy != null)
            {
                var sortedQuery = query.OrderBy(abstractSpecification.OrderBy);

                // Apply then ordering if expressions are set
                if (abstractSpecification.ThenBy != null)
                {
                    sortedQuery = sortedQuery.ThenBy(abstractSpecification.ThenBy);
                }

                if (abstractSpecification.ThenByDescending != null)
                {
                    sortedQuery = sortedQuery.ThenBy(abstractSpecification.ThenByDescending);
                }

                query = sortedQuery;
            }
            else if (abstractSpecification.OrderByDescending != null)
            {
                var sortedQuery = query.OrderByDescending(abstractSpecification.OrderByDescending);

                // Apply then ordering if expressions are set
                if (abstractSpecification.ThenBy != null)
                {
                    sortedQuery = sortedQuery.ThenBy(abstractSpecification.ThenBy);
                }

                if (abstractSpecification.ThenByDescending != null)
                {
                    sortedQuery = sortedQuery.ThenBy(abstractSpecification.ThenByDescending);
                }

                query = sortedQuery;
            }

            // Apply group by if expressions are set
            if (abstractSpecification.GroupBy != null)
            {
                query = query.GroupBy(abstractSpecification.GroupBy).SelectMany(x => x);
            }

            // Apply ignore query filters
            if (abstractSpecification.IgnoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            return query;
        }
        
        private static IQueryable<TEntity> ApplyPaging<TEntity>(this IQueryable<TEntity> queryable,
            AbstractSpecification<TEntity> abstractSpecification)
            where TEntity : class, IEntity
        {
            var query = queryable;

            // Apply paging if enabled
            if (abstractSpecification.IsPagingEnabled)
            {
                query = query.Skip(abstractSpecification.Skip)
                    .Take(abstractSpecification.Take);
            }

            return query;
        }
    }
}