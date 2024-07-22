using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
    }
}
