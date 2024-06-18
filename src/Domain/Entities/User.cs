using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }//public string UserType { get; set; } // No hace falta, en el context al crearlo se nos hace una columna que discrimina el tipo de usuario, ya que los herederos de la misma tienen diferente nombre.
        [Column(TypeName = "nvarchar(20)")]
        public string UserType { get; set; }
    }
}
