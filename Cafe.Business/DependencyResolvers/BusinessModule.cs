using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Utilities.IoC;
using Cafe.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Cafe.DataAccess.Concrete.EntityFramework.SQLite.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cafe.Business.DependencyResolvers
{
   public class BusinessModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddDbContext<DbContext>(optionsAction=>optionsAction.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = Cafe; Trusted_Connection = true"));
           services.AddDbContext<DbContext,SqlLiteDataContext>(optionsLifetime=>optionsLifetime.UseSqlite("CafeSqlLiteContext"));
       
        }
    }
}
