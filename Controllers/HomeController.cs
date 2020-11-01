using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
                var Temp =  _context.Client;
                var namelist=Temp.Where(m => m.IfAccountIsOnHold);
            ViewData["OnHoldList"] = namelist;
            if (!namelist.Any())
            { 
            ViewData["IfNone"] = "none";
            }

            var all_list = await _context.DailyToDoList.ToListAsync();


            var TempToDoList = from s in all_list
                       where (s.today.Date - DateTime.Today.Date).Days <= 2 && (s.today.Date - DateTime.Today.Date).Days >= 0
                       select s;
            ViewBag.TodayList = TempToDoList.OrderBy(m => m.today);

            var containerList = _context.SeaContainer;

            var issues = _context.IssueBoard.ToList();

            List<SeaContainer> ToYardCurrentWeekVBS = new List<SeaContainer>();

            List<SeaContainer> CartageOnlyCurrentWeekVBS = new List<SeaContainer>();
            
                List<SeaContainer> ToYardCurrentWeekVBSCompleted = new List<SeaContainer>();
            List<SeaContainer> CartageOnlyCurrentWeekOFETA = new List<SeaContainer>();

            List<SeaContainer> ToYardCurrentWeekOFETA = new List<SeaContainer>();

            List<SeaContainer> ToYardCurrentMonthOFETA = new List<SeaContainer>();

            List<SeaContainer> CartageOnlyCurrentMonthOFETACompleted = new List<SeaContainer>();

            List<SeaContainer> ToyardCurrentMonthOFETACompleted = new List<SeaContainer>();


            List<SeaContainer> CartageOnlyCurrentWeekOFETACompleted = new List<SeaContainer>();

            List<SeaContainer> ToYardCurrentWeekOFETACompleted = new List<SeaContainer>();


            foreach (SeaContainer container in containerList)
            {
                //current week by VBS
                if ((GetWeekNumber(container.TimeToYard.GetValueOrDefault()) == GetWeekNumber(DateTime.Now)))
                { 
                
                if (container.IfCartageOnly == true)
                {
                        //cartage only + vbsconfirm + current week
                    CartageOnlyCurrentWeekVBS.Add(container);


                }
                else 
                {
                        //To yard Inbound + vbsconfirm + current week
                        ToYardCurrentWeekVBS.Add(container);
                        if (container.JobFullyCompleted)
                        {
                            ToYardCurrentWeekVBSCompleted.Add(container);

                        }
                }
                
                }
                //current week by oceanfreight
                if ((GetWeekNumber(container.OceanFreightETA) == GetWeekNumber(DateTime.Now)))
                {

                    if (container.IfCartageOnly == true)
                    {
                        //cartage only + ETA + current week
                        CartageOnlyCurrentWeekOFETA.Add(container);
                        if (container.JobFullyCompleted)
                        { //cartage only + ETA + current week + Completed
                            CartageOnlyCurrentWeekOFETACompleted.Add(container);
                        }
                       

                    }
                    else
                    { //To yard Inbound + current week + ETA + Completed
                        ToYardCurrentWeekOFETA.Add(container);
                        if(!container.JobFullyCompleted)
                        {
                            ToYardCurrentWeekOFETACompleted.Add(container);
                        }

                    }

                }


                // current month by o.f eta
                if (container.OceanFreightETA.Month == DateTime.Now.Month)

                {
                    ToYardCurrentMonthOFETA.Add(container);

                    if (container.JobFullyCompleted )
                    {
                        if (container.IfCartageOnly)
                        {
    //current month + o.f eta + completed + cartageOnly
                        CartageOnlyCurrentMonthOFETACompleted.Add(container);
                        }
                        else
                        {  //current month + o.f eta + completed + toyard
                            ToyardCurrentMonthOFETACompleted.Add(container);

                        }
                    
                    }

                }
            
            
            }


            int countIssues = issues.Count(m => m.IfIssueIsSolved == false);

            ViewBag.ToYardCurrentWeekVBSCompleted = ToYardCurrentWeekVBSCompleted.Count;

            ViewBag.ToYardCurrentWeekVBS = ToYardCurrentWeekVBS.Count;

            ViewBag.CartageOnlyCurrentWeekVBS = ToYardCurrentWeekVBS.Count;


            ViewBag.CartageOnlyCurrentWeekOFETA = CartageOnlyCurrentWeekOFETA.Count;

            ViewBag.ToYardCurrentWeekOFETA = ToYardCurrentWeekOFETA.Count;


            ViewBag.CartageOnlyCurrentMonthOFETACompleted = CartageOnlyCurrentMonthOFETACompleted.Count;

            ViewBag.ToyardCurrentMonthOFETACompleted = ToyardCurrentMonthOFETACompleted.Count;


            ViewBag.CartageOnlyCurrentWeekOFETACompleted = CartageOnlyCurrentWeekOFETACompleted.Count;

            ViewBag.ToYardCurrentWeekOFETACompleted = ToYardCurrentWeekOFETACompleted.Count;

            ViewBag.ToYardCurrentMonthOFETA = ToYardCurrentMonthOFETA.Count();

            return View();


        }

        public static int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
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

