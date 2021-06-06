using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Core.Entities;

namespace Cafe.Entities.Concrete
{
   public class Person:IEntity
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime  DateOfBirth { get; set; }
    }
}
