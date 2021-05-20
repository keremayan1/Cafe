using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.Utilities.Results
{
    public class ErrorResult : Result, IResult
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}
