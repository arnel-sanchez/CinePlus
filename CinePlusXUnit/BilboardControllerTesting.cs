using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.Editing;
using Xunit;
using Moq;
using CinePlus.Controllers;
using CinePlusXUnit.Mocks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using CinePlus.DataAccess;
using CinePlus.Models;
namespace CinePlusXUnit
{
   public class BilboardControllerTesting
    {
        private readonly BilboardController bilboard;
        public BilboardControllerTesting()
        {
            FakeBilboardRepository fakeRepository = new FakeBilboardRepository();
            bilboard = new BilboardController(fakeRepository);
        }

        [Fact]
        public void IndexTest()
        {
            IActionResult index = bilboard.Index();
            Assert.IsType<ViewResult>(index);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("0")]//case movie = null

        public void DetailsNotFoundTest(string id)
        {
            
            IActionResult details = bilboard.Details(id);
            Assert.IsType<NotFoundResult>(details);
        }

        [Fact]
        public void DetailsVieResultTest()
        {
            IActionResult details = bilboard.Details("1");
            Assert.IsType<ViewResult>(details);
        }


        [Fact]
        public void SearchMovieTest()
        {
            IActionResult select = bilboard.SearchMovie("default");
            Assert.IsType<RedirectToActionResult>(select);

        }

        [Fact]
        public void SelectDateTest()
        {
            IActionResult select = bilboard.SelectDate(DateTime.Today);
            Assert.IsType<RedirectToActionResult>(select);

        }

        [Fact]
        public void BilboardByMovieTest()
        {
            IActionResult select = bilboard.BilboardByMovie();
            Assert.IsType<ViewResult>(select);
        }






    }
}
