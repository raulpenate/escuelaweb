#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using escuelaweb.Models;

namespace escuelaweb.Controllers
{
    public class NotasController : Controller
    {
        private readonly escuelaContext _context;

        public NotasController(escuelaContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.Nota.Include(n => n.FkIdAlumnoNavigation).Include(n => n.FkIdGradoNavigation).Include(n => n.FkIdMateriaNavigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .Include(n => n.FkIdAlumnoNavigation)
                .Include(n => n.FkIdGradoNavigation)
                .Include(n => n.FkIdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno");
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado");
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNota,FkIdAlumno,FkIdMateria,FkIdGrado,Nota1,Nota2,Nota3")] Notum notum)
        {
            if (ModelState.IsValid)
            {
                var sumaNotas = (notum.Nota1 ?? 0) + (notum.Nota2 ?? 0) + (notum.Nota3 ?? 0);
                notum.NotaFinal = sumaNotas / 3;
                _context.Add(notum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", notum.FkIdAlumno);
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", notum.FkIdGrado);
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", notum.FkIdMateria);
            return View(notum);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota.FindAsync(id);
            if (notum == null)
            {
                return NotFound();
            }
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", notum.FkIdAlumno);
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", notum.FkIdGrado);
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", notum.FkIdMateria);
            return View(notum);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNota,FkIdAlumno,FkIdMateria,FkIdGrado,Nota1,Nota2,Nota3,NotaFinal")] Notum notum)
        {
            if (id != notum.IdNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotumExists(notum.IdNota))
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
            ViewData["FkIdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", notum.FkIdAlumno);
            ViewData["FkIdGrado"] = new SelectList(_context.Grados, "IdGrado", "IdGrado", notum.FkIdGrado);
            ViewData["FkIdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", notum.FkIdMateria);
            return View(notum);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notum = await _context.Nota
                .Include(n => n.FkIdAlumnoNavigation)
                .Include(n => n.FkIdGradoNavigation)
                .Include(n => n.FkIdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notum == null)
            {
                return NotFound();
            }

            return View(notum);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notum = await _context.Nota.FindAsync(id);
            _context.Nota.Remove(notum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotumExists(int id)
        {
            return _context.Nota.Any(e => e.IdNota == id);
        }
    }
}
