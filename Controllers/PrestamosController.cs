using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tarea_semana_4.Data;
using tarea_semana_4.Models;

namespace tarea_semana_4.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly BibliotecaContext _context;

        public PrestamosController(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Prestamos.Include(p => p.Estudiante).Include(p => p.Libro);
            return View(await bibliotecaContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Estudiante)
                .Include(p => p.Libro)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        public IActionResult Create()
        {
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Apellidos");
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo");
            return View(new Prestamo { FechaPrestamo = DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,FechaPrestamo,FechaDevolucion,IdLibro,IdEstudiante")] Prestamo prestamo)
        {
            ValidarFechas(prestamo);

            if (ModelState.IsValid && prestamo.FechaDevolucion == null)
            {
                await PrestarEjemplar(prestamo.IdLibro);
            }

            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Apellidos", prestamo.IdEstudiante);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", prestamo.IdLibro);
            return View(prestamo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Apellidos", prestamo.IdEstudiante);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", prestamo.IdLibro);
            return View(prestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrestamo,FechaPrestamo,FechaDevolucion,IdLibro,IdEstudiante")] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            var anterior = await _context.Prestamos.AsNoTracking().FirstOrDefaultAsync(p => p.IdPrestamo == id);
            if (anterior == null)
            {
                return NotFound();
            }

            ValidarFechas(prestamo);

            if (ModelState.IsValid)
            {
                if (anterior.FechaDevolucion == null)
                {
                    await DevolverEjemplar(anterior.IdLibro);
                }

                if (prestamo.FechaDevolucion == null)
                {
                    await PrestarEjemplar(prestamo.IdLibro);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.IdPrestamo))
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
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Apellidos", prestamo.IdEstudiante);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "Titulo", prestamo.IdLibro);
            return View(prestamo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Estudiante)
                .Include(p => p.Libro)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                if (prestamo.FechaDevolucion == null)
                {
                    await DevolverEjemplar(prestamo.IdLibro);
                }
                _context.Prestamos.Remove(prestamo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.IdPrestamo == id);
        }

        private void ValidarFechas(Prestamo prestamo)
        {
            if (prestamo.FechaDevolucion != null && prestamo.FechaDevolucion < prestamo.FechaPrestamo)
            {
                ModelState.AddModelError(nameof(Prestamo.FechaDevolucion), "La fecha de devolución no puede ser anterior a la fecha de préstamo.");
            }
        }

        private async Task PrestarEjemplar(int idLibro)
        {
            var libro = await _context.Libros.FindAsync(idLibro);
            if (libro == null)
            {
                ModelState.AddModelError(nameof(Prestamo.IdLibro), "El libro seleccionado no existe.");
                return;
            }

            if (libro.Stock <= 0)
            {
                ModelState.AddModelError(nameof(Prestamo.IdLibro), $"No hay ejemplares disponibles de \"{libro.Titulo}\".");
                return;
            }

            libro.Stock--;
        }

        private async Task DevolverEjemplar(int idLibro)
        {
            var libro = await _context.Libros.FindAsync(idLibro);
            if (libro != null)
            {
                libro.Stock++;
            }
        }
    }
}
