using AutoMapper;
using FluentValidation;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.UnitTest.Unity.ServiceTest
{
    public class DishServiceTest : IDishService
    {

        private readonly List<Dish> _dishs;
        private readonly IMapper _mapper;

        public DishServiceTest(IMapper mapper)
        {
            _mapper = mapper;
            _dishs = new List<Dish>()
            {
                new Dish() { Id = 1, Description = "Batata Frita", Price = 10.5, RestaurantId = 1 },
                new Dish() { Id = 2, Description = "Parmegiana de Frango", Price = 15.9, RestaurantId = 1 },
                new Dish() { Id = 3, Description = "Macarrão", Price = 19.9, RestaurantId = 3 },
                new Dish() { Id = 4, Description = "Bife", Price = 11.9, RestaurantId = 4 }
            };
        }

        public IEnumerable<DishResponse> GetAll()
        {
            return _mapper.Map<List<DishResponse>>(_dishs);
        }

        public IEnumerable<DishResponse> GetAllByRestaurantId(long restauranteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DishResponse> GetAllIncluding()
        {
            return _mapper.Map<List<DishResponse>>(_dishs);
        }

        public DishResponse GetById(long id)
        {
            var dish = _dishs.Where(r => r.Id == id).FirstOrDefault();

            return _mapper.Map<DishResponse>(dish);
        }

        public DishResponse Insert<V>(DishRequest entity) where V : AbstractValidator<DishRequest>
        {

            var dish = _mapper.Map<Dish>(entity);
            _dishs.Add(dish);
            return _mapper.Map<DishResponse>(dish);
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public DishResponse Update<V>(DishRequest entity) where V : AbstractValidator<DishRequest>
        {
            throw new NotImplementedException();
        }
    }
}
