using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagement.Infrastructure
{
    public static class AddInfrastructureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementAppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ProductDbConnection")));
            
            return services;
        }
    }
}
