using System.Collections.Generic;
using System.Threading.Tasks;
using AspTodo.Core.Domain.Models;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IRepository<TEntity>
        where TEntity: class, IEntity
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        
        Task<IEnumerable<TEntity>> FindAllAsync(AbstractSpecification<TEntity> abstractSpecification);
        
        Task<QueryList<TEntity>> PagingAsync(AbstractSpecification<TEntity> abstractSpecification);
        
        Task<TEntity> FindAsync(AbstractSpecification<TEntity> abstractSpecification);

        Task<bool> Exist(AbstractSpecification<TEntity> abstractSpecification);
        
        Task<int> Count(AbstractSpecification<TEntity> abstractSpecification);

        Task CreateAsync(TEntity entity);
        
        Task RemoveAsync(TEntity entity);
        
        void Create(TEntity entity);
        
        void Remove(TEntity entity);
    }
}