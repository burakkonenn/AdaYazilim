using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.Services.Train;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITrainService, TrainService>();
            services.AddScoped<ITrainReadRepository, TrainReadRepository>();

            return services;
        }
    }
}
