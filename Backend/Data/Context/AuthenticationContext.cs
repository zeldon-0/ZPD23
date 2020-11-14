using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Context.Configurations;

namespace Data.Context
{
  public class AuthenticationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<RegistrationJournal> RegistrationJournal { get; set; }
        public DbSet<OperationJournal> OperationJournal { get; set; }
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public AuthenticationContext() : base()
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new UserQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new OperationJournalConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationJournalConfiguration());
        }
    }
}
