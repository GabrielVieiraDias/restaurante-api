using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }
    }
}
