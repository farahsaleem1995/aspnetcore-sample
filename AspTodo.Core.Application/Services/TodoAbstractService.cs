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
    public class TodoAbstractService : AbstractService, ITodoService
    {
        private readonly IRepository<TodoEntity> _todoRepository;

        public TodoAbstractService(IHttpContextAccessor httpContextAccessor, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IRepository<TodoEntity> todoRepository)
            : base(httpContextAccessor, unitOfWork, mapper)
        {
            _todoRepository = todoRepository;
        }


        public async Task<QueryListDto<TodoDto>> GetAllAsync()
        {
            var todos = await _todoRepository.PagingAsync(new TodoAbstractSpecification());

            return Mapper.Map<QueryList<TodoEntity>, QueryListDto<TodoDto>>(todos);
        }

        public async Task<TodoDto> GetByIdAsync(int id)
        {
            var todo = await _todoRepository.FindAsync(new TodoAbstractSpecification(id));

            return Mapper.Map<TodoEntity, TodoDto>(todo);
        }
    }
}