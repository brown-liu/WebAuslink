using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuslink.Data;
using Microsoft.AspNetCore.Authorization;



namespace WebAuslink.Models
{
    [Authorize]
    public class DailyToDoListsController : Controller
    {
        private readonly WebAuslinkContext _context;

        public DailyToDoListsController(WebAuslinkContext context)
        {
            _context = context;
        }

        // GET: DailyToDoLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.DailyToDoList.ToListAsync());
        }

        // GET: DailyToDoLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyToDoList = await _context.DailyToDoList
                .FirstOrDefaultAsync(m => m.id == id);
            if (dailyToDoList == null)
            {
                return NotFound();
            }

            return View(dailyToDoList);
        }

        // GET: DailyToDoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyToDoLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,today,MorningJob,AfternoonJob,ExtraWork")] DailyToDoList dailyToDoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyToDoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyToDoList);
        }

        // GET: DailyToDoLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyToDoList = await _context.DailyToDoList.FindAsync(id);
            if (dailyToDoList == null)
            {
                return NotFound();
            }
            return View(dailyToDoList);
        }

        // POST: DailyToDoLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,today,MorningJob,AfternoonJob,ExtraWork")] DailyToDoList dailyToDoList)
        {
            if (id != dailyToDoList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyToDoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyToDoListExists(dailyToDoList.id))
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
            return View(dailyToDoList);
        }

        // GET: DailyToDoLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyToDoList = await _context.DailyToDoList
                .FirstOrDefaultAsync(m => m.id == id);
            if (dailyToDoList == null)
            {
                return NotFound();
            }

            return View(dailyToDoList);
        }

        // POST: DailyToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyToDoList = await _context.DailyToDoList.FindAsync(id);
            _context.DailyToDoList.Remove(dailyToDoList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyToDoListExists(int id)
        {
            return _context.DailyToDoList.Any(e => e.id == id);
        }
    }
}
