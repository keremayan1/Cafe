using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cafe.Business.Abstract;
using Cafe.Business.Adapters.Person;
using Cafe.Business.ValidationRules.FluentValidation;
using Cafe.Core.Aspects.Autofac.Validation;
using Cafe.Core.Utilities.BusinessRules;
using Cafe.Core.Utilities.Results;
using Cafe.DataAccess.Abstract;
using Cafe.Entities.Concrete;

namespace Cafe.Business.Business
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;
        private IKpsService _kpsService;

        public PersonManager(IPersonDal personDal, IKpsService kpsService)
        {
            _personDal = personDal;
            _kpsService = kpsService;
        }

        public IDataResult<List<Person>> GetPerson()
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetAll());
        }
        [ValidationAspect(typeof(PersonValidator))]
        public IResult Add(Person person)
        {
            var result = BusinessRules.Run(CheckIfRealPerson(person),
                
               PersonInformationToUpper(person));
            if (result != null)
            {
                return result;
            }
            _personDal.Add(person);
            return new SuccessResult("Islem Basarili");
        }

        public IResult Update(Person person)
        {
            var result = BusinessRules.Run(CheckIfPersonExists(person.NationalId),
                CheckIfRealPerson(person),
                PersonInformationToUpper(person));
            if (result != null)
            {
                return result;
            }
            _personDal.Update(person);
            return new SuccessResult("Durum Guncellendi");
        }
        // Business Codes
        private static IResult PersonInformationToUpper(Person person)
        {
            person.Name = person.Name.ToUpper();
            person.LastName = person.LastName.ToUpper();
            return new SuccessResult();
        }
        private IResult CheckIfRealPerson(Person person)
        {
            var result = _kpsService.Verify(person).Result;
            if (result != true)
            {
                return new ErrorResult("Hatali TC-Kimlik No");
            }
            return new SuccessResult();
        }

        private IResult CheckIfPersonExists(string nationalId)
        {
            var result = _personDal.GetAll(p => p.NationalId == nationalId).Any();
            if (result)
            {
                return new ErrorResult("Bu Kullanici Sistemde Mevcut");
            }
            return new SuccessResult();
        }




    }
}
