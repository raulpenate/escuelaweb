#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace escuelaweb.Models
{
    public class NonimaDocenteController : Controller
    {
        private readonly escuelaContext _context;

        public NonimaDocenteController(escuelaContext context)
        {
            _context = context;
        }

        // GET: NonimaDocente
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.NonimaDocentes.Include(n => n.FkIdDocenteNavigation).Include(n => n.FkIdMateriaNavigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: NonimaDocente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonimaDocente = await _context.NonimaDocentes
                .Include(n => n.FkIdDocenteNavigation)
                .Include(n => n.FkIdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdNonimnaDocente == id);
            if (nonimaDocente == null)
            {
                return NotFound();
            }

            return View(nonimaDocente);
        }

        // GET: NonimaDocente/Create
        public IActionResult Create()
        {
            ViewData["FkIdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente");
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria");
            return View();
        }

        // POST: NonimaDocente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNonimnaDocente,FkIdDocente,FkIdGrado,FkIdMateria")] NonimaDocente nonimaDocente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nonimaDocente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", nonimaDocente.FkIdDocente);
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", nonimaDocente.FkIdMateria);
            return View(nonimaDocente);
        }

        // GET: NonimaDocente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonimaDocente = await _context.NonimaDocentes.FindAsync(id);
            if (nonimaDocente == null)
            {
                return NotFound();
            }
            ViewData["FkIdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", nonimaDocente.FkIdDocente);
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", nonimaDocente.FkIdMateria);
            return View(nonimaDocente);
        }

        // POST: NonimaDocente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNonimnaDocente,FkIdDocente,FkIdGrado,FkIdMateria")] NonimaDocente nonimaDocente)
        {
            if (id != nonimaDocente.IdNonimnaDocente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nonimaDocente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NonimaDocenteExists(nonimaDocente.IdNonimnaDocente))
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
            ViewData["FkIdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", nonimaDocente.FkIdDocente);
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", nonimaDocente.FkIdMateria);
            return View(nonimaDocente);
        }

        // GET: NonimaDocente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonimaDocente = await _context.NonimaDocentes
                .Include(n => n.FkIdDocenteNavigation)
                .Include(n => n.FkIdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdNonimnaDocente == id);
            if (nonimaDocente == null)
            {
                return NotFound();
            }

            return View(nonimaDocente);
        }

        // POST: NonimaDocente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nonimaDocente = await _context.NonimaDocentes.FindAsync(id);
            _context.NonimaDocentes.Remove(nonimaDocente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NonimaDocenteExists(int id)
        {
            return _context.NonimaDocentes.Any(e => e.IdNonimnaDocente == id);
        }
    }
}
