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
        public async Task<IActionResult> Index()
        {
            return View(await _context.SeaContainer.ToListAsync());
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

            //var ClientModel = _client;
            return View();
        }




        // POST: SeaContainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContainerNumber,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,Reference,IfEnteredCartonCloud,IfInvoiced,SpecialInstruction")] SeaContainer seaContainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seaContainer);
                
                 await _context.SaveChangesAsync();

    

                return RedirectToAction(nameof(Index));
            }
            return View(seaContainer);
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

        // POST: SeaContainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContainerNumber,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,Reference,IfEnteredCartonCloud,IfInvoiced,SpecialInstruction")] SeaContainer seaContainer)
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
