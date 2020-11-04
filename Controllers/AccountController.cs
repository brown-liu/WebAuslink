using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAuslink.Models;
using WebAuslink.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using log4net.Core;
using Microsoft.Extensions.Logging;

namespace WebAuslink.Controllers
    
{
    [Authorize]
    public class AccountController : Controller

    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountRepo _accountRepo;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IAccountRepo accountRepo, ILogger<AccountController> log,RoleManager<IdentityRole> roleManager)

        {
            _roleManager = roleManager;
               _accountRepo = accountRepo;
            _logger = log;
        }

        //[Authorize(Roles = "Administrator")]
        [Route("signup")]
        public IActionResult SignUp()
        {
            this._logger.LogInformation("signUP");
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
            _logger.LogInformation("Log Out");

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
