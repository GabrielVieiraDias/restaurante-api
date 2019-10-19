using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Interfaces.UnitOfWork;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;
using Restaurante.Infra.Resources;
using Restaurante.Service.Common;
using Restaurante.Service.Exceptions;

namespace Restaurante.Service.Services
{
    public class LoginService : BaseService<LoginRequest, LoginResponse, User>, ILoginService
    {

        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;

        public LoginService(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IHttpContextAccessor accessor)
            : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _accessor = accessor;
        }

        public string UserLogged => _accessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public LoginResponse Authenticate(LoginRequest login)
        {
            try
            {
                var user = _repository.GetByPropertyIncluding(u => u.Email == login.Email);

                if (user == null)
                    throw new AppException(MessagesAPI.USER_NOT_FOUND);

                login.Password = Util.GetSha256Hash(new SHA256CryptoServiceProvider(), login.Password);

                if (_repository.GetByPropertyIncluding(u => u.Email == login.Email && u.PasswordHash == login.Password) == null)
                    throw new AppException(MessagesAPI.USER_OR_PASSWORD_INVALID);

                long expireMinutes = long.Parse(_configuration["Jwt:Minutes"]);
                string issuer = _configuration["Jwt:Issuer"];
                string secretKey = _configuration["Jwt:SecretKey"];

                return JWT.BuildToken(login.Email, expireMinutes, issuer, secretKey, user.FirstName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
