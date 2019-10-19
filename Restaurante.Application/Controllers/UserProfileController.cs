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
    public class UserProfileController : APIController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        /// <summary>
        /// Salva relação do usuário com o perfil
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        [HttpPost("saveUserProfile")]
        [ProducesResponseType(typeof(UserProfileResponse), StatusCodes.Status200OK)]
        public IActionResult SaveUserProfile([FromBody]UserProfileRequest userProfile)
        {
            try
            {
                return Ok(_userProfileService.Insert<UserProfileValidator>(userProfile));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}