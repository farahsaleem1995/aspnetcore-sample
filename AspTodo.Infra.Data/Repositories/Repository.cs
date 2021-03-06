using System.Collections.Generic;
using System.Threading.Tasks;
using AspTodo.Core.Domain.Contracts;
using AspTodo.Core.Domain.Models;
using AspTodo.Infra.Data.Context;
using AspTodo.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AspTodo.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity: class, IEntity
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

        public async Task<IEnumerable<TEntity>> FindAllAsync(AbstractSpecification<TEntity> abstractSpecification)
        {
            _entities.ApplySpecification(abstractSpecification, out var totalQuery);

            return await totalQuery.ToListAsync();
        }

        public async Task<QueryList<TEntity>> PagingAsync(AbstractSpecification<TEntity> abstractSpecification)
        {
            var items = _entities.ApplySpecification(abstractSpecification, out var totalQuery);

            return new QueryList<TEntity>
            {
                Total = await totalQuery.CountAsync(),
                Items = await items.ToListAsync()
            };
        }

        public async Task<TEntity> FindAsync(AbstractSpecification<TEntity> abstractSpecification)
        {
            var items = _entities.ApplySpecification(abstractSpecification);

            return await items.FirstOrDefaultAsync();
        }

        public async Task<bool> Exist(AbstractSpecification<TEntity> abstractSpecification)
        {
            var items = _entities.ApplySpecification(abstractSpecification);

            return await items.AnyAsync();
        }

        public async Task<int> Count(AbstractSpecification<TEntity> abstractSpecification)
        {
            var items = _entities.ApplySpecification(abstractSpecification);

            return await items.CountAsync();
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