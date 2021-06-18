using AspTodo.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspTodo.Infra.Data.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void Entity<TEntity, TKeyId>(this EntityTypeBuilder<TEntity> builder, string table)
            where TEntity: class, IEntity<TKeyId>
            where TKeyId: KeyId
        {
            builder.Ignore(entity => entity.KeyId);

            builder.Property(entity => entity.CreatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("CreatedAt");
            
            builder.Property(entity => entity.UpdatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("UpdatedAt");

            builder.ToTable(table);
        }
        
        public static void SoftDeleted<TSoftDeleted>(this EntityTypeBuilder<TSoftDeleted> builder)
            where TSoftDeleted: class, ISoftDeleted
        {
            builder.Property(entity => entity.DeletedAt)
                .HasColumnType("datetime2")
                .HasColumnName("DeletedAt");
            
            builder.Property(entity => entity.Deleted)
                .HasColumnType("bit")
                .HasColumnName("Deleted");
        }
    }
}