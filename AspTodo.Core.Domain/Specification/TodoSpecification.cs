using AspTodo.Core.Domain.Contracts;
using AspTodo.Core.Domain.Models;

namespace AspTodo.Core.Domain.Specification
{
    public sealed class TodoSpecification : Specification<TodoEntity>
    {
        public TodoSpecification()
        {
        }
        
        public TodoSpecification(int id)
            : base(entity => entity.Id == id)
        {
        }
    }
}