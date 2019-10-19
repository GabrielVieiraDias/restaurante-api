using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Infra.Data.Context;

namespace Restaurante.Infra.Data.Repository
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ContextDb context)
            : base(context)
        {
        }
    }
}
