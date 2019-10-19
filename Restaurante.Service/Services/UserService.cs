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
    public class UserService : BaseService<UserRequest, UserResponse, User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserResponse SaveUser(UserRequest user)
        {
            Validate(user, Activator.CreateInstance<UserValidator>());
            User userSave = null;

            try
            {
                #region Validações
                var userEntity = _repository.GetByPropertyIncluding(u => u.Email == user.Email);
                if (userEntity != null)
                    throw new AppException(MessagesAPI.USER_ALREADY_EXISTS); 
                #endregion

                userSave = _mapper.Map<User>(user);

                #region Criptografia de Senha
                userSave.PasswordHash = Util.GetSha256Hash(new SHA256CryptoServiceProvider(), user.PasswordHash);
                #endregion
                
                _unitOfWork.Begin();
                _repository.Insert(userSave);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }

            return _mapper.Map<UserResponse>(userSave);
        }
    }
}
