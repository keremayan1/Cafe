using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Utilities.Results;
using Cafe.Entities.Concrete;

namespace Cafe.Business.Abstract
{
   public interface IDessertService
   {
       IDataResult<List<Dessert>> GetAll();
       IDataResult<List<Dessert>> GetByDessertId(int id);
       IResult Add(Dessert dessert);
       IResult Update(Dessert dessert);
       IResult Delete(Dessert dessert);

   }
}
