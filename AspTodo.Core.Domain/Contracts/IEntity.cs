using System;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IEntity
    {
        KeyId KeyId { get; set; }

        DateTime CreatedAt { get; set; }
        
        DateTime UpdatedAt { get; set; }
    }
}