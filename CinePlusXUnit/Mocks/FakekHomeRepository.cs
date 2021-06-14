using System;
using System.Collections.Generic;
using System.Text;
using CinePlus.DataAccess;
using CinePlus.Models;

namespace CinePlusXUnit.Mocks
{
    class FakekHomeRepository : IHomeRepository
    {
        public List<MovieOnTop10> GetMovieOnTop10s()
        {
            return new List<MovieOnTop10>();
        }
    }
}
