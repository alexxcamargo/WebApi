using ApiCoreEF.Application.Interfaces;
using ApiCoreEF.Application.Services;
using ApiCoreEF.Domain.User;
using ApiCoreEF.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCoreEF.Infra.CrossCutting.IoC
{
    public class NativeInject
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
