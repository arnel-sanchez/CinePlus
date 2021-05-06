using cine__backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cine__backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<User> UserManager;

        private SignInManager<User> SignInManager;

        private ILogger<AuthController> Logger;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthController> logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register-manager")]
        public IActionResult RegisterManager()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register-partner")]
        public IActionResult RegisterPartner()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("edit")]
        public IActionResult Edit()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("get-user")]
        public IActionResult GetUser()
        {
            return Ok();
        }
    }
}
