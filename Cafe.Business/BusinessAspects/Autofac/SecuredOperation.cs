using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using Cafe.Core.Extensions;
using Cafe.Core.Utilities.Interceptors;
using Cafe.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _contextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _contextAccessor.HttpContext.User.ClaimRole();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }   
            }
            throw new AuthenticationException("Yetkiniz Yok");
        }
    }
}
