using System.Threading.Tasks;

namespace AspTodo.Core.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Complete();
        
        Task CompleteAsync();
    }
}