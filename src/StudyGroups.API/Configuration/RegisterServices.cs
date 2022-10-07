using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyGroups.Core.Interfaces;
using StudyGroups.Core.Services;
using StudyGroups.Infrastructure.DTO;
using StudyGroups.Infrastructure.Persistence.Context;

namespace StudyGroups.API.Configuration
{
    public static class RegisterServices
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbConfig>(configuration);

            services.AddScoped<IDbClient, DbClient>();

            services.AddTransient<IStudyGroupService, StudyGroupService>();
        }
    }
}