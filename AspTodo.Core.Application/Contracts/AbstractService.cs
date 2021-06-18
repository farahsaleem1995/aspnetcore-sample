using AspTodo.Core.Domain.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AspTodo.Core.Application.Contracts
{
    public abstract class AbstractService
    {
        protected readonly IHttpContextAccessor HttpContextAccessor;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        protected AbstractService(IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            HttpContextAccessor = httpContextAccessor;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}