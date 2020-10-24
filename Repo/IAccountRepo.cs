using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebAuslink.Models;

namespace WebAuslink.Repo
{
    public interface IAccountRepo
    {
        Task<IdentityResult> CreateUserAsync(User user);
        Task<SignInResult> PasswordSignInasync(LogInUserModel usermodel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePassword model);
    }
}