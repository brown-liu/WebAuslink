
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;


namespace WebAuslink.Data
{
    public class DbInitializer : IDbInitializer
    {

        private readonly WebAuslinkContext _context;
        private readonly UserManager<IdentityUser>  _userManager;


        public DbInitializer(WebAuslinkContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        void IDbInitializer.Initialize()
        {
            

            if (_context.Database.GetPendingMigrations().Count() > 0)
            {
                _context.Database.Migrate();
            }

            if (_context.Users.Any()) return;

            _userManager.CreateAsync(new IdentityUser
            {

                Email = "brown@auslink.co.nz",
                UserName = "brown@auslink.co.nz",
                EmailConfirmed = true

            }, "brown@auslink.co.nz").GetAwaiter().GetResult();
          
            }

    }
}
