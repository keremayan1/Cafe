using Cafe.Business.Abstract;
using Cafe.Core.Utilities.Results;
using Cafe.DataAccess.Abstract;
using Cafe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Business.Business
{
    public class FoodManager : IFoodService
    {
        IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public IResult Add(Food food)
        {
            _foodDal.Add(food);
            return new SuccessResult();
        }

        public IResult Delete(Food food)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Food>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Food>> GetByFoodId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
