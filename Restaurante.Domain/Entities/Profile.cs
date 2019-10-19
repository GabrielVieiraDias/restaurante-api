using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public string Description { get; set; }

        public IEnumerable<UserProfile> UserProfiles { get; set; }
    }
}
