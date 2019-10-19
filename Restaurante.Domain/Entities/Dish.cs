using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string Description { get; set; }
        public float Price { get; set; }
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
