using System.Collections.Generic;
using System.Security.Claims;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Domain.Interfaces.Services
{
    public interface ILoginService : IService<LoginRequest, LoginResponse, User>
    {
        string UserLogged { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();

        LoginResponse Authenticate(LoginRequest login);

    }
}
