using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Utilities.Results;
using Cafe.Entities.Concrete;

namespace Cafe.Business.Abstract
{
   public interface IPersonService
   {
       IDataResult<List<Person>>  GetPerson();
       IResult Add(Person person);
   }
}
