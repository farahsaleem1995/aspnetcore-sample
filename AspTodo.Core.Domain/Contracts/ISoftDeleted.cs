using System;

namespace AspTodo.Core.Domain.Contracts
{
    public interface ISoftDeleted
    {
        bool Deleted { get; set; }
        
        DateTime? DeletedAt { get; set; }
    }
}