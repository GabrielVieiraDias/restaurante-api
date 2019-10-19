using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class RestaurantRequest : BaseRequest
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
