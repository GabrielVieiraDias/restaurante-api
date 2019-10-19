using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Domain.Interfaces.Services;
using Restaurante.Domain.Interfaces.UnitOfWork;
using Restaurante.Infra.Data.Context;
using Restaurante.Infra.Data.Repository;
using Restaurante.Infra.Data.UnitOfWork;
using Restaurante.Service.Services;

namespace Restaurante.Infra.CrossCutting.IoC
{
    public class DependencyInjection
    {
        private readonly IServiceCollection _service;

        public DependencyInjection(IServiceCollection service)
        {
            _service = service;
        }

        public void RegisterServices()
        {
            // Banco de Dados
            _service.AddEntityFrameworkNpgsql().AddDbContext<ContextDb>();
            _service.AddScoped<IUnitOfWork, UnitOfWork>();

            // Usuário Logado
            _service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Services
            _service.AddScoped<ILoginService, LoginService>();
            _service.AddScoped<IUserService, UserService>();
            _service.AddScoped<IProfileService, ProfileService>();
            _service.AddScoped<IUserProfileService, UserProfileService>();
            _service.AddScoped<IRestaurantService, RestaurantService>();
            _service.AddScoped<IDishService, DishService>();

            // Repositories
            _service.AddScoped<IUserRepository, UserRepository>();
            _service.AddScoped<IProfileRepository, ProfileRepository>();
            _service.AddScoped<IUserProfileRepository, UserProfileRepository>();
            _service.AddScoped<IRestaurantRepository, RestaurantRepository>();
            _service.AddScoped<IDishRepository, DishRepository>();
        }
    }
}
