using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;
using Restaurante.Service.Validators;

namespace Restaurante.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class RestaurantController : APIController
    {
        private readonly IRestaurantService _restaurantService;
        
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        
        /// <summary>
        /// Salva um novo restaurante
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(RestaurantResponse), StatusCodes.Status200OK)]
        public IActionResult Save([FromBody]RestaurantRequest restaurant)
        {
            try
            {
                return Ok(_restaurantService.Insert<RestaurantValidator>(restaurant));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Edita um restaurante
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(RestaurantResponse), StatusCodes.Status200OK)]
        public IActionResult Edit([FromBody]RestaurantRequest restaurant)
        {
            try
            {
                return Ok(_restaurantService.Update<RestaurantValidator>(restaurant));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove restaurante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            try
            {
                _restaurantService.Remove(id);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca todos os restaurantes
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<RestaurantResponse>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_restaurantService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca restaurante pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<RestaurantResponse>), StatusCodes.Status200OK)]
        public IActionResult GetById(long id)
        {
            try
            {
                return Ok(_restaurantService.GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}