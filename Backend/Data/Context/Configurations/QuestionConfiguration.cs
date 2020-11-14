using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Value)
                .HasMaxLength(60)
                .IsRequired();
            builder.HasIndex(u => u.Value)
                .IsUnique();
        }
    }
}
