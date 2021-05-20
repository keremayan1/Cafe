using Cafe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Entities.Concrete
{
   public class Stock:IEntity
    {
        public int Id { get; set; }
        public string Spieces { get; set; }
        public string FoodSpieces { get; set; }
        public int UnitInStock { get; set; }
    }
}
