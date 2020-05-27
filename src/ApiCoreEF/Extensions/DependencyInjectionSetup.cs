using ApiCoreEF.Infra.CrossCutting.IoC;
using ApiCoreEF.Infra.Data.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApiCoreEF.Extensions
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInject.RegisterServices(services);
        }
    }
}
