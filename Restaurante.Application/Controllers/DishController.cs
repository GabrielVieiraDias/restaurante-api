using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Controllers;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Request;
using Restaurante.Service.Validators;
using System;
using System.Collections.Generic;

namespace Dishe.Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class DishController : APIController
    {
        private readonly IDishService _dishService;
        
        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
        
        /// <summary>
        /// Salva um novo prato
        /// </summary>
        /// <param name="dish"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status200OK)]
        public IActionResult Save([FromBody]DishRequest dish)
        {
            try
            {
                return Ok(_dishService.Insert<DishValidator>(dish));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Edita um prato
        /// </summary>
        /// <param name="dish"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status200OK)]
        public IActionResult Edit([FromBody]DishRequest dish)
        {
            try
            {
                return Ok(_dishService.Update<DishValidator>(dish));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove prato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            try
            {
                _dishService.Remove(id);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca todos os pratos do restaurante
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [HttpGet("restaurante/{restaurantId}")]
        [ProducesResponseType(typeof(List<DishResponse>), StatusCodes.Status200OK)]
        public IActionResult GetAllByRestaurant(long restaurantId)
        {
            try
            {
                return Ok(_dishService.GetAllByRestaurantId(restaurantId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca todos os pratos
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<DishResponse>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dishService.GetAllIncluding());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca prato pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<DishResponse>), StatusCodes.Status200OK)]
        public IActionResult GetById(long id)
        {
            try
            {
                return Ok(_dishService.GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}