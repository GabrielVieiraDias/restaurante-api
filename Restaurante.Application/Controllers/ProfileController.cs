using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;
using Restaurante.Service.Validators;

namespace Restaurante.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : APIController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Salva Perfil
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost("save")]
        [ProducesResponseType(typeof(ProfileResponse), StatusCodes.Status200OK)]
        public IActionResult Save([FromBody]ProfileRequest profile)
        {
            try
            {
                return Ok(_profileService.Insert<ProfileValidator>(profile));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}