using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities;

namespace Cafe.Entities.Dto
{
  public  class UserForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
