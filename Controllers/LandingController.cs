using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAuslink.Controllers
{
    [Authorize]
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
