﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAuslink.Data;
using WebAuslink.Models;

namespace WebAuslink.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebAuslinkContext _context;

        public HomeController(ILogger<HomeController> logger,WebAuslinkContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return  View( await _context.SeaContainer.ToListAsync());
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> containerDetails(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var result = await _context.SeaContainer.FirstOrDefaultAsync(m => m.ContainerNumber==Id);
        if (result == null)
            {
                return NotFound();
            }


            return View(result);
        }



    }
}
