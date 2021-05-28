using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AuthController : ControllerBase
    {
        private UserManager<User> UserManager;

        private SignInManager<User> SignInManager;

        private ILogger<AuthController> Logger;

        private IAuthRepository AuthRepository;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthController> logger, IAuthRepository authRepository)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
            AuthRepository = authRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginModelRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await UserManager.FindByNameAsync(request.username);
                    if (user != null)
                    {
                        var result = await SignInManager.PasswordSignInAsync(user, request.password, false, false);
                        if (result.Succeeded)
                        {
                            Logger.LogInformation($"El usuario [{request.username}] se ha autenticado en el sistema.");
                            return Ok();
                        }
                        else
                        {
                            Logger.LogError($"El usuario [{request.username}] ha proporcionado una contraseña incorrecta.");
                            return BadRequest("Incorrect Password");
                        }
                    }
                    else
                    {
                        Logger.LogError($"El usuario [{request.username}] no existe.");
                        return BadRequest("Incorrect Username");
                    }
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                    return BadRequest(e.Message);
                }
            }
            var a = ModelState.GetEnumerator();
            a.MoveNext();
            var error = a.Current.Value.Errors.GetEnumerator();
            error.MoveNext();
            Logger.LogError(error.Current.ErrorMessage);
            return BadRequest(error.Current.ErrorMessage);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterModelRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User
                    {
                        Email = request.email,
                        LastName = request.lastName,
                        Name = request.name,
                        UserName = request.userName,
                        Role = request.role
                    };
                    if(request.role == Roles.Partner)
                    {
                        var random = new Random();
                        var partner = new Partner
                        {
                            Id = Guid.NewGuid().ToString(),
                            Points = 0,
                            User = user,
                            Code = random.Next(100000, 1000000).ToString()
                        };
                        var res = await UserManager.CreateAsync(user, request.password);
                        if (res.Succeeded)
                        {
                            AuthRepository.CreatePartner(partner);
                            Logger.LogInformation($"El usuario [{request.userName}] se ha registrado en el sistema.");
                            return Ok();
                        }
                    }
                    else if(request.role == Roles.Client)
                    {
                        var res = await UserManager.CreateAsync(user, request.password);
                        if (res.Succeeded)
                        {
                            Logger.LogInformation($"El usuario [{request.userName}] se ha registrado en el sistema.");
                            return Ok();
                        }
                    }
                    else
                    {
                        Logger.LogError($"El usuario [{request.userName}] no se puede registrar como Manager.");
                        return BadRequest();
                    }
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                    return BadRequest(e.Message);
                }
            }
            var a = ModelState.GetEnumerator();
            a.MoveNext();
            var error = a.Current.Value.Errors.GetEnumerator();
            error.MoveNext();
            Logger.LogError(error.Current.ErrorMessage);
            return BadRequest(error.Current.ErrorMessage);
        }

        [Authorize(Roles = Roles.Manager)]
        [HttpPost("register-manager")]
        public async Task<IActionResult> RegisterManagerAsync(RegisterModelRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User
                    {
                        Email = request.email,
                        LastName = request.lastName,
                        Name = request.name,
                        UserName = request.userName,
                        Role = request.role
                    };
                    var res = await UserManager.CreateAsync(user, request.password);
                    if (res.Succeeded)
                    {
                        Logger.LogInformation($"El usuario [{request.userName}] ha sido registrado en el sistema.");
                        return Ok();
                    }
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                    return BadRequest(e.Message);
                }
            }
            var a = ModelState.GetEnumerator();
            a.MoveNext();
            var error = a.Current.Value.Errors.GetEnumerator();
            error.MoveNext();
            Logger.LogError(error.Current.ErrorMessage);
            return BadRequest(error.Current.ErrorMessage);
        }

        [Authorize]
        [HttpPost("edit")]
        public async Task<IActionResult> EditAsync(EditModelRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await UserManager.FindByIdAsync(request.userId);
                    if (user == null)
                    {
                        Logger.LogError($"El usuario con id [{request.userId}] no existe en el sistema.");
                        return BadRequest("Incorrect UserId");
                    }
                    if (request.userName != null)
                    {
                        if (UserManager.FindByNameAsync(request.userName).Result != null)
                        {
                            Logger.LogError($"El usuario [{request.userName}] ya existe existe en el sistema.");
                            return BadRequest("There is a user with that username.");
                        }
                        user.UserName = request.userName;
                    }
                    if (request.name != null)
                        user.Name = request.name;
                    if (request.lastName != null)
                        user.LastName = request.lastName;
                    if (request.email != null)
                        user.Email = request.email;
                    var check = await UserManager.CheckPasswordAsync(user, request.password);
                    if (check)
                    {
                        var a = await UserManager.UpdateAsync(user);
                        if (a.Succeeded)
                        {
                            Logger.LogInformation($"El usuario [{request.userName}] ha atualizado su perfil en el sistema.");
                            return Ok();
                        }
                        else
                        {
                            Logger.LogError(a.Errors.ToList()[0].Description);
                            return BadRequest(a.Errors.ToList()[0].Description);
                        }
                    }
                    else
                    {
                        Logger.LogError($"El usuario [{request.userName}] ha proporiconado una contraseña incorrecta.");
                        return BadRequest("Incorrect Password");
                    }
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                    return BadRequest(e.Message);
                }
            }
            var b = ModelState.GetEnumerator();
            b.MoveNext();
            var error = b.Current.Value.Errors.GetEnumerator();
            error.MoveNext();
            Logger.LogError(error.Current.ErrorMessage);
            return BadRequest(error.Current.ErrorMessage);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                var user = User.Identity.Name;
                await SignInManager.SignOutAsync();
                Logger.LogInformation($"El usuario [{user}] ha salido del sistema.");
                return Ok();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost("get-user")]
        public async Task<IActionResult> GetUserAsync()
        {
            try
            {
                var username = User.Identity.Name;
                var user = await UserManager.FindByNameAsync(username);
                if (user.Role == Roles.Partner)
                {
                    var partner = AuthRepository.GetPartnerById(user.Id);
                    Logger.LogInformation($"El usuario [{username}] ha solicitado su información.");
                    return Ok(partner);
                }
                else
                {
                    Logger.LogInformation($"El usuario [{username}] ha solicitado su información.");
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
