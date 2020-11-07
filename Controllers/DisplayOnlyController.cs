using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebAuslink.Data;

namespace WebAuslink.Controllers
{
    [Authorize]
    public class DisplayOnlyController : Controller
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
        public IActionResult site_map()
        {

            return View();
        }


        async public Task<IActionResult> auto_display()
        {
            var all_container = await _context.SeaContainer.ToListAsync();
            var all_plan = await _context.DailyToDoList.ToListAsync();
            var all_client = await _context.Client.ToListAsync();
            var InboundThisWeek = from s in all_container
                                  where s.IfCartageOnly == false
                                  &&
                                  HomeController.GetWeekNumber(s.TimeToYard.GetValueOrDefault()) == HomeController.GetWeekNumber(DateTime.Now)
                                  && s.JobFullyCompleted == false
                                  orderby s.TimeToYard
                                  select s;

            var AllContainerThisMonth = from s in all_container
                                        where s.OceanFreightETA.Month == DateTime.Now.Month
                                        orderby s.OceanFreightETA
                                        select s;

            var JobPlan = from j in all_plan
                          where j.today.Day == DateTime.Now.Day
                          select j;

            var OnHold = from c in all_client
                         where c.IfAccountIsOnHold == true
                         select c;


            ViewBag.InboundThisWeek = InboundThisWeek;
            ViewBag.ThisMonth = AllContainerThisMonth;
            ViewBag.PlanToday = JobPlan;
            ViewBag.ClientOnHOld =OnHold;
            return View();

        }

     
            


    }


}
