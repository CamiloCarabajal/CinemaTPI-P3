using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        List<Ticket> GetTicketByClientId(int clientId);
        Client? GetClient(int clientId);
        Movie? GetMovie(int movieId);
        void LoadRelatedEntities(Ticket ticket);

       
    }
}
