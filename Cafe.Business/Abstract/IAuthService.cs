using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities.Concrete;
using Cafe.Core.Utilities.Results;
using Cafe.Core.Utilities.Security.JWT;
using Cafe.Entities.Dto;

namespace Cafe.Business.Abstract
{
  public  interface IAuthService
  {
      IDataResult<User> Login(UserForLoginDto userForLoginDto);
      IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
      IDataResult<AccessToken> CreateAccessToken(User user);
      IResult UserExists(string email);
  }
}
