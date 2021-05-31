using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.CrossCuttingConcerns.Logging;
using Cafe.Core.CrossCuttingConcerns.Logging.Log4Net;
using Cafe.Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace Cafe.Core.Aspects.Autofac.Exception
{
  public  class ExceptionLogAspect:MethodInterception
  {
      private LoggerServiceBase _loggerServiceBase;

      public ExceptionLogAspect(Type loggerServiceBase)
      {
          if (!typeof(LoggerServiceBase).IsAssignableFrom(loggerServiceBase))
          {
              throw new System.Exception("Hata");
          }
          _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceBase);
      }

      public override void OnException(IInvocation invocation, System.Exception exception)
        {
           LogDetailWithException logDetailWithException = GetLogDetail(invocation);
           logDetailWithException.ExceptionMessage = exception.Message;
           _loggerServiceBase.Error(logDetailWithException);
        }

      private LogDetailWithException GetLogDetail(IInvocation invocation)
      {
          var logParameters = new List<LogParameter>();
          for (int i = 0; i < invocation.Arguments.Length; i++)
          {
              logParameters.Add(new LogParameter
              {
                  Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                  Value = invocation.Arguments[i],
                  Type = invocation.Arguments[i].GetType().Name
              });
          }
          var logDetailWithException = new LogDetailWithException
          {
              MethodName = invocation.Method.Name,
              LogParameter = logParameters
          };
          return logDetailWithException;
      }
  }
}
