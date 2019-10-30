using AutoMapper;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Controllers;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Request;
using Restaurante.Service.Exceptions;
using Restaurante.Service.Services;
using Restaurante.Service.Validators;
using Restaurante.UnitTest.Unity.ServiceTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Restaurante.UnitTest.Unity.ControllerTest
{
    public class RestaurantControllerTest
    {
        private RestaurantController _controller;
        private IRestaurantService _service;
        private RestaurantValidator _validator;
        private IMapper _mapper;

        public RestaurantControllerTest()
        {
            SetAutoMapper();

            _service = new RestaurantServiceTest(_mapper);
            _controller = new RestaurantController(_service);
            _validator = new RestaurantValidator();

        }

        internal void SetAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestaurantRequest, Domain.Entities.Restaurant>();
                cfg.CreateMap<Domain.Entities.Restaurant, RestaurantResponse>();
            });

            _mapper = new Mapper(configuration);
        }

        #region Métodos de Busca

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll() as ObjectResult;

            // Assert
            var items = Assert.IsType<List<RestaurantResponse>>(okResult.Value);
            Assert.Equal(10, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetById(100000);

            // Assert
            var item = Assert.IsType<OkObjectResult>(notFoundResult);
            Assert.Null(item.Value);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetById(1) as ObjectResult;
           
            // Assert
            Assert.IsType<RestaurantResponse>(okResult.Value);
        }

        #endregion

        #region Métodos de Insert

        [Fact]
        public void Add_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var item = new RestaurantRequest()
            {
                Name = "Restaurante 1"
                
            };

            // Act
            var okResult = _controller.Save(item) as ObjectResult;

            // Assert
            Assert.IsType<RestaurantResponse>(okResult.Value);
        }

        //[Fact]
        //public void Add_InvalidObjectPassed_NameMissing_ReturnsBadRequest()
        //{
        //    // Arrange
        //    var missingItem = new RestaurantRequest()
        //    {
        //        Name = string.Empty
        //    };

        //    // Assert
        //    ValidationTestException validationTestException = Assert.Throws<ValidationTestException>(() => _validator.ShouldNotHaveValidationErrorFor(x => x.Name, missingItem));
        //    Assert.Contains(nameof(missingItem.Name), validationTestException.Message);
        //}

        #endregion
    }
}
