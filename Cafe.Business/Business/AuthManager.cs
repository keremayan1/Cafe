using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Business.Abstract;
using Cafe.Core.Entities.Concrete;
using Cafe.Core.Utilities.Results;
using Cafe.Core.Utilities.Security.Hashing;
using Cafe.Core.Utilities.Security.JWT;
using Cafe.Entities.Dto;

namespace Cafe.Business.Business
{
    public class AuthManager : IAuthService
    {

        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı Bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Hatali Sifre");
            }
            return new SuccessDataResult<User>(userToCheck, "Giris Basarili Hosgeldiniz");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayit Ekleme Islemi Basarili");
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IResult UserExists(string email)
        {
            //if (_userService.GetByMail(email) != null)
            //{
            //    return new ErrorResult("Bu Kullanıcı Sistemde Mevcut");
            //}
            var result = _userService.GetByMail(email);
            if (result != null)
            {
                return new ErrorResult("Bu Kullanıcı Sistemde Mevcut");
            }

            return new SuccessResult();
        }
    }
}
