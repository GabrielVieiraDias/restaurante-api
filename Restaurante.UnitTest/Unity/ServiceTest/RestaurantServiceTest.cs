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
    public class RestaurantServiceTest : IRestaurantService
    {

        private readonly List<Restaurant> _restaurants;
        private readonly IMapper _mapper;

        public RestaurantServiceTest(IMapper mapper)
        {
            _mapper = mapper;
            _restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Restaurante 1" },
                new Restaurant() { Id = 2, Name = "Restaurante 2" },
                new Restaurant() { Id = 3, Name = "Restaurante 3" },
                new Restaurant() { Id = 4, Name = "Restaurante 4" },
                new Restaurant() { Id = 5, Name = "Restaurante 5" },
                new Restaurant() { Id = 6, Name = "Restaurante 6" },
                new Restaurant() { Id = 7, Name = "Restaurante 7" },
                new Restaurant() { Id = 8, Name = "Restaurante 8" },
                new Restaurant() { Id = 9, Name = "Restaurante 9" },
                new Restaurant() { Id = 10, Name = "Restaurante 10" },
            };
        }

        public IEnumerable<RestaurantResponse> GetAll()
        {
            return _mapper.Map<List<RestaurantResponse>>(_restaurants);
        }

        public RestaurantResponse GetById(long id)
        {
            var restaurant = _restaurants.Where(r => r.Id == id).FirstOrDefault();

            return _mapper.Map<RestaurantResponse>(restaurant);
        }

        public RestaurantResponse Insert<V>(RestaurantRequest entity) where V : AbstractValidator<RestaurantRequest>
        {

            var restaurant = _mapper.Map<Restaurant>(entity);
            _restaurants.Add(restaurant);
            return _mapper.Map<RestaurantResponse>(restaurant);
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public RestaurantResponse Update<V>(RestaurantRequest entity) where V : AbstractValidator<RestaurantRequest>
        {
            throw new NotImplementedException();
        }
    }
}
