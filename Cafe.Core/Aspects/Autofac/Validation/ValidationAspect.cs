using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cafe.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Cafe.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;

namespace Cafe.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _type;

        public ValidationAspect(Type type)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception("Hatali Dogrulama Servisi");
            }
            _type = type;
        }

        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_type);
            var entityType = _type.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(p => p.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
