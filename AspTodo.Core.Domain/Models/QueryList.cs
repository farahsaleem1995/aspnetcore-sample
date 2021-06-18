using System.Collections.Generic;

namespace AspTodo.Core.Domain.Models
{
    public class QueryList<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}