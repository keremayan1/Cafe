using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.CrossCuttingConcerns.Caching;
using Cafe.Core.CrossCuttingConcerns.Caching.Microsoft;
using Cafe.Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Core.DependencyResolvers
{
  public  class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection collection)
        {
            collection.AddMemoryCache();
            collection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
