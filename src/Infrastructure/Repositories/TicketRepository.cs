using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TicketRepository : EfRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Ticket> GetTicketByClientId(int clientId) 
        {
            return _context.Tickets
                .Include(u=>u.Movie)
                .Include(p=>p.ClientBuyer)
                .Where(t => t.ClientId == clientId)
                .ToList();
        }
        public Client? GetClient(int clientId) 
        {
            return _context.Clients.FirstOrDefault(p => p.Id == clientId);
        }

        public Movie? GetMovie(int movieId) 
        {
            return _context.Movies.FirstOrDefault(p => p.Id == movieId);
        }

        public void LoadRelatedEntities(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            }

            _context.Entry(ticket).Reference(t => t.Movie).Load();
            _context.Entry(ticket).Reference(t => t.ClientBuyer).Load();
        }
    }
}
