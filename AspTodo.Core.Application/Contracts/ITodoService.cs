using System.Threading.Tasks;
using AspTodo.Core.Application.Dto;

namespace AspTodo.Core.Application.Contracts
{
    public interface ITodoService
    {
        Task<QueryListDto<TodoDto>> GetAllAsync();
        
        Task<TodoDto> GetByIdAsync();
    }
}