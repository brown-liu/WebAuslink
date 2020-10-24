using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuslink.Models;
using WebAuslink.Services;




namespace WebAuslink.Repo
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserservice _userService;
        public AccountRepo(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,
            IUserservice userservice)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userservice;
        }
        public async Task<IdentityResult> CreateUserAsync(User userModel)
        {
            var user = new IdentityUser()
            {
                
                Email = userModel.Email,
                UserName=userModel.Email,

            
            };
           var result =  await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInasync(LogInUserModel usermodel)
        {
           var result =  await _signInManager.PasswordSignInAsync(usermodel.Email,usermodel.Password,usermodel.RememberMe,false);
            return result;
        }


        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
         

        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePassword model)
        {
            var UserID = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(UserID);
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.ConfirmNewPassword);
            return result;
        
        }
    }
}
