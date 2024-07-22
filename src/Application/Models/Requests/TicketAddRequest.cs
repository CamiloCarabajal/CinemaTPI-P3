using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class TicketAddRequest
    {
        public int ClientId { get; set; }
        public int MovieId { get; set; }
    }
}
