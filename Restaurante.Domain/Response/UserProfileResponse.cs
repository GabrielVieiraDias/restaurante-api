using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Response
{
    [DataContract]
    public class UserProfileResponse : BaseResponse
    {
        [DataMember(Name = "user_id")]
        public long UserId { get; set; }

        [DataMember(Name = "profile_id")]
        public long ProfileId { get; set; }

    }
}
