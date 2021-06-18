using System.Linq;
using System.Threading.Tasks;
using AspTodo.Core.Application.Contracts;
using AspTodo.Core.Application.Dto;
using AspTodo.Core.Domain.Contracts;
using AspTodo.Core.Domain.Models;
using AspTodo.Core.Domain.Specification;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AspTodo.Core.Application.Services
{
    public class TodoService : Service, ITodoService
    {
        private readonly IRepository<TodoEntity, TodoKeyId> _todoRepository;

        public TodoService(IHttpContextAccessor httpContextAccessor, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IRepository<TodoEntity, TodoKeyId> todoRepository)
            : base(httpContextAccessor, unitOfWork, mapper)
        {
            _todoRepository = todoRepository;
        }


        public async Task<QueryListDto<TodoDto>> GetAllAsync()
        {
            var todos = await _todoRepository.FindAllAsync(new TodoSpecification());

            return Mapper.Map<QueryList<TodoEntity>, QueryListDto<TodoDto>>(todos);
        }

        public async Task<TodoDto> GetByIdAsync()
        {
            var todos = await _todoRepository.FindAllAsync(new TodoSpecification());

            return Mapper.Map<TodoEntity, TodoDto>(todos.Items.FirstOrDefault());
        }
    }
}