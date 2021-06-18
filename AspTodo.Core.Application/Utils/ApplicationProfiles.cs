using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

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
                    .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Profile)))
                    .ToList()
                    .ForEach(profiles.Add);
            });

            return profiles;
        }
    }
}