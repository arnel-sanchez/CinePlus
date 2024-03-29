﻿using CinePlus.DataAccess;
using CinePlus.Models;
using CinePlus.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Controllers
{
    [Authorize(Roles=Roles.Manager)]
    public class AdministrationController : Controller
    {
        private ILogger<AdministrationController> Logger;
        private IAdministrationRepository AdministrationRepository;
        private IImageHandler ImageHandler;
        private static string Top10Id;
        private static string MovieName;
        private static DateTime Date= DateTime.Today;
        private static string RoomId;

        public AdministrationController(IImageHandler imageHandler, ILogger<AdministrationController> logger, IAdministrationRepository administrationRepository)
        {
            Logger = logger;
            ImageHandler = imageHandler;
            AdministrationRepository = administrationRepository;
        }

        #region Top10
        public IActionResult GetTop10()
        {
            if(Top10Id == null)
            {
                var res = new Top10Model
                {
                    MovieOnTop10 = AdministrationRepository.GetTop10(),
                    Top10 = AdministrationRepository.GetTop(),
                    Top10s = AdministrationRepository.GetTop10List(),
                    MoviesNotAssigned = AdministrationRepository.GetMoviesNotAssigned()
                };
                return View(res);
            }
            else
            {
                var res = new Top10Model
                {
                    MovieOnTop10 = AdministrationRepository.GetTop10(Top10Id),
                    Top10 = AdministrationRepository.GetTop(Top10Id),
                    Top10s = AdministrationRepository.GetTop10List(),
                    MoviesNotAssigned = AdministrationRepository.GetMoviesNotAssigned(Top10Id)
                };
                return View(res);
            }
        }

        [HttpPost]
        public IActionResult SearchTop10(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            Top10Id = id;
            return RedirectToAction("GetTop10");
        }

        [HttpPost]
        public IActionResult DeleteOnTop10(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            AdministrationRepository.DeleteMovieOnTop10ById(id);
            return RedirectToAction("GetTop10");
        }

        [HttpPost]
        public IActionResult CreateTop10(string name)
        {
            if (string.IsNullOrEmpty(name))
                return NotFound();
            var top = new Top10
            {
                Name = name,
                Top10Id = Guid.NewGuid().ToString()
            };
            AdministrationRepository.AddTop10(top);
            return RedirectToAction("GetTop10");
        }

        [HttpPost]
        public IActionResult AddMovie(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            if(Top10Id == null || Top10Id == "")
            {
                var top = AdministrationRepository.GetTop();
                var movieOnTop10 = new MovieOnTop10
                {
                    MovieId = id,
                    Top10Id = top.Top10Id,
                    Top10 = top,
                    MovieOnTop10Id = Guid.NewGuid().ToString()
                };
                AdministrationRepository.AddMovieOnTop10(movieOnTop10);
            }
            else
            {
                var movieOnTop10 = new MovieOnTop10
                {
                    MovieId = id,
                    Top10Id = Top10Id,
                    MovieOnTop10Id = Guid.NewGuid().ToString()
                };
                AdministrationRepository.AddMovieOnTop10(movieOnTop10);
            }
            return RedirectToAction("GetTop10");
        }
        #endregion

        #region Shows
        public IActionResult GetShows()
        {
            var res = new GetShowsResult
            {
                Date = Date,
                Shows = AdministrationRepository.GetShowsByDate(Date),
                Movie = AdministrationRepository.GetMovies(),
                Room = AdministrationRepository.GetRooms()
            };
            return View(res);
        }

        public IActionResult GetDate(DateTime date)
        {
            if (date == default)
                return NotFound();
            Date = date;
            return RedirectToAction("GetShows");
        }

        [HttpPost]
        public IActionResult CreateShow(CreateShowRequest request)
        {
            if(ModelState.IsValid)
            {
                var show = new Show
                {
                    DateTime = request.Date,
                    MovieId = request.Movie,
                    Price = request.Price,
                    PriceInPoints = request.PriceInPoints,
                    RoomId = request.Room,
                    ShowId = Guid.NewGuid().ToString()
                };
                AdministrationRepository.AddShow(show);
                return RedirectToAction("GetShows");
            }
            foreach (var error in ModelState.Values)
            {
                foreach (var item in error.Errors)
                {
                    Logger.LogError(item.ErrorMessage);
                }
            }
            return View("Getshows");
        }

        [HttpPost]
        public IActionResult DeleteShow(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            AdministrationRepository.DeleteShowById(id);
            return RedirectToAction("GetShows");
        }

        #endregion

        #region Movies
        public IActionResult GetMovies()
        {
            GetMovieResult res = new GetMovieResult();
            if(string.IsNullOrEmpty(MovieName))
            {
                res.Movie = AdministrationRepository.GetMovies();
            }
            else
            {
                res.Movie = AdministrationRepository.GetMoviesByName(MovieName);
            }
            res.MovieType = AdministrationRepository.GetMovieTypes();
            return View(res);
        }

        public IActionResult SearchMovie(string name)
        {
            if (string.IsNullOrEmpty(name))
                return NotFound();
            MovieName = name;
            return RedirectToAction("GetMovies");
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
        {
            if(ModelState.IsValid)
            {
                string url = "";
                if(request.File==null)
                {
                    url = "https://localhost:44304/img/movie.jpg";
                }
                else
                {
                    url = await ImageHandler.UploadImage(request.File);
                }
                var movie = new Movie
                {
                    DateUpload = DateTime.Now,
                    Description = request.Description,
                    Director = request.Director,
                    URL = url,
                    Name = request.Name,
                    MovieTypeId = request.MovieTypeId,
                    MovieId = Guid.NewGuid().ToString()
                };
                AdministrationRepository.AddMovie(movie);
                return RedirectToAction("GetMovies");
            }
            foreach (var error in ModelState.Values)
            {
                foreach (var item in error.Errors)
                {
                    Logger.LogError(item.ErrorMessage);
                }
            }
            return View("GetMovies");
        }

        [HttpPost]
        public IActionResult DeleteMovie(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            AdministrationRepository.DeleteMovie(id);
            return RedirectToAction("GetMovies");
        }
        #endregion

        #region Rooms
        public IActionResult GetRooms()
        {   
            if(string.IsNullOrEmpty(RoomId))
            {
                var res = new GetRoomsResult
                {
                    ArmChairByRooms = AdministrationRepository.GetArmChairByRoom(),
                    Rooms = AdministrationRepository.GetRooms()
                };
                return View(res);
            }
            else
            {
                var res = new GetRoomsResult
                {
                    ArmChairByRooms = AdministrationRepository.GetArmChairByRoom(RoomId),
                    Rooms = AdministrationRepository.GetRooms()
                };
                return View(res);
            }
        }

        [HttpPost]
        public IActionResult SelectRoom(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            RoomId = id;
            return RedirectToAction("GetRooms");
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomRequest request)
        {
            if(ModelState.IsValid)
            {
                Room room = new Room
                {
                    Name = request.Name,
                    NoArmChairs = request.ArmChairs,
                    RoomId = Guid.NewGuid().ToString()
                };
                AdministrationRepository.AddRoom(room);
                for (int i = 0; i < request.ArmChairs; i++)
                {
                    ArmChair armChair = new ArmChair
                    {
                        ArmChairId = Guid.NewGuid().ToString(),
                        No = i + 1
                    };
                    ArmChairByRoom armChairByRoom = new ArmChairByRoom
                    {
                        ArmChairId = armChair.ArmChairId,
                        RoomId = room.RoomId,
                        ArmChairByRoomId = Guid.NewGuid().ToString(),
                        StateArmChair = StateArmChair.ready
                    };
                    AdministrationRepository.AddArmChair(armChair);
                    AdministrationRepository.AddArmChairByRoom(armChairByRoom);
                }
                return RedirectToAction("GetRooms");
            }
            foreach (var error in ModelState.Values)
            {
                foreach (var item in error.Errors)
                {
                    Logger.LogError(item.ErrorMessage);
                }
            }
            return RedirectToAction("GetRooms");
        }

        [HttpPost]
        public IActionResult DeleteRoom(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            AdministrationRepository.DeleteRoomById(id);
            return RedirectToAction("GetRooms");
        }

        public IActionResult MarkArmChair(string armChairId, string roomId, StateArmChair state)
        {
            if (string.IsNullOrEmpty(armChairId) || string.IsNullOrEmpty(roomId))
                return NotFound();
            AdministrationRepository.MarkArmChairByRoomIdAndArmChairId(armChairId, roomId, state);
            return RedirectToAction("GetRooms");
        }
        #endregion

        #region Stadistics
        public IActionResult Stadistics(Stadistics stadistics)
        {
            if(stadistics.Movies!=null)
            {
                return View(stadistics);
            }
            stadistics = new Stadistics
            {
                Movies = AdministrationRepository.GetMovies(),
                MovieTypes = AdministrationRepository.GetMovieTypes()
            };
            return View(stadistics);
        }

        [HttpPost]
        public IActionResult StadisticsByDirector(string name)
        {
            if (string.IsNullOrEmpty(name))
                return NotFound();
            var res = new Stadistics
            {
                Movies = AdministrationRepository.GetMovies(),
                MovieTypes = AdministrationRepository.GetMovieTypes(),
                Name = "Ventas por Director",
                Value = AdministrationRepository.StadisticsByDirector(name)
            };
            return View("Stadistics", res);
        }

        [HttpPost]
        public IActionResult StadisticsByMovie(string movieId)
        {
            if (string.IsNullOrEmpty(movieId))
                return NotFound();
            var res = new Stadistics
            {
                Movies = AdministrationRepository.GetMovies(),
                MovieTypes = AdministrationRepository.GetMovieTypes(),
                Name = "Ventas por Película",
                Value = AdministrationRepository.StadisticsByMovie(movieId)
            };
            return View("Stadistics", res);
        }

        [HttpPost]
        public IActionResult StadisticsByMovieType(string movieTypeId)
        {
            if (string.IsNullOrEmpty(movieTypeId))
                return NotFound();
            var res = new Stadistics
            {
                Movies = AdministrationRepository.GetMovies(),
                MovieTypes = AdministrationRepository.GetMovieTypes(),
                Name = "Ventas del Tipo de Plícula",
                Value = AdministrationRepository.StadisticsByMovieType(movieTypeId)
            };
            return View("Stadistics", res);
        }

        [HttpPost]
        public IActionResult StadisticsByDate(DateTime date)
        {
            if (date == default)
                return NotFound();
            var res = new Stadistics
            {
                Movies = AdministrationRepository.GetMovies(),
                MovieTypes = AdministrationRepository.GetMovieTypes(),
                Name = "Ventas del Día",
                Value = AdministrationRepository.StadisticsByDate(date)
            };
            return View("Stadistics", res);
        }

        [HttpPost]
        public IActionResult StadisticsByDateRange(DateTime dateInitial, DateTime dateFinal)
        {
            if (dateFinal == default || dateInitial == default)
                return NotFound();
            var res = new Stadistics
            {
                Movies = AdministrationRepository.GetMovies(),
                MovieTypes = AdministrationRepository.GetMovieTypes(),
                Name = "Ventas del Rango de Fecha",
                Value = AdministrationRepository.StadisticsByDateRange(dateInitial, dateFinal)
            };
            return View("Stadistics", res); ;
        }
        #endregion
    }
}
