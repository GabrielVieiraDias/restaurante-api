using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Infra.Data.Context;

namespace Restaurante.Infra.Data.Repository
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ContextDb context)
            : base(context)
        {
        }
    }
}
