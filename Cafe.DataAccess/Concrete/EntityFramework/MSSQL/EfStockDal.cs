using Cafe.Core.DataAccess.EntityFramework;
using Cafe.DataAccess.Abstract;
using Cafe.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Cafe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfStockDal:EfEntityRepository<Stock,CafeContext>,IStockDal
    {
    }
}
