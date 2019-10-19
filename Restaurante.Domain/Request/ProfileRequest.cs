using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class ProfileRequest : BaseRequest
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
