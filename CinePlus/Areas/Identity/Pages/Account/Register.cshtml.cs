﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using CinePlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using CinePlus.DataAccess;

namespace CinePlus.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IAuthRepository _authRepository;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IAuthRepository authRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _authRepository = authRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Role")]
            public bool Role { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "La {0} debe tener entre {2} y {1} caracteres de longitud.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                string role = "";
                if (Input.Role)
                    role = Roles.Partner;
                else
                    role = Roles.Client;
                var user = new User { UserName = Input.UserName, LastName = Input.LastName, Name = Input.Name, Role = role, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if(Input.Role)
                    {
                        var random = new Random();
                        var partner = new Partner
                        {
                            Id = Guid.NewGuid().ToString(),
                            Points = 0,
                            User = user,
                            Code = random.Next(100000, 1000000).ToString()
                        };
                        _authRepository.CreatePartner(partner);
                    }
                    await _userManager.AddToRoleAsync(user, role);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = "https://localhost:5001/Identity/Account/ConfirmEmail?userId=" + user.Id + "&code=" + code;

                    await _emailSender.SendEmailAsync(Input.Email, "Confirme su Email",
                        $"Por favor, confirme su cuenta haciendo click aquí: <a href='{callbackUrl}'>Confirmar Cuenta</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        _logger.LogWarning($"El usuario [{Input.UserName}] necesita confirmar su cuenta.");
                        return RedirectToPage("Confirmación de Registro", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        _logger.LogInformation($"El usuario [{Input.UserName}] se ha registrado en el sistema.");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    _logger.LogError(error.Description);
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            foreach (var error in ModelState.Values)
            {
                foreach (var item in error.Errors)
                {
                    _logger.LogError(item.ErrorMessage);
                }
            }
            return Page();
        }
    }
}
