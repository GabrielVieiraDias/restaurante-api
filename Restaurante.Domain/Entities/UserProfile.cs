using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
