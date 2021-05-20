using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.Utilities.Results
{
public   interface IDataResult<T>:IResult
    {
         T Data { get; set; }

    }
}
