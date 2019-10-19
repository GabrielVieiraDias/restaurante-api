using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Application.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : APIController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Autenticação do Usuário. (Retorna Token)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public IActionResult Authenticate([FromBody]LoginRequest login)
        {
            try
            {
                return Ok(_loginService.Authenticate(login));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}