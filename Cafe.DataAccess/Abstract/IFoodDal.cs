using Cafe.Core.DataAccess;
using Cafe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.DataAccess.Abstract
{
 public   interface IFoodDal:IEntityRepository<Food>
    {
    }
}
