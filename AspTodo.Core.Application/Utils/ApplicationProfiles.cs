using System;
using System.Collections.Generic;
using System.Linq;
using AspTodo.Core.Application.Attributes;

namespace AspTodo.Core.Application.Utils
{
    public static class ApplicationProfiles
    {
        public static List<Type> GetAll()
        {
            var profiles = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            assemblies.ForEach(assembly =>
            {
                assembly.GetTypes()
                    .Where(type => type.GetCustomAttributes(typeof(ApplicationProfile), true).Length > 0)
                    .ToList()
                    .ForEach(profiles.Add);
            });

            return profiles;
        }
    }
}