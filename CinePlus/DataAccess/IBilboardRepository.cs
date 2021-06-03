using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public interface IBilboardRepository
    {
        public void AddMovie(Movie movie);

        public List<MovieOnTop10> GetMoviesOnTop10();

        public List<MovieType> GetMovieTypes();

        public bool ExistMovieById(string id);

        public List<Show> GetShowByDate(DateTime date);

        public List<Show> GetShowByMovieName(string name);

        public Movie GetMovieById(string id);

        public List<DiscountsByShow> GetDiscounts(string name);

        public List<DiscountsByShow> GetDiscounts(DateTime date);
    }
}
