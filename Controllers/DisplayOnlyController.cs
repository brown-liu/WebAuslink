using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebAuslink.Data;
using WebAuslink.Migrations;

namespace WebAuslink.Controllers
{
    [Authorize]
    public class DisplayOnlyController:Controller
    {

        public readonly WebAuslinkContext _context;

        public DisplayOnlyController(WebAuslinkContext context)
        {

            _context = context;

        }


        public IActionResult CheckList()
        {
            return View();
        }

        public IActionResult sop_auslink()
        {
            var temp = _context.FileLoader;
            ViewBag.SOPs = temp.Where(m => m.Classification == "auslink");

            return View();
        }

        public IActionResult auslink_structure()

        {
            return View();
        }
        public IActionResult sop_byclient()
        {
            var SOPfiles = _context.FileLoader;
            ViewBag.SOPs = SOPfiles.Where(m => m.Classification == "client");

            return View();
        }

    }


}
