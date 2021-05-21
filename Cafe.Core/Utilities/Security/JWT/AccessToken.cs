using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.Utilities.Security.JWT
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
