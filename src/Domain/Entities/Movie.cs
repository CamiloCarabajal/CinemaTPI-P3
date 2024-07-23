using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorMovie { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public int SeatCount { get; set; } = 5; //Cantidad de asientos.
    }
}
