using AspTodo.Core.Application.Contracts;
using AspTodo.Core.Application.Services;
using AspTodo.Core.Domain.Contracts;
using AspTodo.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AspTodo.Infra.IoC
{
    public partial class DependencyContainer
    {
        private static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<ITodoService, TodoService>();
        }
    }
}