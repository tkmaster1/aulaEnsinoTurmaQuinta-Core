using Microsoft.Extensions.DependencyInjection;
using System;
using TKMaster.AulaEnsino.Core.IoC;

namespace TKMaster.AulaEnsino.Core.WebApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            BootStrapper.RegisterServices(services);
        }
    }
}
