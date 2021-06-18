using System;
using AspTodo.Core.Application.Utils;

namespace AspTodo.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ApplicationProfile : Attribute
    {
        public ApplicationProfile()
        {
        }
    }
}