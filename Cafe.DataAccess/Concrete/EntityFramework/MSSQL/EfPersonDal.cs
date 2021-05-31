﻿using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.DataAccess.EntityFramework;
using Cafe.DataAccess.Abstract;
using Cafe.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Cafe.Entities.Concrete;

namespace Cafe.DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfPersonDal:EfEntityRepository<Person,CafeContext>,IPersonDal
    {
    }
}
