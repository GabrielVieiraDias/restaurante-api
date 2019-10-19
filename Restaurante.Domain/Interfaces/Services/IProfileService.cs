using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Domain.Interfaces.Services
{
    public interface IProfileService : IService<ProfileRequest, ProfileResponse, Domain.Entities.Profile>
    {
    }
}
