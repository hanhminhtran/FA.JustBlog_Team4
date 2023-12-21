using FA.JustBlog.Core;
using FA.JustBlog.Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Website.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly UserManager<Core.User> _userManager;
        private readonly SignInManager<Core.User> _signInManager;
        private RoleManager<IdentityRole> _roleManager
        {
            get;
        }
        public AuthenticateController(UserManager<Core.User> userManager, SignInManager<Core.User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVm signIn, string ReturnUrl)
        {
            Core.User user;
            if (signIn.Email.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(signIn.Email);
            }
            else
            {
                user = null;
            }
            if (user == null)
            {
                ModelState.AddModelError("", "Login failed");
                return View(signIn);
            }
            var result = await
            _signInManager.PasswordSignInAsync(user, signIn.Password, true, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login failed.");
                return View(signIn);
            }
            if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
            return RedirectToAction("Index", "Team", new
            {
                area = "admin"
            });
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm register)
        {
            if (!ModelState.IsValid) return View();
            Core.User newUser = new Core.User
            {
                Email = register.Email,
                Username = register.Username
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return RedirectToAction("SignIn");
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }
}