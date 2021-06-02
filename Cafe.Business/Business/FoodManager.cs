using Cafe.Business.Abstract;
using Cafe.Core.Utilities.Results;
using Cafe.DataAccess.Abstract;
using Cafe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Business.Adapters.Person;

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
            _foodDal.Delete(food);
            return new SuccessResult();
        }

        public IDataResult<List<Food>> GetAll()
        {
            return new SuccessDataResult<List<Food>>(_foodDal.GetAll());
        }

        public IDataResult<List<Food>> GetByFoodId(int id)
        {
            return new SuccessDataResult<List<Food>>(_foodDal.GetAll(p => p.Id == id));
        }

        public IResult Update(Food food)
        {
            _foodDal.Update(food);
            return new SuccessResult();
        }

       
        
    }
}
