using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateUpdate { get; set; }

        public IEnumerable<UserProfile> UserProfiles { get; set; }
    }
}
