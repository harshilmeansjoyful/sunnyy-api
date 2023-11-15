using Microsoft.Extensions.DependencyInjection;
using SunnyRewards.HelloWorld.Common.Helpers;
using SunnyRewards.HelloWorld.Common.Helpers.Interfaces;
using SunnyRewards.HelloWorld.Common.Infrastructure;
using SunnyRewards.HelloWorld.Common.Infrastructure.Interfaces;
using SunnyRewards.HelloWorld.Common.Repos;
using SunnyRewards.HelloWorld.Common.Repos.Interfaces;
using SunnyRewards.HelloWorld.Common.Services;
using SunnyRewards.HelloWorld.Common.Services.Interfaces;

namespace SunnyRewards.HelloWorld.Common.ServiceRegistry
{
    public static class RegisterServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IServiceCollection InitDependencies(this IServiceCollection services, Action<IServiceCollection> action)
        {
            action.Invoke(services);

            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            services.AddSingleton<IRuntime, Runtime>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IBaseHelper, BaseHelper>();
            return services;
        }
    }
}
