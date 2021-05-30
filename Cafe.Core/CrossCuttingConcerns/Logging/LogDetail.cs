using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.CrossCuttingConcerns.Logging
{
   public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameter { get; set; }
    }
}
