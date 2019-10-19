using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class UserProfileRequest : BaseRequest
    {
        [DataMember(Name = "user_id")]
        public long UserId { get; set; }

        [DataMember(Name = "profile_id")]
        public long ProfileId { get; set; }
    }
}
