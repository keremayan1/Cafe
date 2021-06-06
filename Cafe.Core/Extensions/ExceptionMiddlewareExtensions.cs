using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Cafe.Core.Extensions
{
   public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigrueCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            
        }
    }
}
