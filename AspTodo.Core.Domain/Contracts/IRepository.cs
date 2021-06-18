using System.Collections.Generic;
using System.Threading.Tasks;
using AspTodo.Core.Domain.Models;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IRepository<TEntity>
        where TEntity: class, IEntity
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        
        Task<QueryList<TEntity>> FindAllAsync(Specification<TEntity> specification);
        
        Task<TEntity> FindAsync(KeyId id);
        
        Task<TEntity> FindAsync(Specification<TEntity> specification);

        Task CreateAsync(TEntity entity);
        
        Task RemoveAsync(TEntity entity);
        
        void Create(TEntity entity);
        
        void Remove(TEntity entity);
    }
}