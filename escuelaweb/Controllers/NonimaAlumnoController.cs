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
    public class NonimaAlumnoController : Controller
    {
        private readonly escuelaContext _context;

        public NonimaAlumnoController(escuelaContext context)
        {
            _context = context;
        }

        // GET: NonimaAlumno
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.NonimaAlumnos.Include(n => n.FkIdAlumnoNavigation).Include(n => n.FkIdGradoNavigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: NonimaAlumno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonimaAlumno = await _context.NonimaAlumnos
                .Include(n => n.FkIdAlumnoNavigation)
                .Include(n => n.FkIdGradoNavigation)
                .FirstOrDefaultAsync(m => m.IdNonimnaAlumno == id);
            if (nonimaAlumno == null)
            {
                return NotFound();
            }

            return View(nonimaAlumno);
        }

        // GET: NonimaAlumno/Create
        public IActionResult Create()
        {
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno");
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado");
            return View();
        }

        // POST: NonimaAlumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNonimnaAlumno,FkIdAlumno,FkIdGrado")] NonimaAlumno nonimaAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nonimaAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", nonimaAlumno.FkIdAlumno);
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", nonimaAlumno.FkIdGrado);
            return View(nonimaAlumno);
        }

        // GET: NonimaAlumno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonimaAlumno = await _context.NonimaAlumnos.FindAsync(id);
            if (nonimaAlumno == null)
            {
                return NotFound();
            }
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", nonimaAlumno.FkIdAlumno);
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", nonimaAlumno.FkIdGrado);
            return View(nonimaAlumno);
        }

        // POST: NonimaAlumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNonimnaAlumno,FkIdAlumno,FkIdGrado")] NonimaAlumno nonimaAlumno)
        {
            if (id != nonimaAlumno.IdNonimnaAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nonimaAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NonimaAlumnoExists(nonimaAlumno.IdNonimnaAlumno))
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
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", nonimaAlumno.FkIdAlumno);
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", nonimaAlumno.FkIdGrado);
            return View(nonimaAlumno);
        }

        // GET: NonimaAlumno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonimaAlumno = await _context.NonimaAlumnos
                .Include(n => n.FkIdAlumnoNavigation)
                .Include(n => n.FkIdGradoNavigation)
                .FirstOrDefaultAsync(m => m.IdNonimnaAlumno == id);
            if (nonimaAlumno == null)
            {
                return NotFound();
            }

            return View(nonimaAlumno);
        }

        // POST: NonimaAlumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nonimaAlumno = await _context.NonimaAlumnos.FindAsync(id);
            _context.NonimaAlumnos.Remove(nonimaAlumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NonimaAlumnoExists(int id)
        {
            return _context.NonimaAlumnos.Any(e => e.IdNonimnaAlumno == id);
        }
    }
}
