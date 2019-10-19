using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Infra.Data.Context;

namespace Restaurante.Infra.Data.Repository
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(ContextDb context)
            : base(context)
        {
        }
    }
}
