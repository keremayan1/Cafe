using Cafe.Core.Utilities.Results;
using Cafe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Business.Abstract
{
    public interface IDrinkService
    {
        IDataResult<List<Drink>> GetAll();
        IDataResult<List<Drink>> GetByDrinkId(int id);
        IResult Add(Drink drink);
        IResult Delete(Drink drink);
        IResult Update(Drink drink);
    }
}
