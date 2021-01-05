using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickList.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // 8* Add the following method to your ApplicationDbContext class:
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Shopper",
                NormalizedName = "SHOPPER"
            }
            );
        }
        // 12* add a DbSet of that class in your AppDbContext and create the table for each model
        public DbSet<QuickList.Models.Shopper> Shopper { get; set; }
    }
}
