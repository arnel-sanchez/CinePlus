using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public interface IAdministrationRepository
    {
        public List<MovieOnTop10> GetTop10(string top10Id);

        public List<MovieOnTop10> GetTop10();

        public List<Top10> GetTop10List();

        public Top10 GetTop();

        public Top10 GetTop(string top10id);

        public void DeleteMovieOnTop10ById(string id);

        public List<Movie> GetMoviesNotAssigned();

        public List<Movie> GetMoviesNotAssigned(string id);

        public void AddMovieOnTop10(MovieOnTop10 movieOnTop10);

        public void AddTop10(Top10 top10);

        public List<Movie> GetMovies();

        public List<Movie> GetMoviesByName(string name);

        public List<MovieType> GetMovieTypes();

        public void AddMovie(Movie movie);

        public void DeleteMovie(string id);

        public List<Show> GetShowsByDate(DateTime date);

        public List<Room> GetRooms();

        public void AddShow(Show show);

        public void DeleteShowById(string id);

        public List<ArmChairByRoom> GetArmChairByRoom();

        public List<ArmChairByRoom> GetArmChairByRoom(string id);

        public void DeleteRoomById(string id);

        public void MarkArmChairByRoomIdAndArmChairId(string armChairId, string roomId, StateArmChair state);

        public void AddRoom(Room room);

        public void AddArmChair(ArmChair armChair);

        public void AddArmChairByRoom(ArmChairByRoom armChairByRoom);

        public int StadisticsByDirector(string name);

        public int StadisticsByMovie(string id);

        public int StadisticsByMovieType(string id);

        public int StadisticsByDate(DateTime date);

        public int StadisticsByDateRange(DateTime dateInitial, DateTime dateFinal);
    }
}
