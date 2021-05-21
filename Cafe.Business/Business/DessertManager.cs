using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Business.Abstract;
using Cafe.Business.ValidationRules.FluentValidation;
using Cafe.Core.Aspects.Autofac.Validation;
using Cafe.Core.Utilities.Results;
using Cafe.DataAccess.Abstract;
using Cafe.Entities.Concrete;

namespace Cafe.Business.Business
{
  public  class DessertManager:IDessertService
  {
      private IDessertDal _dessertDal;

      public DessertManager(IDessertDal dessertDal)
      {
          _dessertDal = dessertDal;
      }

      public IDataResult<List<Dessert>> GetAll()
        {
            return new SuccessDataResult<List<Dessert>>(_dessertDal.GetAll());
        }

        public IDataResult<List<Dessert>> GetByDessertId(int id)
        {
            return  new SuccessDataResult<List<Dessert>>(_dessertDal.GetAll(d=>d.Id==id));
        }
        [ValidationAspect(typeof(DessertValidator))]
        public IResult Add(Dessert dessert)
        {
           _dessertDal.Add(dessert);
           return new SuccessResult();
        }

        public IResult Update(Dessert dessert)
        {
           _dessertDal.Update(dessert);
           return new SuccessResult();
        }

        public IResult Delete(Dessert dessert)
        {
            _dessertDal.Delete(dessert);
            return new SuccessResult();
        }
    }
}
