using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;

namespace Restaurante.Infra.Data.Mapping
{
    public class RestaurantMap : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("restaurant");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        }
    }
}
