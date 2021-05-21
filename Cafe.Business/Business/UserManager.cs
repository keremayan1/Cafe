using System.Collections.Generic;
using Cafe.Business.Abstract;
using Cafe.Core.Entities.Concrete;
using Cafe.Core.Utilities.Results;
using Cafe.DataAccess.Abstract;

namespace Cafe.Business.Business
{
   
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }

       public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string mail)
        {
            return _userDal.Get(p => p.Email == mail);
            
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
          _userDal.Update(user);
          return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
    }
}
