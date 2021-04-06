using Fiction.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                var createTask = _userManager.CreateAsync(user, model.Password);

                if (createTask.Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in createTask.Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AccountLoginViewModel model, string returnURL)
        {
            if (ModelState.IsValid)
            {
                Task<Microsoft.AspNetCore.Identity.SignInResult> signInTask;

                if (model.SaveSession)
                {
                    signInTask = _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
                } else
                {
                    signInTask = _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                }

                if (signInTask.Result.Succeeded)
                {
                    if (returnURL is not null)
                    {
                        return Redirect(returnURL);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect username or password");
            }

            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
