using AutoMapper;
using Restaurante.Application.Controllers;
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
    public class DishControllerTest
    {
        private DishController _controller;
        private IDishService _service;
        private DishValidator _validator;
        private IMapper _mapper;

        public DishControllerTest()
        {
            SetAutoMapper();

            _service = new DishServiceTest(_mapper);
            _controller = new DishController(_service);
            _validator = new DishValidator();

        }

        internal void SetAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DishRequest, Domain.Entities.Dish>();
                cfg.CreateMap<Domain.Entities.Dish, DishResponse>();
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
            var items = Assert.IsType<List<DishResponse>>(okResult.Value);
            Assert.Equal(4, items.Count);
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
            Assert.IsType<DishResponse>(okResult.Value);
        }

        #endregion

        #region Métodos de Insert

        [Fact]
        public void Add_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var item = new DishRequest()
            {
                Description = "Bife a Bolonhesa",
                Price = 10.5,
                RestaurantId = 1,

            };

            // Act
            var okResult = _controller.Save(item) as ObjectResult;

            // Assert
            Assert.IsType<DishResponse>(okResult.Value);
        }

        #endregion
    }
}
