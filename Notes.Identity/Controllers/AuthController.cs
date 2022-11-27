
using System;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Identity.Models;

namespace Notes.Identity.Controllers
{
    public class AuthController:Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(IIdentityServerInteractionService interactionService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _interactionService = interactionService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var vm = new LoginVm
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            var user = await _userManager.FindByNameAsync(loginVm.Username);
            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "User not found");
                return View(loginVm);
            }

            var result = await _signInManager.PasswordSignInAsync(loginVm.Username,loginVm.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(loginVm.ReturnUrl);
            }
            ModelState.AddModelError(String.Empty, "Login error");
            return View(loginVm);
        }
        
        [HttpGet]
        public  IActionResult Register(string returnUrl)
        {
            var viewModel = new RegistrationVm
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationVm registrationVm)
        {
            if (!ModelState.IsValid)
            {
                return View(registrationVm);
            }

            var user = new AppUser
            {
                UserName = registrationVm.Username
            };
            var result = await _userManager.CreateAsync(user, registrationVm.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(registrationVm.ReturnUrl);
            }
            ModelState.AddModelError(String.Empty, "Error occured!");
            return View(registrationVm);
        }
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}