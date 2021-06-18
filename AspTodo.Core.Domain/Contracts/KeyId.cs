using System;
using System.Collections.Generic;
using AspTodo.Core.Domain.Exceptions;

namespace AspTodo.Core.Domain.Contracts
{
    public class KeyId
    {
        private readonly IDictionary<string, object> _id;

        public KeyId()
        {
            _id = new Dictionary<string, object>();
        }

        public void Set<T>(string key, T value)
            where T: struct, IConvertible, IComparable, IEquatable<T>
        {
            if (!_id.ContainsKey(key))
            {
                _id.Add(key, value);
            }
            else
            {
                _id[key] = value;
            }
        }

        public T Get<T>(string key)
        {
            try
            {
                return (T)_id[key];
            }
            catch (Exception)
            {
                throw new KeyIdNotFoundException(key);
            }
        }

        public IEnumerable<string> GetKeys()
        {
            return _id.Keys;
        }
    }
}