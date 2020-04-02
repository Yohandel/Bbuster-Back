using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiRestTest.Models
{
    public class BBusterContext : DbContext
    {
        public BBusterContext(DbContextOptions<BBusterContext> options) : base(options) { }

        public DbSet<Director> BusterDirectors { get; set; }
        public DbSet<Movie> BusterMovies { get; set; }
        public DbSet<User> BusterUsers { get; set; }
        public DbSet<Invoice> BusterInvoice { get; set; }
        public DbSet<Category> BusterCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
            .Property(m => m.deleted)
            .HasDefaultValue(false);

            builder.Entity<Category>()
            .Property(c => c.deleted)
            .HasDefaultValue(false);

            builder.Entity<Director>()
            .Property(d => d.deleted)
            .HasDefaultValue(false);

            builder.Entity<Invoice>()
            .Property(i => i.Created_At)
            .HasDefaultValueSql("getdate()");

            builder.Entity<Invoice>()
            .Property(i => i.deleted)
            .HasDefaultValue(false);

            builder.Entity<User>()
            .Property(u => u.deleted)
            .HasDefaultValue(false);

        }
    }

}