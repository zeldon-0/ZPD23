using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context.Configurations
{
    public class RegistrationJournalConfiguration : IEntityTypeConfiguration<RegistrationJournal>
    {
        public void Configure(EntityTypeBuilder<RegistrationJournal> builder)
        {
            builder.HasKey(j => j.Id);
            builder.HasOne(j => j.User)
                .WithMany(u => u.RegistrationEntries)
                .HasForeignKey(j => j.UserId);
        }
    }
}
