using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMUG.Data;
using NMUG.Models;

namespace NMUG.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirectorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Directors
        public async Task<IActionResult> Index(int? id, int? TitleID)
        {
            return View(await _context.Directors
                .Include(t => t.TitleID)
                .ToListAsync());
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.ID == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Email,FirstName,LastName")] Directors directors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directors);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(directors);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.ID == id);
            if (directors == null)
            {
                return NotFound();
            }
            return View(directors);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Email,FirstName,LastName")] Directors directors)
        {
            if (id != directors.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorsExists(directors.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(directors);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.ID == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directors = await _context.Directors.SingleOrDefaultAsync(m => m.ID == id);
            _context.Directors.Remove(directors);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DirectorsExists(int id)
        {
            return _context.Directors.Any(e => e.ID == id);
        }
    }
}
