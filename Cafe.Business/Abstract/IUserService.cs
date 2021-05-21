using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities.Concrete;
using Cafe.Core.Utilities.Results;

namespace Cafe.Business.Abstract
{
   public interface IUserService
   {
       IDataResult<List<User>> GetAll();
       List<OperationClaim> GetClaims(User user);
       User GetByMail(string mail);
       IResult Add(User user);
       IResult Update(User user);
       IResult Delete(User user);
   }
}
