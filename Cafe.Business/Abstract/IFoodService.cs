using Cafe.Core.Utilities.Results;
using Cafe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Business.Abstract
{
  public  interface IFoodService
    {
        IDataResult<List<Food>> GetAll();
        IDataResult<List<Food>> GetByFoodId(int id);
        IResult Add(Food food);
        IResult Delete(Food food);
        IResult Update(Food food);


    }
}
