using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Request
{
    [DataContract]
    public class LoginRequest : BaseRequest
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
