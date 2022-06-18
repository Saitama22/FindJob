using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FindJob
{
    public static class DI
    {
        public static IServiceCollection Init(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IResumeRepo, ResumeRepo>();
            return services;
        }
    }
}
