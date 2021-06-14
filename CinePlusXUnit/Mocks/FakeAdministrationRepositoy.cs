using System;
using System.Collections.Generic;
using System.Text;
using CinePlus.DataAccess;
using CinePlus.Models;
using CinePlus.Services;
using Microsoft.AspNetCore.Http;
using Moq;
namespace CinePlusXUnit.Mocks
{
    public class FakeAdministrationRepositoy:IAdministrationRepository
    {
        public List<MovieOnTop10> GetTop10(string top10Id)
        {
            return new List<MovieOnTop10>();
        }

        public List<MovieOnTop10> GetTop10()
        {
            return new List<MovieOnTop10>();
        }

        public List<Top10> GetTop10List()
        {
            return new List<Top10>();
        }

        public Top10 GetTop()
        {
            return new Top10();
        }

        public Top10 GetTop(string top10id)
        {
            return new Top10();
        }

        public void DeleteMovieOnTop10ById(string id)
        {
            
        }

        public List<Movie> GetMoviesNotAssigned()
        {
            return new List<Movie>();
        }

        public List<Movie> GetMoviesNotAssigned(string id)
        {
            return new List<Movie>();
        }

        public void AddMovieOnTop10(MovieOnTop10 movieOnTop10)
        {
           
        }

        public void AddTop10(Top10 top10)
        {
            
        }

        public List<Movie> GetMovies()
        {
            return new List<Movie>();
        }

        public List<Movie> GetMoviesByName(string name)
        {
            return new List<Movie>();
        }

        public List<MovieType> GetMovieTypes()
        {
            return new List<MovieType>();
        }

        public void AddMovie(Movie movie)
        {
           
        }

        public void DeleteMovie(string id)
        {
           
        }

        public List<Show> GetShowsByDate(DateTime date)
        {
            return new List<Show>();
        }

        public List<Room> GetRooms()
        {
            return new List<Room>();
        }

        public void AddShow(Show show)
        {
           
        }

        public void DeleteShowById(string id)
        {
            
        }

        public List<ArmChairByRoom> GetArmChairByRoom()
        {
            return new List<ArmChairByRoom>();
        }

        public List<ArmChairByRoom> GetArmChairByRoom(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoomById(string id)
        {
            
        }

        public void MarkArmChairById(string id, StateArmChair state)
        {
           
        }

        public void AddRoom(Room room)
        {
            
        }

        public void AddArmChair(ArmChair armChair)
        {
            
        }

        public void AddArmChairByRoom(ArmChairByRoom armChairByRoom)
        {
           
        }

        public int StadisticsByDirector(string name)
        {
            return 1;
        }

        public int StadisticsByMovie(string id)
        {
            return 2;
        }

        public int StadisticsByMovieType(string id)
        {
            return 4;
        }

        public int StadisticsByDate(DateTime date)
        {
            return 5;
        }

        public int StadisticsByDateRange(DateTime dateInitial, DateTime dateFinal)
        {
            return 8;
        }
    }
}
