using Microsoft.Extensions.DependencyInjection;

namespace FindJob
{
    public static class DI
    {
        public static IServiceCollection Init(this IServiceCollection services)
        {
            services.AddMvc();            
            return services;
        }
    }
}
