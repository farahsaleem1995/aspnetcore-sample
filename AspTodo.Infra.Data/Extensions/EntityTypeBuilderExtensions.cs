using System;
using System.Linq.Expressions;
using AspTodo.Core.Domain.Contracts;
using AspTodo.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspTodo.Infra.Data.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void Key<THasKey, TKey>(this EntityTypeBuilder<THasKey> builder, string type)
            where THasKey : class, IHasKey<TKey>
            where TKey : struct, IConvertible, IComparable<TKey>, IEquatable<TKey>
        {
            builder.HasKey(entity => entity.Id);
            
            builder.Property(entity => entity.Id)
                .HasColumnType(type)
                .HasColumnName("Id");
        }

        public static void Entity<TEntity>(this EntityTypeBuilder<TEntity> builder, string table)
            where TEntity : class, IEntity
        {
            builder.Property(entity => entity.CreatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("CreatedAt");

            builder.Property(entity => entity.UpdatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("UpdatedAt");

            builder.ToTable(table);
        }

        public static void SoftDeleted<TSoftDeleted>(this EntityTypeBuilder<TSoftDeleted> builder)
            where TSoftDeleted : class, ISoftDeleted
        {
            builder.Property(entity => entity.DeletedAt)
                .HasColumnType("datetime2")
                .HasColumnName("DeletedAt");

            builder.Property(entity => entity.Deleted)
                .HasColumnType("bit")
                .HasColumnName("Deleted");
        }

        public static void Column<TEntity, T>(this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, T>> propertyExpression, string type, string name)
            where TEntity : class
            where T : struct, IConvertible, IComparable<T>, IEquatable<T>
        {
            builder.Property(propertyExpression)
                .HasColumnType(type)
                .HasColumnName(name);
        }
    }
}