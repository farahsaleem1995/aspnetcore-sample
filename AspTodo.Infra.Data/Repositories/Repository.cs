using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspTodo.Core.Domain.Contracts;
using AspTodo.Core.Domain.Models;
using AspTodo.Infra.Data.Context;
using AspTodo.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AspTodo.Infra.Data.Repositories
{
    public class Repository<TEntity, TKeyId> : IRepository<TEntity, TKeyId>
        where TEntity: class, IEntity<TKeyId>
        where TKeyId: KeyId
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<QueryList<TEntity>> FindAllAsync(Specification<TEntity, TKeyId> specification)
        {
            var items = _entities.ApplySpecification(specification, out var totalQuery);

            return new QueryList<TEntity>
            {
                Total = await totalQuery.CountAsync(),
                Items = await items.ToListAsync()
            };
        }

        public async Task<TEntity> FindAsync(TKeyId id)
        {
            var idKeys = id.GetKeys();

            var idValues = idKeys.Select(id.Get<object>);

            return await _entities.FindAsync(idValues.ToArray());
        }

        public async Task<TEntity> FindAsync(Specification<TEntity, TKeyId> specification)
        {
            var items = _entities.ApplySpecification(specification);

            return await items.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _context.Remove(entity);
            
            await _context.SaveChangesAsync();
        }

        public void Create(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }
    }
}