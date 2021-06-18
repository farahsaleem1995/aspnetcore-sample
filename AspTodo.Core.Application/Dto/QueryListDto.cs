using System.Collections.Generic;

namespace AspTodo.Core.Application.Dto
{
    public class QueryListDto<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}