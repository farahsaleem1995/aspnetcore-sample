using System;
using AspTodo.Core.Domain.Contracts;

namespace AspTodo.Core.Domain.Models
{
    public class TodoEntity : IEntity, ISoftDeleted
    {
        public int Id
        {
            get => KeyId.Get<int>("Id");
            set => KeyId.Set("Id", value);
        }

        public KeyId KeyId { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public bool Deleted { get; set; }
        
        public DateTime? DeletedAt { get; set; }

        public TodoEntity()
        {
            KeyId = new KeyId();
        }
    }
}