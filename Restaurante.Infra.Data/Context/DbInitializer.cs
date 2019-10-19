using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurante.Domain.Entities;

namespace Restaurante.Infra.Data.Context
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ContextDb>();
            context.Database.Migrate();

            if (!context.Profile.Any())
            {
                var profiles = new List<Profile>()
                {
                    new Profile() { Id = 1, Description = "Administrador" },
                    new Profile() { Id = 2, Description = "Usuário" },
                };

                context.AddRange(profiles);
                context.SaveChanges();
            }

            if (!context.User.Any())
            {
                var users = new List<User>()
                {
                    new User() { Id = 1, FirstName = "Admin", LastName = "usuário 1", Email = "user@restaurante.com", PasswordHash = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5" },
                    new User() { Id = 2, FirstName = "Usuário", LastName = "usuário 2", Email = "user2@restaurante.com", PasswordHash = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5" }
                };

                context.AddRange(users);
                context.SaveChanges();
            }

            if (!context.UserProfile.Any())
            {
                var userProfiles = new List<UserProfile>()
                {
                    new UserProfile() { UserId = 1, ProfileId = 1 },
                    new UserProfile() { UserId = 1, ProfileId = 2 },
                    new UserProfile() { UserId = 2, ProfileId = 2 }
                };

                context.AddRange(userProfiles);
                context.SaveChanges();
            }
        }
    }
}
