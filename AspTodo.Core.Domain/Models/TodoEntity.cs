using System;
using AspTodo.Core.Domain.Contracts;

namespace AspTodo.Core.Domain.Models
{
    public class TodoEntity : IEntity<TodoKeyId>, ISoftDeleted
    {
        public int Id
        {
            get => KeyId.Get<int>("Id");
            set => KeyId.Set("Id", value);
        }

        public TodoKeyId KeyId { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public bool Deleted { get; set; }
        
        public DateTime? DeletedAt { get; set; }
        
        public string GetModelName() => "Todo";

        public TodoEntity()
        {
            KeyId = new TodoKeyId();
        }
    }

    public class TodoKeyId : KeyId
    {
        public TodoKeyId()
        {
        }
        
        public TodoKeyId(int id)
        {
            Set("Id", id);
        }
    }
}