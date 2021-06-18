using System;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IHasKey<TKey>
        where TKey: struct, IConvertible, IComparable<TKey>, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}