using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context.Configurations
{
    public class OperationJournalConfiguration : IEntityTypeConfiguration<OperationJournal>
    {
        public void Configure(EntityTypeBuilder<OperationJournal> builder)
        {
            builder.HasKey(j => j.Id);
            builder.HasOne(j => j.User)
                .WithMany(u => u.OperationEntries)
                .HasForeignKey(j => j.UserId);
        }
    }
}
