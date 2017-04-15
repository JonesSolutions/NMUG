using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMUG.Data;
using NMUG.Models;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Networking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace NMUG.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public DirectorsController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        // GET: Directors
        public async Task<IActionResult> Index(int? id, int? TitleID)
        {
            if (!_context.Directors.Any())
            {
                return View(_context.Directors.ToListAsync());
            }
            return View(await _context.Directors
                .Include(t => t.title)
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
            //Directors director = _context.Directors.Include(d => d.Image).SingleOrDefault(d => d.ID == id);
            if (directors == null)
            {
                return NotFound();
            }

            return View(directors);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            ViewData["TitleID"] = new SelectList(_context.Title, "TitleID", "jobTitle");
            return View();
        }

        


        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Email,FirstName,LastName,TitleID")] Directors directors)/* , ICollection<IFormFile> files)*/
        {
            if (ModelState.IsValid)
            {
                //var profilepics = Path.Combine(_environment.WebRootPath, "profilepics");
                //foreach (var file in files)
                //{
                //    if (file.Length > 0)
                //    {
                //        using (var fileStream = new FileStream(Path.Combine(profilepics, file.FileName), FileMode.Create))
                //        {
                //            await file.CopyToAsync(fileStream);
                //            directors.Image = file.FileName;
                //        }
                //    }
                //}



                _context.Add(directors);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
}
ViewData["TitleID"] = new SelectList(_context.Title, "TitleID", "jobTitle", directors.TitleID);
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
