using System;

namespace AspTodo.Core.Domain.Exceptions
{
    public class KeyIdNotFoundException : Exception
    {
        public KeyIdNotFoundException(string key)
            : base($"Key \"{key}\" not found.")
        {
        }
    }
}