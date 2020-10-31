using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuslink.Data;
using WebAuslink.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;


namespace WebAuslink.Controllers
{[Authorize]
    public class SeaContainersController : Controller
    {
        private readonly WebAuslinkContext _context;

        //private readonly Client _client;

        public SeaContainersController(WebAuslinkContext context)
        {
            _context = context;
         
        }

        // GET: SeaContainers
        //public async Task<IActionResult> Index(int pageNumber=1)
        //{



        //    return View(await Paging<SeaContainer>.CreateAsync( _context.SeaContainer, pageNumber,20));
        //}


        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string SearchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["YardSortParm"] = String.IsNullOrEmpty(sortOrder) ? "T2Yard_desc" : "";
            ViewData["OFSortParm"] = sortOrder == "ofeta" ? "ofeta_desc" : "ofeta";

            if (SearchString != null)
            {
                pageNumber = 1;
            }
            else {
                SearchString = currentFilter;
            }
            ViewData["CurrentFilter"] = currentFilter;
            var CTNS = from c in _context.SeaContainer select c;

            if (!String.IsNullOrEmpty(SearchString))
            {
                CTNS = CTNS.Where(s => s.ContainerNumber.Contains(SearchString) || s.ClientCompanyName.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "T2Yard_desc":
                    CTNS = CTNS.OrderBy(c => c.TimeToYard);
                    break;
                case "ofeta_desc":
                    CTNS = CTNS.OrderBy(c => c.OceanFreightETA);
                    break;
                case "ofeta":
                    CTNS = CTNS.OrderByDescending(c => c.OceanFreightETA);
                    break;
                default:
                    CTNS = CTNS.OrderByDescending(c => c.TimeToYard);
                    break;


            }
            return View(await Paging<SeaContainer>.CreateAsync(CTNS.AsNoTracking(), pageNumber??1, 20));


        }

