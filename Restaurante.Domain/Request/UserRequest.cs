using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Restaurante.Domain.Entities;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class UserRequest : BaseRequest
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "password")]
        public string PasswordHash { get; set; }
    }
}
