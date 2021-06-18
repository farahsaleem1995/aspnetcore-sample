using AspTodo.Core.Domain.Models;
using AspTodo.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspTodo.Infra.Data.Configuration
{
    public class TodoEntityConfiguration : IEntityTypeConfiguration<TodoEntity>
    {
        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                .HasColumnType("int")
                .HasColumnName("Id");
            
            builder.Entity("Todo");
            
            builder.SoftDeleted();
        }
    }
}