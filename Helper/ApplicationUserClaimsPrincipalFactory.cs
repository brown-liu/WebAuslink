using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAuslink.Helper
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser,IdentityRole>
    {

        public ApplicationUserClaimsPrincipalFactory(UserManager<IdentityUser> um,
           RoleManager<IdentityRole> rm,IOptions<IdentityOptions> options ):base(um,rm,options)
        {

        }
       protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await  base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("UserFirstName",user.UserName));
            return identity;
        }
    }
    
  
}
