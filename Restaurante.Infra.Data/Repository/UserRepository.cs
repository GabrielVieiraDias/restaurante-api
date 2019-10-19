using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Infra.Data.Context;

namespace Restaurante.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ContextDb context)
            : base(context)
        {
        }
    }
}
