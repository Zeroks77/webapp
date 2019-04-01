using System;
using System.Collections.Generic;
using System.Text;
using firstwebapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace firstwebapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Votes>()
                    .HasIndex(d => new { d.QuestionId, d.UserId })
                    .HasName("Unique_VoteIndex")
                    .IsUnique();
            base.OnModelCreating(builder);
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Votes> Votes { get; set; }

    }
}
