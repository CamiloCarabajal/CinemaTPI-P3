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
        public ICollection<Ticket> Ticket { get; set; } = new List<Ticket>(); //Preguntar por que solo 1 ticket?
        public Admin Admin { get; set; }
        public string CreationUser { get; set; } // Guardamos el nom del adm "en el constructor" . Esto deja en claro quien entro ultimo e hizo la modificacion de movie (Todavia no sabemos si queremos esto)
    }
}
