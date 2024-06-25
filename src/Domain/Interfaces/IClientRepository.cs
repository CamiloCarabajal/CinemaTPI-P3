using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        //Ticket CreateTicket(Ticket ticket);
        //void UpdateTicket(Ticket ticket);
        //void DeleteTicket(Ticket ticket);
        ICollection<Movie> GetMovies();
        Movie? GetById(int id);
    }
}
