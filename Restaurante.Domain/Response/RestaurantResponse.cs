using Restaurante.Domain.Response;
using System.Runtime.Serialization;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class RestaurantResponse : BaseResponse
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
