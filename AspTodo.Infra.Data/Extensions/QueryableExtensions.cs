using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspTodo.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspTodo.Infra.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> ApplySpecification<TEntity, TKeyId>(this IQueryable<TEntity> queryable,
            Specification<TEntity, TKeyId> specification, out IQueryable<TEntity> totalQuery)
            where TEntity : class, IEntity<TKeyId>
            where TKeyId : KeyId
        {
            var query = queryable;

            query = query.ApplySpecificationWithoutPaging(specification);

            totalQuery = query;

            return query.ApplyPaging(specification);
        }

        public static IQueryable<TEntity> ApplySpecification<TEntity, TKeyId>(this IQueryable<TEntity> queryable,
            Specification<TEntity, TKeyId> specification)
            where TEntity : class, IEntity<TKeyId>
            where TKeyId : KeyId
        {
            var query = queryable;

            query = query.ApplySpecificationWithoutPaging(specification);

            return query.ApplyPaging(specification);
        }
        
        private static IQueryable<TEntity> ApplySpecificationWithoutPaging<TEntity, TKeyId>(this IQueryable<TEntity> queryable,
            Specification<TEntity, TKeyId> specification)
            where TEntity : class, IEntity<TKeyId>
            where TKeyId : KeyId
        {
            var query = queryable;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // filter by all filter expressions
            query = specification.Filters.Aggregate(query,
                (current, filter) => current.Where(filter));

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query,
                (current, include) => current.Include(include));

            // Include any string-based include statements
            query = specification.IncludeStrings.Aggregate(query,
                (current, include) => current.Include(include));


            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                var sortedQuery = query.OrderBy(specification.OrderBy);

                // Apply then ordering if expressions are set
                if (specification.ThenBy != null)
                {
                    sortedQuery = sortedQuery.ThenBy(specification.ThenBy);
                }

                if (specification.ThenByDescending != null)
                {
                    sortedQuery = sortedQuery.ThenBy(specification.ThenByDescending);
                }

                query = sortedQuery;
            }
            else if (specification.OrderByDescending != null)
            {
                var sortedQuery = query.OrderByDescending(specification.OrderByDescending);

                // Apply then ordering if expressions are set
                if (specification.ThenBy != null)
                {
                    sortedQuery = sortedQuery.ThenBy(specification.ThenBy);
                }

                if (specification.ThenByDescending != null)
                {
                    sortedQuery = sortedQuery.ThenBy(specification.ThenByDescending);
                }

                query = sortedQuery;
            }

            // Apply group by if expressions are set
            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            // Apply ignore query filters
            if (specification.IgnoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            return query;
        }
        
        private static IQueryable<TEntity> ApplyPaging<TEntity, TKeyId>(this IQueryable<TEntity> queryable,
            Specification<TEntity, TKeyId> specification)
            where TEntity : class, IEntity<TKeyId>
            where TKeyId : KeyId
        {
            var query = queryable;

            // Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }

            return query;
        }
    }
}