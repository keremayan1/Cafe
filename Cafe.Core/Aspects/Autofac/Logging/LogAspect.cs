using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cafe.Core.CrossCuttingConcerns.Logging;
using Cafe.Core.CrossCuttingConcerns.Logging.Log4Net;
using Cafe.Core.Utilities.Interceptors;
using Cafe.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerService;

        public LogAspect(Type loggerService)
        {
            if (!typeof(LoggerServiceBase).IsAssignableFrom(loggerService))
            {
                throw new Exception("Hatali Log Servisi");
            }

            _loggerService = (LoggerServiceBase)Activator.CreateInstance(loggerService); // Kullanicidan deger isteniyorsa bunu kullanmaliyiz
            //ServiceTool.ServiceProvider.GetService<LoggerServiceBase>(); Kullanicidan deger istemiyorsak bunu kullanabiliriz
        }

        public override void OnBefore(IInvocation invocation)
        {
            _loggerService.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments.GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameter = logParameters
            };
            return logDetail;
        }
    }
}
