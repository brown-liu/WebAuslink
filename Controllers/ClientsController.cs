using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebAuslink.Data;
using WebAuslink.Models;

namespace WebAuslink.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly WebAuslinkContext _context;

        public ClientsController(WebAuslinkContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index(string SearchStringClient)
        {
            var all_client = await _context.Client.ToListAsync();

            if (!string.IsNullOrEmpty(SearchStringClient))
            {
                var result = all_client.Where(m => m.ClientCompanyName.ToLower().Contains(SearchStringClient.ToLower()));
               
       
                    return View(result);   
            
            }
            return View(all_client);
        }

        public async Task<IActionResult> IndexReadOnly(string SearchStringClient)
        {
            var all_client = await _context.Client.ToListAsync();

            if (!string.IsNullOrEmpty(SearchStringClient))
            {
                var result = all_client.Where(m => m.ClientCompanyName.ToLower().Contains(SearchStringClient.ToLower()));


                return View(result);

            }
            return View(all_client);
        }


        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        public async Task<IActionResult> DetailsReadOnly(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientCompanyName,CartageRate20,CartageRateSingle20,CartageRate40,CartageRateSingle40,CartageFAF,VGM,ATF,MPI,CartageVBS,UnpackM,UnpackP,OtherCharge1,OtherCharge2,OtherCharge3,OtherCharge4,OtherCharge5,OtherCharge6,OtherCharge7,OtherCharge8,ChargePerCBM,ChargePerPLT,ChargePerFullTruckLoad,SpecialCharges1,SpecialCharges2")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientCompanyName,CartageRate20,CartageRateSingle20,CartageRate40,CartageRateSingle40,CartageFAF,VGM,ATF,MPI,CartageVBS,UnpackM,UnpackP,OtherCharge1,OtherCharge2,OtherCharge3,OtherCharge4,OtherCharge5,OtherCharge6,OtherCharge7,OtherCharge8,ChargePerCBM,ChargePerPLT,ChargePerFullTruckLoad,SpecialCharges1,SpecialCharges2")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }










        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FindAsync(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }




        public async Task<IActionResult> Index_on_hold_status(string SearchStringClient)
        {
            var all_client = await _context.Client.ToListAsync();

            if (!string.IsNullOrEmpty(SearchStringClient))
            {
                var result = all_client.Where(m => m.ClientCompanyName.ToLower().Contains(SearchStringClient.ToLower()));
                return View(result);
            }


            return View(all_client);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOnHoldStatus(int id,[ Bind("Id", "ClientCompanyName", "IfAccountIsOnHold")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {

                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DBConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    
                }return View(client);
            }
            return RedirectToAction(nameof(Index_on_hold_status));
        }

        public async Task<IActionResult> EditOnHoldStatus(int? id)
            
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }


      


        // collect from ajax to display if certain client is on hold


    }
}
