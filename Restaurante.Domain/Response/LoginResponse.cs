using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Response
{
    [DataContract]
    public class LoginResponse : BaseResponse
    {
        [DataMember(Name = "authenticated")]
        public bool Authenticated { get; set; }

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "expires_in")]
        public long ExpiresIn { get; set; }

        [DataMember(Name = "token_type")]
        public string TokenType { get; set; } = "Bearer";

        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "roles")]
        public IEnumerable<string> Roles { get; set; }
    }
}
