using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAuslink.Models;
using WebAuslink.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;




namespace WebAuslink.Controllers
    
{
    [Authorize]
    public class AccountController : Controller

    {
        private readonly IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)

        {
            _accountRepo = accountRepo;
        }


        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepo.CreateUserAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(user);
                }
                ModelState.Clear();
            }
            return View();
        }


       

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepo.SignOutAsync();
            return RedirectToAction("Index","Home");


        }

        [Route("change-password")]
        public  IActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var result = await  _accountRepo.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            } 

            return View(model);
        }

        



    }
}
