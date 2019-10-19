using Restaurante.Domain.Entities;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Domain.Interfaces.Services
{
    public interface IRestaurantService : IService<RestaurantRequest, RestaurantResponse, Restaurant>
    {
    }
}
