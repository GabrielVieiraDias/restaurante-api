using System.Collections.Generic;
using System.Security.Claims;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Domain.Interfaces.Services
{
    public interface IUserService : IService<UserRequest, UserResponse, User>
    {
        UserResponse SaveUser(UserRequest user);
    }
}
