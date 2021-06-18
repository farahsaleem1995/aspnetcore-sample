using System;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        
        DateTime UpdatedAt { get; set; }
    }
}