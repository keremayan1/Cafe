using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cafe.Core.DataAccess.EntityFramework;
using Cafe.Core.Entities.Concrete;
using Cafe.DataAccess.Abstract;
using Cafe.DataAccess.Concrete.EntityFramework.MSSQL.Context;


namespace Cafe.DataAccess.Concrete.EntityFramework.MSSQL
{
    public class EfUserDal : EfEntityRepository<User, CafeContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CafeContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
