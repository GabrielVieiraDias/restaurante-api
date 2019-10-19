using AutoMapper;
using Restaurante.Domain.Request;
using Restaurante.Domain.Response;

namespace Restaurante.Service.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserRequest, Domain.Entities.User>();
            CreateMap<Domain.Entities.User, UserResponse>();

            CreateMap<ProfileRequest, Domain.Entities.Profile>();
            CreateMap<Domain.Entities.Profile, ProfileResponse>();

            CreateMap<UserProfileRequest, Domain.Entities.UserProfile>();
            CreateMap<Domain.Entities.UserProfile, UserProfileResponse>();

            CreateMap<RestaurantRequest, Domain.Entities.Restaurant>();
            CreateMap<Domain.Entities.Restaurant, RestaurantResponse>();

            CreateMap<DishRequest, Domain.Entities.Dish>();
            CreateMap<Domain.Entities.Dish, DishResponse>();
        }
    }
}

public class Source<T>
{
    public T Value { get; set; }
}

public class Destination<T>
{
    public T Value { get; set; }
}
