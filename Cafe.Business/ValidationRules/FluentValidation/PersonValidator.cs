using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Entities.Concrete;
using FluentValidation;

namespace Cafe.Business.ValidationRules.FluentValidation
{
  public  class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.NationalId).NotEmpty();
            RuleFor(p => p.NationalId).MaximumLength(11).WithMessage("TC-Kimlik No 11 Karakterli Olmalıdır!");
            RuleFor(p => p.Name).MaximumLength(64).WithMessage("Ad En Fazla 64 Karakterli Olmalıdır");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Ad en az 2 Karakterli Olmalıdır");
            RuleFor(p => p.LastName).MaximumLength(64).WithMessage("Soyad En Fazla 64 Karakterli Olmalıdır");
            RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyad en az 2 Karakterli Olmalıdır");
            RuleFor(p => p.DateOfBirth).LessThan(DateTime.Today).WithMessage("Dogum Gunu Bugun Olamaz!");
           
        }
    }
}
