using AutoMapper;
using System;
using System.Security.Cryptography;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Interfaces.UnitOfWork;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;
using Restaurante.Infra.Resources;
using Restaurante.Service.Common;
using Restaurante.Service.Exceptions;
using Restaurante.Service.Validators;

namespace Restaurante.Service.Services
{
    public class RestaurantService : BaseService<RestaurantRequest, RestaurantResponse, Restaurant>, IRestaurantService
    {
        private readonly IRestaurantRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

    }
}
