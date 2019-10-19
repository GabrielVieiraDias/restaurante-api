using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;
using System.Collections.Generic;

namespace Restaurante.Domain.Interfaces.Services
{
    public interface IDishService : IService<DishRequest, DishResponse, Dish>
    {
        IEnumerable<DishResponse> GetAllByRestaurantId(long restauranteId);
        IEnumerable<DishResponse> GetAllIncluding();
    }
}
