using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Domain.Interfaces.Services
{
    public interface IUserProfileService : IService<UserProfileRequest, UserProfileResponse, UserProfile>
    {
    }
}
