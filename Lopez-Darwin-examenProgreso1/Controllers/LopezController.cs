using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lopez_Darwin_examenProgreso1.Data;
using Lopez_Darwin_examenProgreso1.Models;

namespace Lopez_Darwin_examenProgreso1.Controllers
{
    public class LopezController : Controller
    {
        private readonly Lopez_Darwin_examenProgreso1Context _context;

        public LopezController(Lopez_Darwin_examenProgreso1Context context)
        {
            _context = context;
        }

        // GET: Lopez
        public async Task<IActionResult> Index()
        {
            var lopez_Darwin_examenProgreso1Context = _context.Lopez.Include(l => l.celulares);
            return View(await lopez_Darwin_examenProgreso1Context.ToListAsync());
        }

        // GET: Lopez/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopez = await _context.Lopez
                .Include(l => l.celulares)
                .FirstOrDefaultAsync(m => m.nombre == id);
            if (lopez == null)
            {
                return NotFound();
            }

            return View(lopez);
        }

        // GET: Lopez/Create
        public IActionResult Create()
        {
            ViewData["celularesmodelo"] = new SelectList(_context.Celular, "modelo", "modelo");
            return View();
        }

        // POST: Lopez/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nombre,edad,EsEcuatoriano,FechaNacimiento,estatura,celularesmodelo")] Lopez lopez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["celularesmodelo"] = new SelectList(_context.Celular, "modelo", "modelo", lopez.celularesmodelo);
            return View(lopez);
        }

        // GET: Lopez/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopez = await _context.Lopez.FindAsync(id);
            if (lopez == null)
            {
                return NotFound();
            }
            ViewData["celularesmodelo"] = new SelectList(_context.Celular, "modelo", "modelo", lopez.celularesmodelo);
            return View(lopez);
        }

        // POST: Lopez/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nombre,edad,EsEcuatoriano,FechaNacimiento,estatura,celularesmodelo")] Lopez lopez)
        {
            if (id != lopez.nombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopezExists(lopez.nombre))
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
            ViewData["celularesmodelo"] = new SelectList(_context.Celular, "modelo", "modelo", lopez.celularesmodelo);
            return View(lopez);
        }

        // GET: Lopez/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopez = await _context.Lopez
                .Include(l => l.celulares)
                .FirstOrDefaultAsync(m => m.nombre == id);
            if (lopez == null)
            {
                return NotFound();
            }

            return View(lopez);
        }

        // POST: Lopez/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lopez = await _context.Lopez.FindAsync(id);
            if (lopez != null)
            {
                _context.Lopez.Remove(lopez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopezExists(string id)
        {
            return _context.Lopez.Any(e => e.nombre == id);
        }
    }
}
