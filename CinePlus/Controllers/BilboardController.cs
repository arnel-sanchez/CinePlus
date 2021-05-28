using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilboardController : ControllerBase
    {
        private ILogger<BilboardController> Logger;

        private IBilboardRepository BilboardRepository;

        public BilboardController(ILogger<BilboardController> logger, IBilboardRepository bilboardRepository)
        {
            Logger = logger;
            BilboardRepository = bilboardRepository;
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost("add-movie")]
        public IActionResult AddMovie(AddMovieRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var movie = new Movie
                    {
                        DateUpload = request.Date,
                        MovieTypeId = request.MovieTypeId,
                        Name = request.MovieName,
                        MovieId = Guid.NewGuid().ToString(),
                        Description = request.Description,
                        Director = request.Director
                    };
                    while (BilboardRepository.ExistMovieById(movie.MovieId))
                        movie.MovieId = Guid.NewGuid().ToString();
                    BilboardRepository.AddMovie(movie);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpGet("get-type-movie")]
        public IActionResult GetTypeMovie()
        {
            try
            {
                var a = BilboardRepository.GetMovieTypes();
                return Ok(a);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get-movies")]
        public IActionResult GetMovies(DateTime date)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var a = BilboardRepository.GetShowByDate(date);
                    return Ok(a);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("Modelo inválido");
            }
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost("add-show")]
        public IActionResult AddShows()
        {
            return Ok();
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost("add-room")]
        public IActionResult AddRoom()
        {
            return Ok();
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost("add-discount")]
        public IActionResult AddDiscount()
        {
            return Ok();
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost("add-Top10")]
        public IActionResult AddTop10()
        {
            return Ok();
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost("add-armachair")]
        public IActionResult AddArmChair()
        {
            return Ok();
        }
    }
}
