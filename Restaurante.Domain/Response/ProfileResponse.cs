using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Response
{
    [DataContract]
    public class ProfileResponse : BaseResponse
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
