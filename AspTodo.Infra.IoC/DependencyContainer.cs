using System;
using AspTodo.Core.Application.Contracts;
using AspTodo.Core.Application.Mapping;
using AspTodo.Core.Application.Services;
using AspTodo.Core.Application.Utils;
using AspTodo.Core.Domain.Contracts;
using AspTodo.Infra.Data.Context;
using AspTodo.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspTodo.Infra.IoC
{
    public static partial class DependencyContainer
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterContext(configuration);
            
            services.RegisterAutoMapper();
            
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            RegisterAppServices(services);
        }
        
        private static void RegisterContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnectionString");
            
            services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseSqlServer(connection,
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        
        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(ApplicationProfiles.GetAll().ToArray());
        }
    }
}