using AspTodo.Core.Application.Dto;
using AspTodo.Core.Domain.Models;
using AutoMapper;

namespace AspTodo.Core.Application.Mapping
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            // Map Domain Model To Dto
            CreateMap<TodoEntity, TodoDto>();
        }
    }
}