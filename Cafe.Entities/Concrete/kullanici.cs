using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities;

namespace Cafe.Entities.Concrete
{
   public class kullanici:IEntity
    {
        public long NationalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime  DateOfBirth { get; set; }
    }
}
