using CinePlus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public class AdministrationDataAccess : IAdministrationRepository
    {
        private CinePlusDBContext _context;

        public AdministrationDataAccess(CinePlusDBContext context)
        {
            _context = context;
        }

        public void AddArmChair(ArmChair armChair)
        {
            _context.ArmChair.Add(armChair);
            _context.SaveChanges();
        }

        public void AddArmChairByRoom(ArmChairByRoom armChairByRoom)
        {
            _context.ArmChairByRoom.Add(armChairByRoom);
            _context.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
        }

        public void AddMovieOnTop10(MovieOnTop10 movieOnTop10)
        {
            _context.MovieOnTop10.Add(movieOnTop10);
            _context.SaveChanges();
        }

        public void AddRoom(Room room)
        {
            _context.Room.Add(room);
            _context.SaveChanges();
        }

        public void AddShow(Show show)
        {
            _context.Show.Add(show);
            _context.SaveChanges();
        }

        public void AddTop10(Top10 top10)
        {
            _context.Top10.Add(top10);
            _context.SaveChanges();
        }

        public void DeleteMovie(string id)
        {
            var movie = _context.Movie.Where(x => x.MovieId == id).FirstOrDefault();
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }

        public void DeleteMovieOnTop10ById(string id)
        {
            var res = _context.MovieOnTop10.Where(x => x.MovieOnTop10Id == id).FirstOrDefault();
            _context.MovieOnTop10.Remove(res);
            _context.SaveChanges();
        }

        public void DeleteRoomById(string id)
        {
            var armchair = _context.ArmChairByRoom.Include(x=>x.ArmChair).Where(x => x.RoomId == id).ToList();
            foreach (var item in armchair)
            {
                _context.ArmChairByRoom.Remove(item);
                _context.ArmChair.Remove(item.ArmChair);
            }
            var room = _context.Room.Where(x => x.RoomId == id).FirstOrDefault();
            _context.Room.Remove(room);
            _context.SaveChanges();
        }

        public void DeleteShowById(string id)
        {
            var show = _context.Show.Where(x => x.ShowId == id).FirstOrDefault();
            _context.Show.Remove(show);
            _context.SaveChanges();
        }

        public List<ArmChairByRoom> GetArmChairByRoom()
        {
            var room = _context.Room.FirstOrDefault();
            var res = _context.ArmChairByRoom
                .Include(x => x.ArmChair)
                .Where(x => x.RoomId == room.RoomId)
                .OrderBy(x=>x.ArmChair.No)
                .ToList();
            var query =
                from armChair in res
                group armChair by armChair.ArmChair.No;
            var list = new List<ArmChairByRoom>();
            foreach (var item in query)
            {
                var temp = item.ElementAt(0);
                list.Add(temp);
            }
            return list;
        }

        public List<ArmChairByRoom> GetArmChairByRoom(string id)
        {
            return _context.ArmChairByRoom.Include(x => x.ArmChair).Where(x => x.RoomId == id).OrderBy(x=>x.ArmChair.No).ToList();
        }

        public List<Movie> GetMovies()
        {
            return _context.Movie.Include(x=>x.MovieType).ToList();
        }

        public List<Movie> GetMoviesByName(string name)
        {
            return _context.Movie.Include(x => x.MovieType).Where(x=>x.Name.Contains(name) || x.Name==name).ToList();
        }

        public List<Movie> GetMoviesNotAssigned()
        {
            var top10 = _context.Top10.FirstOrDefault();
            var movieOnTop10 = _context.MovieOnTop10
                .Include(x => x.Movie)
                .Include(x => x.Top10)
                .Include(x => x.Movie.MovieType)
                .Where(x => x.Top10Id == top10.Top10Id)
                .Select(x=>x.MovieId)
                .ToList();
            return _context.Movie.Where(x => !movieOnTop10.Contains(x.MovieId)).ToList();
        }

        public List<Movie> GetMoviesNotAssigned(string id)
        {
            var movieOnTop10 = _context.MovieOnTop10
                .Include(x => x.Movie)
                .Include(x => x.Top10)
                .Include(x => x.Movie.MovieType)
                .Where(x => x.Top10Id == id)
                .Select(x => x.MovieId)
                .ToList();
            return _context.Movie.Where(x => !movieOnTop10.Contains(x.MovieId)).ToList();
        }

        public List<MovieType> GetMovieTypes()
        {
            return _context.MovieType.ToList();
        }

        public List<Room> GetRooms()
        {
            return _context.Room.ToList();
        }

        public List<Show> GetShowsByDate(DateTime date)
        {
            return _context
                .Show
                .Include(x=>x.Movie)
                .Include(x=>x.Room)
                .Where(x => x.DateTime.Year == date.Year && x.DateTime.Month == date.Month && x.DateTime.Day == date.Day)
                .OrderBy(x=>x.DateTime)
                .ToList();
        }

        public Top10 GetTop()
        {
            return _context.Top10.FirstOrDefault();
        }

        public Top10 GetTop(string top10id)
        {
            return _context.Top10.Where(x => x.Top10Id == top10id).FirstOrDefault();
        }

        public List<MovieOnTop10> GetTop10(string top10Id)
        {
            return _context.MovieOnTop10
                .Include(x=>x.Movie)
                .Include(x=>x.Top10)
                .Include(x => x.Movie.MovieType)
                .Where(x=>x.Top10Id==top10Id)
                .OrderBy(x=>x.Top10Id)
                .ToList();
        }

        public List<MovieOnTop10> GetTop10()
        {
            var top10 = _context.Top10.FirstOrDefault();
            return _context.MovieOnTop10
                .Include(x => x.Movie)
                .Include(x => x.Top10)
                .Include(x=>x.Movie.MovieType)
                .Where(x=>x.Top10Id==top10.Top10Id)
                .OrderBy(x => x.Top10Id)
                .ToList();
        }

        public List<Top10> GetTop10List()
        {
            return _context.Top10
                .OrderBy(x => x.Top10Id)
                .ToList();
        }

        public void MarkArmChairByRoomIdAndArmChairId(string armChairId, string roomId, StateArmChair state)
        {
            var armChair = _context.ArmChairByRoom.Where(x => x.ArmChairId == armChairId && x.RoomId==roomId).ToList();
            foreach (var item in armChair)
            {
                item.StateArmChair = state;
                _context.ArmChairByRoom.Update(item);
            }
            _context.SaveChanges();
        }

        public int StadisticsByDate(DateTime date)
        {
            return _context.Carts.Where(x => x.DateTime.Year == date.Year && x.DateTime.Month == date.Month && x.DateTime.Day == date.Day).Count();
        }

        public int StadisticsByDateRange(DateTime dateInitial, DateTime dateFinal)
        {
            return _context.Carts.Where(x => x.DateTime.Year >= dateInitial.Year && x.DateTime.Month >= dateInitial.Month && x.DateTime.Day >= dateInitial.Day && x.DateTime.Year <= dateFinal.Year && x.DateTime.Month <= dateFinal.Month && x.DateTime.Day <= dateFinal.Day).Count();
        }

        public int StadisticsByDirector(string name)
        {
            return _context.Carts.Where(x => x.DiscountsByShow.Show.Movie.Director == name || x.DiscountsByShow.Show.Movie.Director.Contains(name)).Count();
        }

        public int StadisticsByMovie(string id)
        {
            return _context.Carts.Where(x => x.DiscountsByShow.Show.Movie.MovieId == id).Count();
        }

        public int StadisticsByMovieType(string id)
        {
            return _context.Carts.Where(x => x.DiscountsByShow.Show.MovieId == id).Count();
        }
    }
}
