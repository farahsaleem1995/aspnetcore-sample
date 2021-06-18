using AspTodo.Core.Domain.Models;
using AspTodo.Infra.Data.Constants;
using AspTodo.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspTodo.Infra.Data.Configuration
{
    public class TodoEntityConfiguration : IEntityTypeConfiguration<TodoEntity>
    {
        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder.Key<TodoEntity, int>(ColumnType.Int);
            
            builder.Entity("Todo");
            
            builder.SoftDeleted();
        }
    }
}