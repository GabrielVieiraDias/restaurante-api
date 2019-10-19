using AutoMapper;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Interfaces.UnitOfWork;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Service.Services
{
    public class UserProfileService : BaseService<UserProfileRequest, UserProfileResponse, UserProfile>, IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileService(IUserProfileRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
    }
}