        public async Task<IActionResult> Index_Cartage_Only(
            string sortOrder,
            string currentFilter,
            string SearchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["YardSortParm"] = String.IsNullOrEmpty(sortOrder) ? "T2Yard_desc" : "";
            ViewData["OFSortParm"] = sortOrder == "ofeta" ? "ofeta_desc" : "ofeta";

            if (SearchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            ViewData["CurrentFilter"] = currentFilter;
            var CTNS = from c in _context.SeaContainer 
                       where c.IfCartageOnly == true &&c.JobFullyCompleted==false
                       select c
                       ;

            if (!String.IsNullOrEmpty(SearchString))
            {
                CTNS = CTNS.Where(s => s.ContainerNumber.Contains(SearchString) || s.ClientCompanyName.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "T2Yard_desc":
                    CTNS = CTNS.OrderBy(c => c.TimeToYard);
                    break;
                case "ofeta_desc":
                    CTNS = CTNS.OrderBy(c => c.OceanFreightETA);
                    break;
                case "ofeta":
                    CTNS = CTNS.OrderByDescending(c => c.OceanFreightETA);
                    break;
                default:
                    CTNS = CTNS.OrderByDescending(c => c.TimeToYard);
                    break;


            }
            return View(await Paging<SeaContainer>.CreateAsync(CTNS.AsNoTracking(), pageNumber ?? 1, 20));


        }



        public async Task<IActionResult> Index_Yard_Inbounds(
            string sortOrder,
            string currentFilter,
            string SearchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["YardSortParm"] = String.IsNullOrEmpty(sortOrder) ? "T2Yard_desc" : "";
            ViewData["OFSortParm"] = sortOrder == "ofeta" ? "ofeta_desc" : "ofeta";

            if (SearchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            ViewData["CurrentFilter"] = currentFilter;
            var CTNS = from c in _context.SeaContainer
                       where c.IfCartageOnly==false &&c.JobFullyCompleted==false
                       select c;

            if (!String.IsNullOrEmpty(SearchString))
            {
                CTNS = CTNS.Where(s => s.ContainerNumber.Contains(SearchString) || s.ClientCompanyName.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "T2Yard_desc":
                    CTNS = CTNS.OrderBy(c => c.TimeToYard);
                    break;
                case "ofeta_desc":
                    CTNS = CTNS.OrderBy(c => c.OceanFreightETA);
                    break;
                case "ofeta":
                    CTNS = CTNS.OrderByDescending(c => c.OceanFreightETA);
                    break;
                default:
                    CTNS = CTNS.OrderByDescending(c => c.TimeToYard);
                    break;


            }
            return View(await Paging<SeaContainer>.CreateAsync(CTNS.AsNoTracking(), pageNumber ?? 1, 20));


        }



        // GET: SeaContainers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seaContainer = await _context.SeaContainer
                .FirstOrDefaultAsync(m => m.ContainerNumber == id);
            if (seaContainer == null)
            {
                return NotFound();
            }

            return View(seaContainer);
        }


        [AcceptVerbs("GET", "POST")]

        public IActionResult Verify_Container_Number(string containerNumber)
        {
            foreach (var item in _context.SeaContainer)
            {
                if (item.ContainerNumber == containerNumber)
                {

                    return Json($"Container # {containerNumber} already exists");
                        
                }
                
            }
            return Json("Please enter container Number carefully!");

        }


        // GET: SeaContainers/Create
        public IActionResult Create()
        {
            
            List<string> nameList= new List<string>();
           var ClientList = _context.Client.ToList();
            if (ClientList != null)
            { 
            foreach (var client in ClientList)
            {
                nameList.Add(client.ClientCompanyName);
            }
            
            }

            ViewBag.ClientList = nameList;
            ViewBag.YardList = new List<string>{"East Tamaki","Mt Wellington","Others (Cartage Job Only)" };

            //var ClientModel = _client;
            return View();
        }




        // POST: SeaContainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContainerNumber,DestinationSite,CCPONumber,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,Reference,IfEnteredCartonCloud,IfInvoiced,SpecialInstruction")] SeaContainer seaContainerTemp)
        {
            //var ContainerList = await _context.SeaContainer.ToListAsync();

            //string ThisContainerNumber = seaContainerTemp.ContainerNumber;

            //foreach (var Con in ContainerList)
            //{
            //    if (true)
            //    {
            //        ModelState.AddModelError("", "Container Number repeated, Please add space + Letter to override!");
            //         return View(seaContainerTemp);
            //    }
            //}   ABOVE CODE IS WRONG SOMEHOW???????????
           

            if (ModelState.IsValid)
            {
                _context.Add(seaContainerTemp);
               ViewBag.IsSuccess = true;
                
                 await _context.SaveChangesAsync();

    

                return RedirectToAction(nameof(Index));
            }
            return View(seaContainerTemp);
        }


     


// GET: SeaContainers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seaContainer = await _context.SeaContainer.FindAsync(id);
            if (seaContainer == null)
            {
                return NotFound();
            }
            return View(seaContainer);
        }
        public async Task<IActionResult> Edit_Yard_Inbounds(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seaContainer = await _context.SeaContainer.FindAsync(id);
            if (seaContainer == null)
            {
                return NotFound();
            }
            return View(seaContainer);
        }

        public async Task<IActionResult> Edit_Cartage_Only(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seaContainer = await _context.SeaContainer.FindAsync(id);
            if (seaContainer == null)
            {
                return NotFound();
            }
            return View(seaContainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Cartage_Only(string id, [Bind("JobFullyCompleted,ContainerNumber,CCPONumber,DestinationSite,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,Reference,IfEnteredCartonCloud,IfInvoiced,SpecialInstruction")] SeaContainer seaContainer)
        {
            if (id != seaContainer.ContainerNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seaContainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeaContainerExists(seaContainer.ContainerNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index_Cartage_Only));
            }
            return View(seaContainer);
        }


        public IActionResult instruciton()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Yard_Inbounds(string id, [Bind("JobFullyCompleted,ContainerNumber,CCPONumber,DestinationSite,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,Reference,IfEnteredCartonCloud,IfInvoiced,SpecialInstruction")] SeaContainer seaContainer)
        {
            if (id != seaContainer.ContainerNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seaContainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeaContainerExists(seaContainer.ContainerNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index_Yard_Inbounds));
            }
            return View(seaContainer);
        }

        // POST: SeaContainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("JobFullyCompleted,ContainerNumber,CCPONumber,DestinationSite,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,Reference,IfEnteredCartonCloud,IfInvoiced,SpecialInstruction")] SeaContainer seaContainer)
        {
            if (id != seaContainer.ContainerNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seaContainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeaContainerExists(seaContainer.ContainerNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(seaContainer);
        }

        // GET: SeaContainers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seaContainer = await _context.SeaContainer
                .FirstOrDefaultAsync(m => m.ContainerNumber == id);
            if (seaContainer == null)
            {
                return NotFound();
            }

            return View(seaContainer);
        }

        // POST: SeaContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var seaContainer = await _context.SeaContainer.FindAsync(id);
            _context.SeaContainer.Remove(seaContainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeaContainerExists(string id)
        {
            return _context.SeaContainer.Any(e => e.ContainerNumber == id);
        }
    }
}
