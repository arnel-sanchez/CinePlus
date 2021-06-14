using System;
using System.Collections.Generic;
using System.Text;
using CinePlus.DataAccess;
using CinePlus.Models;

namespace CinePlusXUnit.Mocks
{
    class FakeBilboardRepository : IBilboardRepository
    {
        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<MovieOnTop10> GetMoviesOnTop10()
        {
            throw new NotImplementedException();
        }

        public List<MovieType> GetMovieTypes()
        {
            throw new NotImplementedException();
        }

        public bool ExistMovieById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Show> GetShowByDate(DateTime date)
        {
            return new List<Show>();
        }

        public List<Show> GetShowByMovieName(string name)
        {
            return new List<Show>();
        }

        public Movie GetMovieById(string id)
        {
            return id == "0" ? null : new Movie();
        }

        public List<DiscountsByShow> GetDiscounts(string name)
        {
            return new List<DiscountsByShow>();
        }

        public List<DiscountsByShow> GetDiscounts(DateTime date)
        {
            return new List<DiscountsByShow>();
        }
    }
}
