using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Cafe.Core.Extensions
{
  public  class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode{ get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
