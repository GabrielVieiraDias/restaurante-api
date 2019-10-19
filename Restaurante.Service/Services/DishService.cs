using System.Collections.Generic;
using AutoMapper;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Interfaces.UnitOfWork;
using Restaurante.Domain.Request;

namespace Restaurante.Service.Services
{
    public class DishService : BaseService<DishRequest, DishResponse, Dish>, IDishService
    {
        private readonly IDishRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DishService(IDishRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<DishResponse> GetAllByRestaurantId(long restauranteId)
        {
            var dishes = _repository.GetFiltered(d => d.RestaurantId == restauranteId,
                r => r.Restaurant);

            return _mapper.Map<List<DishResponse>>(dishes);
        }

        public IEnumerable<DishResponse> GetAllIncluding()
        {
            var dishes = _repository.GetAllIncluding(r => r.Restaurant);

            return _mapper.Map<List<DishResponse>>(dishes);
        }
    }
}
