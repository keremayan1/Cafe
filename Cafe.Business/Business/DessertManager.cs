using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Cafe.Business.Abstract;
using Cafe.Business.BusinessAspects.Autofac;
using Cafe.Business.ValidationRules.FluentValidation;
using Cafe.Core.Aspects.Autofac.Caching;
using Cafe.Core.Aspects.Autofac.Performance;
using Cafe.Core.Aspects.Autofac.Validation;
using Cafe.Core.Utilities.Results;
using Cafe.DataAccess.Abstract;
using Cafe.Entities.Concrete;

namespace Cafe.Business.Business
{
    public class DessertManager : IDessertService
    {
        private IDessertDal _dessertDal;

        public DessertManager(IDessertDal dessertDal)
        {
            _dessertDal = dessertDal;
        }
        [PerformanceAspect(5)]
        public IDataResult<List<Dessert>> GetAll()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Dessert>>(_dessertDal.GetAll());
        }
        [CacheAspect(10)]
        public IDataResult<List<Dessert>> GetByDessertId(int id)
        {
            return new SuccessDataResult<List<Dessert>>(_dessertDal.GetAll(d => d.Id == id));
        }
       // [SecuredOperation("moderator")]
        [ValidationAspect(typeof(DessertValidator))]
        [CacheRemoveAspect("IDessertService.Get")]
        public IResult Add(Dessert dessert)
        {
            _dessertDal.Add(dessert);
            return new SuccessResult("asd");
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
