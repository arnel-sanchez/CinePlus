using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CinePlus.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAuthRepository authRepository,
            ILogger<IndexModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _authRepository = authRepository;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [DataType(DataType.Text)]
            public string Code { get; set; }

            public double Points { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            if(user.Role==Roles.Partner)
            {
                Input = new InputModel
                {
                    PhoneNumber = phoneNumber,
                    Name = user.Name,
                    LastName = user.LastName,
                    Code = _authRepository.GetPartnerById(user.Id).Code
                };
            }
            else
            {
                Input = new InputModel
                {
                    PhoneNumber = phoneNumber,
                    Name = user.Name,
                    LastName = user.LastName
                };
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogError("No existe usuario con sesión iniciada.");
                return NotFound("No existe usuario con sesión iniciada.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogError("No existe usuario con sesión iniciada.");
                return NotFound("No existe usuario con sesión iniciada.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            user.LastName = Input.LastName;
            user.Name = Input.Name;
            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded)
            {
                _logger.LogError("Error inesperado intentando actualizar la información del usuario.");
                StatusMessage = "Error inesperado intentando actualizar la información del usuario.";
                return RedirectToPage();
            }
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    _logger.LogError("Error inesperado intentando modificar su número de teléfono.");
                    StatusMessage = "Error inesperado intentando modificar su número de teléfono.";
                    return RedirectToPage();
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation($"El usuario [{user.UserName}] ha modificado su perfil.");
            StatusMessage = "Su perfil ha sido modificado satisfactoriamente.";
            return RedirectToPage();
        }
    }
}
