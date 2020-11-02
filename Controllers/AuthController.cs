using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAuslink.Models;
using WebAuslink.Repo;

namespace WebAuslink.Controllers
{
   
    public class AuthController : Controller
    {
        private readonly IAccountRepo _acc;
      

        public AuthController(IAccountRepo acc)
        {
            _acc = acc;
       
        }



        [Route("login")]
        public IActionResult LogIn()
        {


            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LogInUserModel loginusermodel)
        {
            if (ModelState.IsValid)
            {

                var result = await _acc.PasswordSignInasync(loginusermodel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid credentials");
            }

            return View(loginusermodel);
        }
    }
}
