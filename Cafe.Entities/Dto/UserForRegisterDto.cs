using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities;

namespace Cafe.Entities.Dto
{
    public class UserForRegisterDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
