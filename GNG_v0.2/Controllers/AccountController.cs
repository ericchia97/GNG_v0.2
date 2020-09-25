using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNG_v0._2.Models;
using GNG_v0._2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GNG_v0._2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public ViewResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(User model)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Name, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                //User newUser = _userRepository.Register(model);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
            }
            return View(model);
        }

        [HttpGet]
        public ViewResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel loginModel)
        {

            if (ModelState.IsValid)
            {
                var userEmail = await userManager.FindByEmailAsync(loginModel.Email);
                var result = await signInManager.PasswordSignInAsync(userEmail, loginModel.Password, loginModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }

                ModelState.AddModelError("", "Your username or password is not matched.");
            }
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
    }
}
