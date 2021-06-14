using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CinePlus.Controllers;
using CinePlusXUnit.Mocks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace CinePlusXUnit
{
    public class HomeControllerTesting
    {
        private readonly HomeController home;

        public HomeControllerTesting()
        {
            FakekHomeRepository context = new FakekHomeRepository();
            home = new HomeController(context);

        }

        [Fact]
        public void IndexEndpointTest()
        {
            IActionResult index = home.Index();
            Assert.IsType<ViewResult>(index);
        }

        

      


    }
}
