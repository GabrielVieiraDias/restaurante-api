using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : APIController
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        /// <summary>
        /// Salva Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("save")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public IActionResult Save([FromBody]UserRequest user)
        {
            try
            {
                return Ok(_userService.SaveUser(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca todos os usuários
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}