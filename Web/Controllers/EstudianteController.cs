using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combos;
        private readonly IConverterHelper _converter;

        public EstudianteController(
            DataContext context,
            ICombosHelper combos,
            IConverterHelper converter)
        {
            _context = context;
            _combos = combos;
            _converter = converter;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        public IActionResult Create()
        {
            EstudianteViewModel model = new EstudianteViewModel
            {
                Genero = _combos.Genders()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student estudiante = _converter.student(model);
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            model.Genero = _combos.Genders();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Students.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            EstudianteViewModel model = _converter.ToEstudentViewModel(estudiante);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student estudiante)
        {
            if (id != estudiante.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.ID))
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
            return View(estudiante);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Students.FindAsync(id);
            _context.Students.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }

        public async Task<IActionResult> AddDireccion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student estudiante = await _context.Students.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            Direccion model = new Direccion { IdEstudiante = estudiante.ID };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDireccion(Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                Student estudiante = await _context.Students
                    .Include(e => e.Direcciones)
                    .FirstOrDefaultAsync(e => e.ID == direccion.IdEstudiante);
                if (estudiante == null)
                {
                    return NotFound();
                }

                try
                {
                    direccion.ID = 0;
                    estudiante.Direcciones.Add(direccion);
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = estudiante.ID });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Existe un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(direccion);
        }
    }
}
