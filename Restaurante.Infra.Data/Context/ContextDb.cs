using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Infra.Data.Mapping;

namespace Restaurante.Infra.Data.Context
{
    public class ContextDb : DbContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }


        private bool _rollBack;
        private IDbContextTransaction Transaction { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options, IConfiguration configuration) :
            base(options)
        {
            _configuration = configuration;
        }

        #region Métodos de Transação

        public IDbContextTransaction Begin() => Transaction ?? (Transaction = this.Database.BeginTransaction());

        public void Commit()
        {
            if (Transaction != null && !_rollBack)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void RollBack()
        {
            if (Transaction != null && !_rollBack)
            {
                Transaction.Rollback();
                _rollBack = true;
            }
        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Restaurante_DB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Profile>(new ProfileMap().Configure);
            modelBuilder.Entity<UserProfile>(new UserProfileMap().Configure);
            modelBuilder.Entity<Restaurant>(new RestaurantMap().Configure);
            modelBuilder.Entity<Dish>(new DishMap().Configure);
        }
    }
}
