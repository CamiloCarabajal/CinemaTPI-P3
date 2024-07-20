using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class MovieAddRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorMovie { get; set; }
        //public string Description { get; set; } Por el momento no. Pensar que mas tambien.
    }
}
