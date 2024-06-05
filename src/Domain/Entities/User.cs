using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }//public string UserType { get; set; } // No hace falta, en el context al crearlo se nos hace una columna que discrimina el tipo de usuario, ya que los herederos de la misma tienen diferente nombre.
    }
}
