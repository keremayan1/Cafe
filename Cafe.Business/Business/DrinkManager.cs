using Cafe.Business.Abstract;
using Cafe.Core.Utilities.Results;
using Cafe.DataAccess.Abstract;
using Cafe.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Aspects.Autofac.Transaction;

namespace Cafe.Business.Business
{
    public class DrinkManager : IDrinkService
    {

        IDrinkDal _drinkDal;

        public DrinkManager(IDrinkDal drinkDal)
        {
            _drinkDal = drinkDal;
        }

        public IResult Add(Drink drink)
        {
            _drinkDal.Add(drink);
            return new SuccessResult();
        }

        public IResult Delete(Drink drink)
        {
            _drinkDal.Delete(drink);
            return new SuccessResult();
        }

        public IDataResult<List<Drink>> GetAll()
        {
            return new SuccessDataResult<List<Drink>>(_drinkDal.GetAll());
        }

        public IDataResult<List<Drink>> GetByDrinkId(int id)
        {
            return new SuccessDataResult<List<Drink>>(_drinkDal.GetAll(p=>p.Id==id));
        }

        public IResult Update(Drink drink)
        {
            _drinkDal.Update(drink);
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult TransactionOperation(Drink drink)
        {
            _drinkDal.Update(drink);
            _drinkDal.Add(drink);
            return new SuccessResult();
        }
    }
}
