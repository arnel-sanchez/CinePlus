using CinePlus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public class BilboardDataAccess : IBilboardRepository
    {
        private CinePlusDBContext _context;

        public BilboardDataAccess(CinePlusDBContext context)
        {
            _context = context;
        }

        public List<MovieType> GetMovieTypes()
        {
            return _context.MovieType.ToList();
        }

        public void AddMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
        }

        public bool ExistMovieById(string id)
        {
            return _context.Movie.Select(x => x.MovieId == id).FirstOrDefault();
        }

        public List<DiscountsByShow> GetShowByDate(DateTime date)
        {
            return _context.DiscountsByShow
                .Include(x=>x.Show)
                .Include(x=>x.Discount)
                .Include(x=>x.Show.Movie)
                .Include(x=>x.Show.Room)
                .Where(x=>x.Show.DateTime.Date == date.Date).ToList();
        }
    }
}
