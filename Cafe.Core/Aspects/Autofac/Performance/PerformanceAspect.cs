using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Cafe.Core.Utilities.Interceptors;
using Cafe.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Core.Aspects.Autofac.Performance
{
   public class PerformanceAspect:MethodInterception
   {
       
       private int _interval;
       private Stopwatch _stopwatch;

       public PerformanceAspect(int interval)
       {
           _interval = interval;
           _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
       }

       public override void OnBefore(IInvocation invocation)
       {
           _stopwatch.Start();
           
       }

       public override void OnAfter(IInvocation invocation)
       {
           if (_stopwatch.Elapsed.TotalSeconds>_interval)
           {
               throw new System.Exception($"Performance :{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}--->{_stopwatch.Elapsed.TotalSeconds}");
           }
          _stopwatch.Reset();

       }
   }
}
