using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        // public ICollection<Movie> Movies { get; set; } = new List<Movie>(); 
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
