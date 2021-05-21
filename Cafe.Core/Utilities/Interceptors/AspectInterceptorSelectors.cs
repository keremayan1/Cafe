using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Cafe.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelectors : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList(); // çağrılan classların attributelarını alması
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList(); // çağrılan methodların attributelarını alması
            classAttributes.AddRange(methodAttributes);
         //   classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priorty).ToArray(); //Alınan  Attributeları yukarıdan aşağıya göre sırala
        }
    }
}
