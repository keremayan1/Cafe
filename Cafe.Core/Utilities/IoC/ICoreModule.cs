using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Core.Utilities.IoC
{
   public interface ICoreModule
   {
       void Load(IServiceCollection collection);
   }
}
