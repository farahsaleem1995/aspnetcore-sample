using System.Reflection;
using AspTodo.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AspTodo.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}