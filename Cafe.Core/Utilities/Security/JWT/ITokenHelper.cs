using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities.Concrete;

namespace Cafe.Core.Utilities.Security.JWT
{
   public interface ITokenHelper
   {
       AccessToken CreateAccessToken(User user,List<OperationClaim>operationClaims);
   }
}
