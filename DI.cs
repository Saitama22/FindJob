using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
