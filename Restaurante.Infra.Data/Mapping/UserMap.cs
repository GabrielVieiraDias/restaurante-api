using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;

namespace Restaurante.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.FirstName).HasColumnName("first_name").HasMaxLength(100).IsRequired();
            builder.Property(c => c.LastName).HasColumnName("last_name").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
            builder.Property(c => c.PasswordHash).HasColumnName("password_hash").HasMaxLength(100).IsRequired();
            builder.Property(c => c.DateRegister).HasColumnName("date_register").HasDefaultValueSql("current_timestamp").IsRequired();
            builder.Property(c => c.DateUpdate).HasColumnName("date_update").HasDefaultValueSql("current_timestamp").IsRequired();

        }
    }
}
