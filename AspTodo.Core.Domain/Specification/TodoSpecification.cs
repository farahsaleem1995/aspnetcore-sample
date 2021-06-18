using AspTodo.Core.Domain.Contracts;
using AspTodo.Core.Domain.Models;

namespace AspTodo.Core.Domain.Specification
{
    public sealed class TodoAbstractSpecification : AbstractSpecification<TodoEntity>
    {
        public TodoAbstractSpecification()
        {
        }
        
        public TodoAbstractSpecification(int id)
            : base(entity => entity.Id == id)
        {
        }
    }
}