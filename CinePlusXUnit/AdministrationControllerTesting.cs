using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CinePlus.Controllers;
using CinePlus.Models;
using CinePlusXUnit.Mocks;
using CinePlusXUnit.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinePlusXUnit
{
    public class AdministrationControllerTesting
    {
        private readonly AdministrationController administration;

        public AdministrationControllerTesting()
        {
            FakeAdministrationRepositoy adminRepo = new FakeAdministrationRepositoy();
            FakeImageHandler imageHandler = new FakeImageHandler();
            Mock<ILogger<AdministrationController>> mockILogger = new Mock<ILogger<AdministrationController>>();
            administration = new AdministrationController(imageHandler, mockILogger.Object, adminRepo);
        }

        #region Top10 Tests
        [Fact]
        public void GetTop10Test()
        {
            
            IActionResult getTop10 = administration.GetTop10();
            Assert.IsType<ViewResult>(getTop10);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SearchTop10NotFoundTest(string id)
        {
            IActionResult searchTop10 = administration.SearchTop10(id);

            Assert.IsType<NotFoundResult>(searchTop10);
        }

        [Fact]
        public void SearchTop10RedirectResultTest()
        {
            IActionResult searchTop10 = administration.SearchTop10("notNullOrEmpty");

            Assert.IsType<RedirectToActionResult>(searchTop10);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeleteOnTop10TestNotFoundTest(string id)
        {
            IActionResult searchTop10 = administration.DeleteOnTop10(id);

            Assert.IsType<NotFoundResult>(searchTop10);
        }

        [Fact]
        public void DeleteOnTop10RedirectResultTest()
        {
            IActionResult searchTop10 = administration.DeleteOnTop10("notNullOrEmpty");

            Assert.IsType<RedirectToActionResult>(searchTop10);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreateTop10TestNotFoundTest(string id)
        {
            IActionResult createTop10 = administration.CreateTop10(id);

            Assert.IsType<NotFoundResult>(createTop10);
        }

        [Fact]
        public void CreateTop10RedirecResultTest()
        {
            IActionResult createTop10 = administration.CreateTop10("notNullOrEmpty");

            Assert.IsType<RedirectToActionResult>(createTop10);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void AddMovieTestNotFoundTest(string id)
        {
            IActionResult addMovie = administration.AddMovie(id);

            Assert.IsType<NotFoundResult>(addMovie);
        }

        [Fact]
        public void AddMovieRedirectResultTest()
        {
            IActionResult addMovie = administration.AddMovie("notNullOrEmpty");

            Assert.IsType<RedirectToActionResult>(addMovie);
        }


        #endregion

        #region Shows Tests
        [Fact]
        public void GetShowsTest()
        {
            IActionResult getShows = administration.GetShows();
            Assert.IsType<ViewResult>(getShows);
        }

        [Fact]
        public void GetDateTestNotFoundTest()
        {
            IActionResult getData = administration.GetDate(new DateTime());
            Assert.IsType<NotFoundResult>(getData);
        }

        [Fact]
        public void GetDateRedirectTest()
        {
            IActionResult getData = administration.GetDate(DateTime.Now);
            Assert.IsType<RedirectToActionResult>(getData);
        }


        [Fact]
        public void CreateShowRequestTest()
        {
            CreateShowRequest request = new CreateShowRequest()
            {
                Movie = "TestMovie",
                Date = DateTime.Today,
                Price = 1,
                PriceInPoints = 1,
                Room = "TestRoom"

            };

            IActionResult createShow = administration.CreateShow(request);
            Assert.IsType<RedirectToActionResult>(createShow);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeleteShowNotFoundTest(string id)
        {
            IActionResult deleteShow = administration.DeleteShow(id);
            Assert.IsType<NotFoundResult>(deleteShow);
        }

        [Fact]
        public void DeleteShowRedirectTest()
        {
            IActionResult deleteShow = administration.DeleteShow("notEmptyOrNull");
            Assert.IsType<RedirectToActionResult>(deleteShow);
        }

        #endregion

        #region MoviesTest

        [Fact]
        public void GetMoviesTest()
        {
            IActionResult getMovies = administration.GetMovies();
            Assert.IsType<ViewResult>(getMovies);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SearchMovieNotFoundTest(string name)
        {
            IActionResult searchMovie = administration.SearchMovie(name);
            Assert.IsType<NotFoundResult>(searchMovie);
        }


        [Fact]
        public void SearchMovieRedirectTest()
        {
            IActionResult searchMovie = administration.SearchMovie("anyMovie");
            Assert.IsType<RedirectToActionResult>(searchMovie);
        }


        // Falta  public async Task<IActionResult> CreateMovie(CreateMovieRequest request) por testear 
        [Fact]
        public void CreateMovieNotNullFileTest()
        {
            CreateMovieRequest request = new CreateMovieRequest()
            {
                MovieTypeId = Guid.NewGuid().ToString(),
                Description = "Its a fake description",
                Director = "Fake Director",
                File = new Mock<IFormFile>().Object,
                Name = "Fake Name"
            };

            Task<IActionResult> createMovie = administration.CreateMovie(request);
            Assert.IsType<RedirectToActionResult>(createMovie.Result);

        }

        [Fact]
        public void CreateMovieNullFileTest()
        {
            CreateMovieRequest request = new CreateMovieRequest()
            {
                MovieTypeId = Guid.NewGuid().ToString(),
                Description = "Its a fake description",
                Director = "Fake Director",
                File =null,
                Name = "Fake Name"
            };

            Task<IActionResult> createMovie = administration.CreateMovie(request);
            Assert.IsType<RedirectToActionResult>(createMovie.Result);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeleteMovieNotFoundTest(string id)
        {
            IActionResult deleteMovie = administration.DeleteMovie(id);
            Assert.IsType<NotFoundResult>(deleteMovie);
        }


        [Fact]
        public void DeleteMovieRedirectTest()
        {
            IActionResult deleteMovie = administration.DeleteMovie("notEmptyOrNull");
            Assert.IsType<RedirectToActionResult>(deleteMovie);
        }
        #endregion

        #region RoomsTest
        [Fact]
        public void GetRoomsTest()
        {
            IActionResult rooms = administration.GetRooms();
            Assert.IsType<ViewResult>(rooms);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SelectRoomsNotFound(string id)
        {
            IActionResult selectRooms = administration.SelectRoom(id);
            Assert.IsType<NotFoundResult>(selectRooms);
        }

        [Fact]

        public void SelectRoomsRedirectTest()
        {
            IActionResult selectRooms = administration.SelectRoom("notNullOrEmpty");
            Assert.IsType<RedirectToActionResult>(selectRooms);
        }

        [Fact]
        public void CreateRoomTestCorrect()
        {
            CreateRoomRequest roomRequest = new CreateRoomRequest()
            {
                Name = "Hab265",
                ArmChairs = 2
            };

            IActionResult createRoom = administration.CreateRoom(roomRequest);
            Assert.IsType<RedirectToActionResult>(createRoom);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeleteRoomNotFoundTest(string id)
        {
            IActionResult deleteRoom = administration.DeleteRoom(id);
            Assert.IsType<NotFoundResult>(deleteRoom);
        }

        [Fact]
        public void DeleteRoomRedirectTest()
        {
            IActionResult deleteRoom = administration.DeleteRoom("notEmptyOrNull");
            Assert.IsType<RedirectToActionResult>(deleteRoom);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void MarkArmChairNotFoundTest(string id)
        {
            IActionResult markArmChair = administration.MarkArmChair(id, StateArmChair.broken);
            Assert.IsType<NotFoundResult>(markArmChair);
        }

        [Fact]
        public void MarkArmChairRedirectTest()
        {
            IActionResult markArmChair = administration.MarkArmChair("notEmptyOrNull", StateArmChair.ready);
            Assert.IsType<RedirectToActionResult>(markArmChair);
        }




        #endregion

        #region Stadistics
        [Fact]
        public void StadisticsNullMoviesTest()
        {
            Stadistics stadistics = new Stadistics()
            {
                Movies = null,
                MovieTypes = new List<MovieType>(),
                Name = "NotMovie",
                Value = 2
            };
            IActionResult stadisticEndpoint = administration.Stadistics(stadistics);
            Assert.IsType<ViewResult>(stadisticEndpoint);
        }

        [Fact]
        public void StadisticsNotNullMoviesTest()
        {
            Stadistics stadistics = new Stadistics()
            {
                Movies = new List<Movie>(),
                MovieTypes = new List<MovieType>(),
                Name = "OtherMovies",
                Value = 3
            };

            IActionResult stadisticEndpoint = administration.Stadistics(stadistics);
            Assert.IsType<ViewResult>(stadisticEndpoint);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void StadisticsByDirectorNotFoundTest(string name)
        {
            IActionResult stadisticsByDirector = administration.StadisticsByDirector(name);
            Assert.IsType<NotFoundResult>(stadisticsByDirector);
        }

        [Fact]
        public void StadisticsByDirectorViewResultTest()
        {
            IActionResult stadisticsByDirector = administration.StadisticsByDirector("notEmptyOrNull");
            Assert.IsType<ViewResult>(stadisticsByDirector);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void StadisticsByMovieNotFoundTest(string movieId)
        {
            IActionResult stadisticsByMovie = administration.StadisticsByMovie(movieId);
            Assert.IsType<NotFoundResult>(stadisticsByMovie);
        }

        [Fact]
        public void StadisticsByMovieViewResultTest()
        {   
            IActionResult stadisticsByMovie = administration.StadisticsByMovie("notEmptyOrNull");
            Assert.IsType<ViewResult>(stadisticsByMovie);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void StadisticsByMovieTypeNotFoundTest(string movieTypeId){

            IActionResult stadisctisByMovie = administration.StadisticsByMovieType(movieTypeId);
            Assert.IsType<NotFoundResult>(stadisctisByMovie);
        } 

        [Fact]
        public void StadisticsByMovieTypeViewResultTest(){
            IActionResult stadisticsByMovie =administration.StadisticsByMovieType("notEmptyOrNull");
            Assert.IsType<ViewResult>(stadisticsByMovie);
        }

        [Fact]
        public void StadisticsByDateNotFoundTest(){
            IActionResult stadisticsByDate = administration.StadisticsByDate(default);
            Assert.IsType<NotFoundResult>(stadisticsByDate);
        }
        
        
        [Fact]
        public void StadisticsByDateViewResultTest(){
            IActionResult stadisticsByDate = administration.StadisticsByDate(DateTime.Now);
            Assert.IsType<ViewResult>(stadisticsByDate);
        }

       
        [Theory]
        [ClassData(typeof(StadisticsByDateRangeData))]
        public void StadisticsByDateRangeTest(DateTime dateInitial, DateTime dateFinal)
        {
            IActionResult stadisticsByDateRang = administration.StadisticsByDateRange(dateInitial, dateFinal);
            if (dateFinal == default || dateInitial == default) 
                Assert.IsType<NotFoundResult>(stadisticsByDateRang);
            else 
                Assert.NotNull(stadisticsByDateRang);
            
        }

        #endregion
    }
}
