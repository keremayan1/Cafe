using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Core.Utilities.IoC
{
   public static class ServiceTool //. net core kendi servislerine eristik 
    {
        public static IServiceProvider ServiceProvider { get; set; } // merkezi yonetim sistemi

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider(); //Serviceleri bir degiskene al 
            return services;
        }
    }
}
