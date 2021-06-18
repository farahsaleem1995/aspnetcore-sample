using System;
using AspTodo.Core.Domain.Contracts;

namespace AspTodo.Core.Domain.Models
{
    public class TodoEntity : IHasKey<int>, IEntity, ISoftDeleted
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}