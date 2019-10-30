using Restaurante.Domain.Entities;
using Restaurante.Domain.Response;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class DishResponse : BaseResponse
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "restaurant_id")]
        public long RestaurantId { get; set; }

        [DataMember(Name = "restaurant")]
        public RestaurantResponse Restaurant { get; set; }
    }
}
