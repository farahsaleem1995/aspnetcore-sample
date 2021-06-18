using AspTodo.Core.Application.Dto;
using AspTodo.Core.Domain.Models;
using AutoMapper;

namespace AspTodo.Core.Application.Mapping
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            // Map Domain Model To Dto
            CreateMap(typeof(QueryList<>), typeof(QueryListDto<>));
        }
    }
}