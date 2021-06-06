using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.DataAccess.EntityFramework;
using Cafe.DataAccess.Abstract;
using Cafe.DataAccess.Concrete.EntityFramework.SQLite.Context;
using Cafe.Entities.Concrete;

namespace Cafe.DataAccess.Concrete.EntityFramework.SQLite
{
 public   class EfPersonDal:EfEntityRepository<Person,SqlLiteDataContext>,IPersonDal
    {
      
    }
}
