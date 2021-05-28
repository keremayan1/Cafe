using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.CrossCuttingConcerns.Caching;
using Cafe.Core.Utilities.Interceptors;
using Cafe.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Core.Aspects.Autofac.Caching
{
   public class CacheRemoveAspect:MethodInterception
   {
       private string _pattern;
       private ICacheManager _cacheManager;

       public CacheRemoveAspect(string pattern)
       {
           _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
       }
        public override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
