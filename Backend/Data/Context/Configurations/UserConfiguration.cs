using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasIndex(u => u.UserName)
                .IsUnique();
            builder.Property(u => u.Password)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
