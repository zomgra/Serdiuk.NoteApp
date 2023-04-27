using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.NoteApp.IdentityServer.Models;

namespace Serdiuk.NoteApp.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var res = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");

                return View(model);
            }
            return Redirect(model.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Username,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect(model.ReturnUrl);
        }
    }
}
