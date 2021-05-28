using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Cafe.Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace Cafe.Core.Aspects.Autofac.Transaction
{
   public class TransactionScopeAspect:MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transaction.Complete();
                }
                catch 
                {
                    transaction.Dispose();
                    throw;
                }
            }
        }
    }
}
