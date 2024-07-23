using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITicketService
    {
        List<TicketDto> GetTicketByClientId(int clientId);
        List<Ticket> GetAll();
        TicketDto CreateTicket(TicketAddRequest request);
        void DeleteTicket(int id);
        int GetAvailableSeats(int movieId);
    }
}
