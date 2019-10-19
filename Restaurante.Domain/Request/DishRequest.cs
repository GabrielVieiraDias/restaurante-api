﻿using Restaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class DishRequest : BaseRequest
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "price")]
        public float Price { get; set; }

        [DataMember(Name = "restaurant_id")]
        public long RestaurantId { get; set; }
    }
}