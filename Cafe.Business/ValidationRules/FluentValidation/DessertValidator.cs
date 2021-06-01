using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Entities.Concrete;
using FluentValidation;

namespace Cafe.Business.ValidationRules.FluentValidation
{
  public  class DessertValidator:AbstractValidator<Dessert>
    {
        public DessertValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Tatlının İsmi Boş Olamaz!");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Tatlının İsmi En Az 2 Karakterli Olmalıdır!");
            RuleFor(p => p.Name).MaximumLength(64).WithMessage("Tatlının İsmi En Fazla 64 Karakter Olmalıdır!");
            
        }
    }
}
