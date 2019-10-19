using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Infra.Data.Context;

namespace Restaurante.Infra.Data.Repository
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        public DishRepository(ContextDb context)
            : base(context)
        {
        }
    }
}
