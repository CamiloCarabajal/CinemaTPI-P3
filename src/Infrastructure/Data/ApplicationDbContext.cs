using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly bool isTestingEnvironment;
       public DbSet<User> Users { get; set; }
       public DbSet<Client> Clients { get; set; }
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Ticket> Tickets { get; set; }
       public DbSet<Admin> Admins { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool isTestingEnvironment = false) : base(options)
        { 
            this.isTestingEnvironment = isTestingEnvironment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>()
                .HasMany(p => p.Ticket)
                .WithOne(b=> b.MovieSelected);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>()
                .HasMany(p => p.Movies);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
                .HasMany(p => p.Ticket)
                .WithOne(b => b.ClientBuyer);

            
        }
    }
}
