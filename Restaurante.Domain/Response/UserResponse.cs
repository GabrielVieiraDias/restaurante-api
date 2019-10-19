using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Response
{
    [DataContract]
    public class UserResponse : BaseResponse
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "date_register")]
        public DateTime DateRegister { get; set; }
        [DataMember(Name = "date_update")]
        public DateTime DateUpdate { get; set; }

        [DataMember(Name = "user_profiles")]
        public IEnumerable<UserProfileResponse> UserProfiles { get; set; }
    }
}
