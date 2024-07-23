using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

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
        public DbSet<SuperAdmin> SuperAdmins { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool isTestingEnvironment = false) : base(options)
        { 
            this.isTestingEnvironment = isTestingEnvironment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasDiscriminator<string>("UserType")
               .HasValue<Client>("Client")
               .HasValue<Admin>("Admin")
               .HasValue<SuperAdmin>("SuperAdmin");

            modelBuilder.Entity<Admin>().HasData(
               new Admin
               {
                   
                   Name = "Ivo",
                   Email = "ivobertoni@gmail.com",
                   Password = "123",
                   Id = 1,
                   UserType = "Admin"
               });

            modelBuilder.Entity<Client>().HasData(
               new Client
               {
                   Name = "Camilo",
                   Email = "camilocarabajal@gmail.com",
                   Password = "123",
                   Id = 2,
                   UserType = "Client"
               });

            modelBuilder.Entity<SuperAdmin>().HasData(
           new SuperAdmin
           {
               Name = "SuperAdmin",
               Email = "SuperAdmin@gmail.com",
               Password = "123",
               Id = 5,
               UserType = "SuperAdmin"
           });

            modelBuilder.Entity<Movie>().HasData(
              new Movie
              {
                  Title = "La zona de interés",
                  AuthorMovie = "Jonathan Glazer ",
                  Id = 1,
                  SeatCount = 5
                  //CreationUser = "Ivo",
                  //AdminId= 1

              });
            modelBuilder.Entity<Movie>().HasData(
         new Movie
         {
             Title = "Sociedad de la nieve",
             AuthorMovie = "Uruguayo ",
             Id = 2,
             SeatCount = 3
             //CreationUser = "Ivo",
             //AdminId= 1

         });
            modelBuilder.Entity<Ticket>().HasData(
            new Ticket
            {
                Id = 1,
                MovieId = 2,
                ClientId = 2,
                ClientName = "Camilo",
            });

            modelBuilder.Entity<Ticket>().HasData(
           new Ticket
           {
               Id = 2,
               MovieId = 2,
               ClientId = 4,
               ClientName = "Fatima",
           });
            // Relacion entre cliejte y ticket

            modelBuilder.Entity<Client>()
               .HasMany(c => c.Tickets)
               .WithOne(o => o.ClientBuyer)
               .HasForeignKey(o => o.ClientId)
               .OnDelete(DeleteBehavior.Cascade);// Esto hace que si eliminamos el cliente, se eliminan sus tickets tambien


            //Relacion entre ticket y movie
            
            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.Movie)
                .WithMany(c => c.Tickets)
                .HasForeignKey(o => o.MovieId);

           
            //modelBuilder.Entity<Movie>()
            //    .HasOne(p => p.Admin)
            //    .WithMany(u => u.Movies)
            //    .HasForeignKey(o => o.AdminId);
            
        }
    }
}
