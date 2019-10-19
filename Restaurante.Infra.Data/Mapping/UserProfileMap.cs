using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Entities;

namespace Restaurante.Infra.Data.Mapping
{
    public class UserProfileMap : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("user_profile");

            builder.HasKey(u => new { u.UserId, u.ProfileId });
            builder.Property(u => u.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(u => u.ProfileId).HasColumnName("profile_id").IsRequired();

            builder.HasOne(u => u.User).WithMany(u => u.UserProfiles).HasForeignKey(bc => bc.UserId);
            builder.HasOne(u => u.Profile).WithMany(u => u.UserProfiles).HasForeignKey(bc => bc.ProfileId);

            builder.Ignore(u => u.Id);
        }
    }
}
