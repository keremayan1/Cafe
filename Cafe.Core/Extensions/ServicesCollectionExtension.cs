using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Core.Extensions
{
   public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection collection, params ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(collection);
            }

            return ServiceTool.Create(collection);
        }
    }
}
