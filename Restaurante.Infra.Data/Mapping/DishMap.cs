using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;

namespace Restaurante.Infra.Data.Mapping
{
    public class DishMap : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("dish");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Price).HasColumnName("price").IsRequired();
            builder.Property(u => u.RestaurantId).HasColumnName("restaurant_id").IsRequired();

            builder.HasOne(e => e.Restaurant).WithMany(c => c.Dishes);
        }
    }
}
