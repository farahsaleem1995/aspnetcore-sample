using System.Collections.Generic;
using System.Threading.Tasks;
using AspTodo.Core.Domain.Models;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IRepository<TEntity, TKeyId>
        where TEntity: class, IEntity<TKeyId>
        where TKeyId: KeyId
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        
        Task<QueryList<TEntity>> FindAllAsync(Specification<TEntity, TKeyId> specification);
        
        Task<TEntity> FindAsync(TKeyId id);
        
        Task<TEntity> FindAsync(Specification<TEntity, TKeyId> specification);

        Task CreateAsync(TEntity entity);
        
        Task RemoveAsync(TEntity entity);
        
        void Create(TEntity entity);
        
        void Remove(TEntity entity);
    }
}