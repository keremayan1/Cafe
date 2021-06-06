using System;
using System.Collections.Generic;
using System.Text;
using Cafe.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Microsoft.EntityFrameworkCore;

namespace Cafe.DataAccess.Concrete.EntityFramework.SQLite.Context
{
   public class SqlLiteDataContext:CafeContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\kerem\Desktop\DB Browser for SQLite\Cafe.db");
        }
    }
}
