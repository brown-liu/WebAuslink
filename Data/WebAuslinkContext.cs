using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAuslink.Models;

namespace WebAuslink.Data
{
    public class WebAuslinkContext : IdentityDbContext
    {
        public WebAuslinkContext (DbContextOptions<WebAuslinkContext> options)
            : base(options)
        {
        }
        public DbSet<WebAuslink.Models.User> User { get; set; }
        public DbSet<WebAuslink.Models.LogInUserModel> LogInUserModel { get; set; }
        public DbSet<WebAuslink.Models.ChangePassword> ChangePassword { get; set; }
        public DbSet<WebAuslink.Models.SeaContainer> SeaContainer { get; set; }
        public DbSet<WebAuslink.Models.Client> Client { get; set; }
        public DbSet<WebAuslink.Models.DailyToDoList> DailyToDoList { get; set; }
        public DbSet<WebAuslink.Models.IssueBoard> IssueBoard { get; set; }

    }
}
