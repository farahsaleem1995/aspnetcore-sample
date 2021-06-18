using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AspTodo.Core.Domain.Contracts
{
    public abstract class Specification<TEntity>
        where TEntity: class, IEntity
    {
        protected Specification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
        
        protected Specification()
        {
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
        
        public List<string> IncludeStrings { get; } = new List<string>();

        public List<Expression<Func<TEntity, bool>>> Filters { get; private set; } = new List<Expression<Func<TEntity, bool>>>();

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public Expression<Func<TEntity, object>> ThenBy { get; private set; }

        public Expression<Func<TEntity, object>> ThenByDescending { get; private set; }
        
        public Expression<Func<TEntity, object>> GroupBy { get; private set; }
        
        public int Take { get; private set; }
        
        public int Skip { get; private set; }
        
        public bool IsPagingEnabled { get; private set; } = false;

        public bool IgnoreQueryFilters { get; private set; }

        public void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
        
        public void AddFilter(Expression<Func<TEntity, bool>> filterExpression)
        {
            Filters.Add(filterExpression);
        }

        public void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        public void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
        
        public void ApplyThenBy(Expression<Func<TEntity, object>> thenByExpression)
        {
            ThenBy = thenByExpression;
        }

        public void ApplyThenByDescending(Expression<Func<TEntity, object>> thenByDescendingExpression)
        {
            ThenByDescending = thenByDescendingExpression;
        }
        
        public void ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

        public void ApplyIgnoreQueryFilters()
        {
            IgnoreQueryFilters = true;
        }
    }
}