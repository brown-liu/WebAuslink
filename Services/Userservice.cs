using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAuslink.Services
{
    public class Userservice : IUserservice
    {
        private readonly IHttpContextAccessor _httpContext;

        public Userservice(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAuthenticated()
        {

            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }


    }
}
