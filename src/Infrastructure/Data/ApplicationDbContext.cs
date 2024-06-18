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
        DbSet<User> Users { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Admin> Admins { get; set; }

        private readonly bool isTestingEnvironment;

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
