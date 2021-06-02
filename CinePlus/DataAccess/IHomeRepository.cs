using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public interface IHomeRepository
    {
        public List<MovieOnTop10> GetMovieOnTop10s();
    }
}
