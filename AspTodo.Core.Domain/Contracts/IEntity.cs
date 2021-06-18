using System;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IEntity<TKeyId>
        where TKeyId: KeyId
    {
        TKeyId KeyId { get; set; }

        DateTime CreatedAt { get; set; }
        
        DateTime UpdatedAt { get; set; }

        string GetModelName();
    }
}