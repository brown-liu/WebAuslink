using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebAuslink.Data;
using WebAuslink.Models;


namespace WebAuslink.Controllers
{
    public class FileLoadersController : Controller
    {
        private readonly WebAuslinkContext _context;

        public FileLoadersController(WebAuslinkContext context)
        {
            _context = context;
        }

        // GET: FileLoaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileLoader.ToListAsync());
        }

        // GET: FileLoaders/Details/5


     
        // GET: FileLoaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileLoader = await _context.FileLoader
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileLoader == null)
            {
                return NotFound();
            }

            return View(fileLoader);
        }


        public void DeleteFileFromServer(string path)
        {
            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
          
        }



        // POST: FileLoaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileLoader = await _context.FileLoader.FindAsync(id);

            DeleteFileFromServer(fileLoader.pdfUrl);
            _context.FileLoader.Remove(fileLoader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileLoaderExists(int id)
        {
            return _context.FileLoader.Any(e => e.Id == id);
        }
    }
}
