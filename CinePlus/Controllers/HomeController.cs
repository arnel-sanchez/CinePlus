using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _context;

        public HomeController(IHomeRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var res = _context.GetMovieOnTop10s();
            return View(res);
        }
    }
}
