using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CinePlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace CinePlus.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailChangeModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<ConfirmEmailChangeModel> _logger;

        public ConfirmEmailChangeModel(UserManager<User> userManager, SignInManager<User> signInManager, Logger<ConfirmEmailChangeModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string email, string code)
        {
            if (userId == null || email == null || code == null)
            {
                if(userId==null)
                {
                    _logger.LogError("UserId no puede ser null.");
                }
                else if(email==null)
                {
                    _logger.LogError("Email no puede ser null.");
                }
                else
                {
                    _logger.LogError("Code no puede ser null.");
                }
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"No existe usuario con ID [{userId}].");
                return NotFound($"No existe usuario con ID [{userId}].");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                StatusMessage = "Error modificando el Email.";
                _logger.LogError("Error modificando el Email.");
                return Page();
            }

            // In our UI email and user name are one and the same, so when we update the email
            // we need to update the user name.
            var setUserNameResult = await _userManager.SetUserNameAsync(user, email);
            if (!setUserNameResult.Succeeded)
            {
                StatusMessage = "Error modificando el nombre de usuario.";
                _logger.LogError("Error modificando el nombre de usuario.");
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Email modificado satisfactoriamente.";
            _logger.LogInformation("Email modificado satisfactoriamente.");
            return Page();
        }
    }
}
