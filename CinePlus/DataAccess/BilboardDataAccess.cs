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

        public List<Show> GetShowByDate(DateTime date)
        {
            try
            {
                return _context.Show
                    .Include(x => x.Movie)
                    .Include(x => x.Room)
                    .Where(x => x.DateTime.Year == date.Date.Year && x.DateTime.Month == date.Month && x.DateTime.Day == date.Day)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<Show>();
            }
        }

        public Movie GetMovieById(string id)
        {
            return _context.Movie
                .Include(x => x.MovieType)
                .Where(x => x.MovieId == id)
                .FirstOrDefault();
        }

        public List<Show> GetShowByMovieName(string name)
        {
            try
            {
                return _context.Show
                    .Include(x => x.Movie)
                    .Include(x => x.Room)
                    .Where(x=>x.Movie.Name.Contains(name) || x.Movie.Name==name)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<Show>();
            }
        }

        public List<DiscountsByShow> GetDiscounts(string name)
        {
            try
            {
                return _context.DiscountsByShow
                    .Include(x => x.Discount)
                    .Where(x => x.Show.Movie.Name.Contains(name) || x.Show.Movie.Name == name)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<DiscountsByShow>();
            }
        }

        public List<DiscountsByShow> GetDiscounts(DateTime date)
        {
            try
            {
                return _context.DiscountsByShow
                    .Include(x=>x.Discount)
                    .Where(x => x.Show.DateTime.Year == date.Date.Year && x.Show.DateTime.Month == date.Month && x.Show.DateTime.Day == date.Day)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<DiscountsByShow>();
            }
        }
    }
}
