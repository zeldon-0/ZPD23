using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context.Configurations
{
    public class UserQuestionConfiguration : IEntityTypeConfiguration<UserQuestion>
    {
        public void Configure(EntityTypeBuilder<UserQuestion> builder)
        {
            builder.HasKey(uq => new {uq.UserId, uq.QuestionId});
            builder.Property(uq => uq.Answer)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasOne(uq => uq.Question)
                .WithMany(q => q.UserQuestions)
                .HasForeignKey(uq => uq.QuestionId);
            builder.HasOne(uq => uq.User)
                .WithMany(u => u.UserQuestions)
                .HasForeignKey(uq => uq.UserId);
        }
    }
}
