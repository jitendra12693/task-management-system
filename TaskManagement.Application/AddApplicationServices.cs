using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.IRepository;
using TaskManagement.Infrastructure;
using TaskManagement.Infrastructure.Repository;

namespace TaskManagement.Application
{
    public static class AddApplicationServices
    {
        public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add application layer services here, e.g., MediatR, AutoMapper, etc.
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddInfrastructureServices(configuration);
            services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssembly(typeof(AddApplicationServices).Assembly);
            });
            return services;
        }
    }
}
