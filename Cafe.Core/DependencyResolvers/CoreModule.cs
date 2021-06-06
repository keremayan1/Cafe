using Cafe.Core.CrossCuttingConcerns.Caching;
using Cafe.Core.CrossCuttingConcerns.Caching.Microsoft;
using Cafe.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;


namespace Cafe.Core.DependencyResolvers
{
    public  class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
           

        }
    }
}
