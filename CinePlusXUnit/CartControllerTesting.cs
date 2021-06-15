using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Xunit;
using Moq;
using CinePlus.Controllers;
using CinePlus.Models;
using CinePlusXUnit.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinePlusXUnit
{
    public class CartControllerTesting
    {
        private readonly CartController cart;

        public CartControllerTesting()
        {
            FakeCardReposity card = new FakeCardReposity();
            FakeUserManagerCart userM = new FakeUserManagerCart();
            cart = new CartController(new Mock<ILogger<CartController>>().Object, card, userM);
            
            
        }

        [Fact]
        public void IndexEndpointTest()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult index = cart.Index();
            Assert.IsType<ViewResult>(index);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SelectArchChairNotFoundTest(string id)
        {
            IActionResult selecArchChair = cart.SelectArmChair(id);
            Assert.IsType<NotFoundResult>(selecArchChair);
        }

        [Fact]
        public void SelectArchChairTestViewResultTest()
        {
            IActionResult selecArchChair = cart.SelectArmChair("anyNotEmptyOrNullString");
            Assert.IsType<ViewResult>(selecArchChair);
        }

        [Theory]
        [InlineData("", "any")]
        [InlineData(null, "any")]
        [InlineData("any", null)]
        [InlineData("any", "")]
        public void AddArmChairNotFoundTest(string armChairId, string showId)
        {


            IActionResult addArchChair = cart.AddArmChair(armChairId, showId);


            Assert.IsType<NotFoundResult>(addArchChair);
        }

        [Fact]
        public void AddArmCharViewResultTest()
        {
            IActionResult addArchChair = cart.AddArmChair("any", "any");
            Assert.IsType<ViewResult>(addArchChair);
        }

        [Theory]
        [InlineData("", "any", "any")]
        [InlineData(null, "any", "any")]
        [InlineData("any", null, "any")]
        [InlineData("any", "", "any")]
        [InlineData("any", "any", null)]
        [InlineData("any", "any", "")]
        public void SelectDiscountNotFoundTest(string armChairId, string showId, string discountByShowId)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult selectDiscount = cart.SelectDiscount(armChairId, showId, discountByShowId);
            Assert.IsType<NotFoundResult>(selectDiscount);
        }

        [Fact]
        public void SelectDiscountTestViewResult()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult selectDiscount = cart.SelectDiscount("armId", "showId", "discountId");
            Assert.IsType<RedirectToActionResult>(selectDiscount);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void QuitArmChairNotFoundTest(string id)
        {
            IActionResult quitArmChair = cart.QuitArmChair(id);

            Assert.IsType<NotFoundResult>(quitArmChair);
        }
        [Fact]
        public void QuitArmChairRedirectTest()
        {

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult quitArmChair = cart.QuitArmChair("acceptedNotNullOrEmptyQuitArmChair");

            Assert.IsType<RedirectToActionResult>(quitArmChair);
        }

        [Fact]

        public void PayTicketWithMoneyTest()
        {
            Mock<ModelStateDictionary> modelStateDictionaryMock = new Mock<ModelStateDictionary>();
            PayTicketRequest request = new PayTicketRequest()
            {
                DateTime = DateTime.Now,
                Card = 20,
                Code = 1,
                Name = "Request1"
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult payTicketWithMoney = cart.PayTicketWithMoney(request);

            Assert.IsType<RedirectToActionResult>(payTicketWithMoney);

        }

        [Fact]

        public void PayTicketWithPointsTest()
        {


            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult payTicketWithPoints = cart.PayTicketWithPoints();

            Assert.IsType<RedirectToActionResult>(payTicketWithPoints);


        }
        [Fact]
        public void GetPayCartTest()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult payCarts = cart.GetPayCarts();
            Assert.IsType<ViewResult>(payCarts);
        }
       

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PrintNotFoundTest(string id)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult print = cart.Print(id);
            Assert.IsType<NotFoundResult>(print);
        }

        [Fact]
        public void PrintFileContentResulTest()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult print = cart.Print("anyNotEmptyOrNullString");
            Assert.IsType<FileContentResult>(print);

        }
        

        

        [Theory]
        [InlineData(12)] //Caso donde se hace null payCart
        [InlineData(1)]
        public void CancelPayTest(long cardOrCode)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult cancelPay = cart.CancelPay(cardOrCode);
            Assert.IsType<RedirectToActionResult>(cancelPay);
        }

        [Fact]
        public void GetCartCountTest()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.Role, "role")

            }, "mock"));

            cart.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            IActionResult getCartCount = cart.GetCartCount();

            Assert.IsType<OkObjectResult>(getCartCount);

        }


    }

   
}
