using CinePlus.Controllers;
using CinePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;
using System.Security.Claims;
using System.Collections.Generic;
using CinePlus.Test.Mocks;

namespace CinePlus.Test
{
    public class AuthControllerTest
    {
        private readonly AuthController authController;

        public AuthControllerTest()
        {
            var fakeHttpContextAccessor = new FakeHttpContextAccessor();
            var fakeUserManager = new FakeUserManager();
            var fakeSignInManager = new FakeSignInManager(fakeHttpContextAccessor);
            var fakeIAuthRepository = new FakeIAuthRepository();
            authController = new AuthController(
                fakeUserManager,
                fakeSignInManager,
                new Mock<ILogger<AuthController>>().Object,
                fakeIAuthRepository
                );
        }

        #region UnitsTestLogin
        [Theory]
        [ClassData(typeof(LoginRequestInvalidData))]
        public void Login_Error_ShouldReturn_ShouldReturn400(LoginModelRequest request)
        {
            if (request.password == null || request.username == null)
                authController.ModelState.AddModelError("error", "probando modelInvalid");
            //Act
            var result = this.authController.LoginAsync(request);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Theory]
        [ClassData(typeof(LoginRequestValidData))]
        public void Login_ValidCredentials_ShouldReturn200(LoginModelRequest request)
        {
            //Act
            var result = this.authController.LoginAsync(request);

            //Assert
            Assert.IsType<OkResult>(result.Result);
        }
        #endregion

        #region UnitsTestRegister
        [Theory]
        [ClassData(typeof(RegisterRequestInvalidData))]
        public void Register_Error_ShouldReturn_ShouldReturn400(RegisterModelRequest request)
        {
            if (request.password == null || request.userName == null || request.email == null || request.lastName == null || request.name == null || request.password == null || request.role == null)
                authController.ModelState.AddModelError("error", "probando modelInvalid");
            //Act
            var result = this.authController.RegisterAsync(request);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Theory]
        [ClassData(typeof(RegisterRequestValidData))]
        public void Register_ValidCredentials_ShouldReturn200(RegisterModelRequest request)
        {
            //Act
            var result = this.authController.RegisterAsync(request);

            //Assert
            Assert.IsType<OkResult>(result.Result);
        }
        #endregion

        #region UnitsTestEdit
        [Theory]
        [ClassData(typeof(EditRequestInvalidData))]
        public void Edit_Error_ShouldReturn_ShouldReturn400(EditModelRequest request)
        {
            if (request.password == null || request.userId == null)
                authController.ModelState.AddModelError("error", "probando modelInvalid");
            //Act
            var result = this.authController.EditAsync(request);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Theory]
        [ClassData(typeof(EditRequestValidData))]
        public void Edit_ValidCredentials_ShouldReturn200(EditModelRequest request)
        {
            //Act
            var result = this.authController.EditAsync(request);

            //Assert
            Assert.IsType<OkResult>(result.Result);
        }
        #endregion

        #region UnitsTestLogout
        [Fact]
        public void Logout_ValidCredentials_ShouldReturn200()
        {
            authController.ControllerContext.HttpContext = new FakeHttpContext();
            authController.ControllerContext.HttpContext.User = new ClaimsPrincipal();
            authController.ControllerContext.HttpContext.User.AddIdentity(new FakeClaimsIdentity("valid"));
            //Act
            var result = this.authController.LogoutAsync();

            //Assert
            Assert.IsType<OkResult>(result.Result);
        }
        #endregion

        #region UnitsTestGetUserAsync
        [Fact]
        public void GetUserAsync_Error_ShouldReturn_ShouldReturn400()
        {
            authController.ControllerContext.HttpContext = new FakeHttpContext();
            authController.ControllerContext.HttpContext.User = new ClaimsPrincipal();
            authController.ControllerContext.HttpContext.User.AddIdentity(new FakeClaimsIdentity("invalid"));

            //Act
            var result = this.authController.GetUserAsync();

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void GetUserAsync_Partner_ValidCredentials_ShouldReturn200()
        {
            authController.ControllerContext.HttpContext = new FakeHttpContext();
            authController.ControllerContext.HttpContext.User = new ClaimsPrincipal();
            authController.ControllerContext.HttpContext.User.AddIdentity(new FakeClaimsIdentity("partner"));
            //Act
            var result = this.authController.GetUserAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetUserAsync_User_ValidCredentials_ShouldReturn200()
        {
            authController.ControllerContext.HttpContext = new FakeHttpContext();
            authController.ControllerContext.HttpContext.User = new ClaimsPrincipal();
            authController.ControllerContext.HttpContext.User.AddIdentity(new FakeClaimsIdentity("valid"));
            //Act
            var result = this.authController.GetUserAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
        #endregion
    }
}
