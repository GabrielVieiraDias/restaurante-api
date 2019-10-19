using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;

namespace Restaurante.Infra.Data.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("profile");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(255).IsRequired();
        }
    }
}
