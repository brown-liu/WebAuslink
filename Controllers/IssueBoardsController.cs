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
{[Authorize]
    public class IssueBoardsController : Controller
    {
        private readonly WebAuslinkContext _context;

        public IssueBoardsController(WebAuslinkContext context)
        {
            _context = context;
        }

        // GET: IssueBoards
        public async Task<IActionResult> Index_full()
        {
            return View(await _context.IssueBoard.ToListAsync());
        }

        public async Task<IActionResult> Index()
        {
            var issueList = await _context.IssueBoard.ToListAsync();
            var UnsolvedIssueList = issueList.Where(m=>m.IfIssueIsSolved==false);
            return View(UnsolvedIssueList);
        }

        // GET: IssueBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueBoard = await _context.IssueBoard
                .FirstOrDefaultAsync(m => m.id == id);
            if (issueBoard == null)
            {
                return NotFound();
            }

            return View(issueBoard);
        }

        // GET: IssueBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IssueBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,IssueTitle,WhoRaisedThisIssue,issueDescription,IfIssueIsSolved,WhoSolvedIssue")] IssueBoard issueBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issueBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issueBoard);
        }

        // GET: IssueBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueBoard = await _context.IssueBoard.FindAsync(id);
            if (issueBoard == null)
            {
                return NotFound();
            }
            return View(issueBoard);
        }

        // POST: IssueBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,IssueTitle,WhoRaisedThisIssue,issueDescription,IfIssueIsSolved,WhoSolvedIssue")] IssueBoard issueBoard)
        {
            if (id != issueBoard.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issueBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueBoardExists(issueBoard.id))
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
            return View(issueBoard);
        }

        // GET: IssueBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueBoard = await _context.IssueBoard
                .FirstOrDefaultAsync(m => m.id == id);
            if (issueBoard == null)
            {
                return NotFound();
            }

            return View(issueBoard);
        }

        // POST: IssueBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issueBoard = await _context.IssueBoard.FindAsync(id);
            _context.IssueBoard.Remove(issueBoard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueBoardExists(int id)
        {
            return _context.IssueBoard.Any(e => e.id == id);
        }
    }
}
