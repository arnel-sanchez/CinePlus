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

        public List<MovieOnTop10> GetMoviesOnTop10()
        {
            return _context.MovieOnTop10
                .Include(x => x.Movie)
                .Include(x => x.Top10)
                .OrderBy(x => x.Top10Id)
                .ToList();
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
            try
            {
                return _context.DiscountsByShow
                    .Include(x => x.Show)
                    .Include(x => x.Discount)
                    .Include(x => x.Show.Movie)
                    .Include(x => x.Show.Room)
                    .Where(x => x.Show.DateTime.Year == date.Date.Year && x.Show.DateTime.Month == date.Month && x.Show.DateTime.Day == date.Day)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<DiscountsByShow>();
            }
        }

        public Movie GetMovieById(string id)
        {
            return _context.Movie
                .Include(x => x.MovieType)
                .Where(x => x.MovieId == id)
                .FirstOrDefault();
        }

        public List<DiscountsByShow> GetShowByMovieName(string name)
        {
            try
            {
                return _context.DiscountsByShow
                    .Include(x => x.Show)
                    .Include(x => x.Discount)
                    .Include(x => x.Show.Movie)
                    .Include(x => x.Show.Room)
                    .Where(x=>x.Show.Movie.Name.Contains(name) || x.Show.Movie.Name==name)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<DiscountsByShow>();
            }
        }
    }
}
