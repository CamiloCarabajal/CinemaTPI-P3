using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base (context)
        {
        }

        //ABM TICKET QUE HICIMOS PARA VER EL CAMINO

        //public Ticket CreateTicket(Ticket ticket) //Este no deberia ser de tipo abm
        //{
        //    _context.Add(ticket);
        //    return ticket;
        //}

        //public void UpdateTicket(Ticket ticket)
        //{
        //    _context.Update(ticket);
        //}
        //public void DeleteTicket(Ticket ticket) 
        //{
        //    _context.Remove(ticket);
        //}

        //Movie

        public ICollection<Movie> GetMovies() 
        {
            return _context.Movies.ToList();
        }
        public Movie? GetById(int id) 
        {
            return _context.Movies.FirstOrDefault(u => u.Id == id);
        }
    }
}
