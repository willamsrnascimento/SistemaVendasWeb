using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;

namespace SistemaVendasWeb.Controllers
{
    public class ClasseTestesController : Controller
    {
        private readonly SistemaVendasWebContext _context;

        public ClasseTestesController(SistemaVendasWebContext context)
        {
            _context = context;
        }

        // GET: ClasseTestes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasseTeste.ToListAsync());
        }

        // GET: ClasseTestes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classeTeste = await _context.ClasseTeste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classeTeste == null)
            {
                return NotFound();
            }

            return View(classeTeste);
        }

        // GET: ClasseTestes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClasseTestes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] ClasseTeste classeTeste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classeTeste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classeTeste);
        }

        // GET: ClasseTestes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classeTeste = await _context.ClasseTeste.FindAsync(id);
            if (classeTeste == null)
            {
                return NotFound();
            }
            return View(classeTeste);
        }

        // POST: ClasseTestes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] ClasseTeste classeTeste)
        {
            if (id != classeTeste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classeTeste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseTesteExists(classeTeste.Id))
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
            return View(classeTeste);
        }

        // GET: ClasseTestes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classeTeste = await _context.ClasseTeste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classeTeste == null)
            {
                return NotFound();
            }

            return View(classeTeste);
        }

        // POST: ClasseTestes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classeTeste = await _context.ClasseTeste.FindAsync(id);
            _context.ClasseTeste.Remove(classeTeste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseTesteExists(int id)
        {
            return _context.ClasseTeste.Any(e => e.Id == id);
        }
    }
}
