using CinePlus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public class HomeDataAccess : IHomeRepository
    {
        private CinePlusDBContext _context;

        public HomeDataAccess(CinePlusDBContext context)
        {
            _context = context;
        }

        public List<MovieOnTop10> GetMovieOnTop10s()
        {
            try
            {
                return _context.MovieOnTop10
                .Include(x => x.Movie)
                .Include(x => x.Top10)
                .ToList();
            }
            catch (Exception)
            {
                return new List<MovieOnTop10>();
            }
        }
    }
}
