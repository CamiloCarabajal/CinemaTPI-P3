using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public ICollection<Movie> Movies { get; set; } // Lista de Movies para Client
        public Movie MovieSelected { get; set; } // Relacion con Movie
        public string ClientName { get; set; }
        public Client ClientBuyer { get; set; } //Relacion con Client

    }
}
