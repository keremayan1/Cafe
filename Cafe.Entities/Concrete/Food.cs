using Cafe.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cafe.Entities.Concrete
{
    //Discriminator hatasi
    public class Food : IEntity
    {
        public int Id { get; set; }
        public string Spiece { get; set; }
        public string Name { get; set; }

    }
}
