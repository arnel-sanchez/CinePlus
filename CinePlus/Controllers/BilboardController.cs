using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Controllers
{
    public class BilboardController : Controller
    {
        private IBilboardRepository BilboardRepository;
        private static DateTime DateTime = DateTime.Today;
        private static string Search="";

        public BilboardController(IBilboardRepository bilboardRepository)
        {
            BilboardRepository = bilboardRepository;
        }

        public IActionResult Index()
        {
            var title = "";
            if (DateTime.DayOfWeek.ToString() == "Monday")
                title += "Lunes";
            else if (DateTime.DayOfWeek.ToString() == "Tuesday")
                title += "Martes";
            else if (DateTime.DayOfWeek.ToString() == "Wednesday")
                title += "Miércoles";
            else if (DateTime.DayOfWeek.ToString() == "Thursday")
                title += "Jueves";
            else if (DateTime.DayOfWeek.ToString() == "Friday")
                title += "Viernes";
            else if (DateTime.DayOfWeek.ToString() == "Saturday")
                title += "Sábado";
            else if (DateTime.DayOfWeek.ToString() == "Sunday")
                title += "Domingo";
            title += " " + DateTime.Day + "/" + DateTime.Month + "/" + DateTime.Year;
            string date = DateTime.Year.ToString()+"-";
            if (DateTime.Month < 10)
                date += "0" + DateTime.Month + "-";
            else
                date += DateTime.Month + "-";
            if (DateTime.Day < 10)
                date += "0" + DateTime.Day;
            else
                date += DateTime.Day;
            var res = new ListBilboardResult
            {
                Shows = BilboardRepository.GetShowByDate(DateTime),
                DiscountsByShows = BilboardRepository.GetDiscounts(DateTime),
                Title = title,
                Date = date
            };
            return View(res);
        }

        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            var movie = BilboardRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        public IActionResult SearchMovie(string search)
        {
            Search = search;
            return RedirectToAction("BilboardByMovie");
        }

        public IActionResult SelectDate(DateTime date)
        {
            DateTime = date;
            return RedirectToAction("Index");
        }

        public IActionResult BilboardByMovie()
        {
            var res = new ListBilboardResult
            {
                Shows = BilboardRepository.GetShowByMovieName(Search),
                Title = Search,
                DiscountsByShows = BilboardRepository.GetDiscounts(Search)
            };
            return View(res);
        }
    }
}
