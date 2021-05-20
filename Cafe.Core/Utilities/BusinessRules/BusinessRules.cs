using Cafe.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.Utilities.BusinessRules
{
   public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
