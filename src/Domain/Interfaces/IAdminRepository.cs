using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        //La firma deberia ser de tipo client
        Movie GetByName(string name);
       // Movie AddMovie(Movie movie);
       //void DeleteMovie(Movie movie);
       // void UpdateMovie(Movie movie);
    }
}
