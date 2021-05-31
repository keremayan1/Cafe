using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.DataAccess;
using Cafe.Entities.Concrete;

namespace Cafe.DataAccess.Abstract
{
  public  interface IPersonDal:IEntityRepository<Person>
    {
    }
}
