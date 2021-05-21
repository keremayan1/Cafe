using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.DataAccess;
using Cafe.Core.Entities.Concrete;

namespace Cafe.DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
   {
       List<OperationClaim> GetClaims(User user);
   }
}
