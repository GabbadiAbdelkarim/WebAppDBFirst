using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppDBFirst.Models.DB;

namespace WebAppDBFirst.Controllers
{
    public class IdentityCardController : Controller
    {
        private readonly MaBdContext _context;

        public IdentityCardController(MaBdContext context)
        {
            _context = context;
        }

        // GET: IdentityCard
        public async Task<IActionResult> Index()
        {
            var maBdContext = _context.CarteIdentite.Include(c => c.IdTypeCarteNavigation);
            return View(await maBdContext.ToListAsync());
        }

        // GET: IdentityCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteIdentite = await _context.CarteIdentite
                .Include(c => c.IdTypeCarteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteIdentite == null)
            {
                return NotFound();
            }

            return View(carteIdentite);
        }

        // GET: IdentityCard/Create
        public IActionResult Create()
        {
            ViewData["IdTypeCarte"] = new SelectList(_context.TypeCarte, "Id", "Id");
            return View();
        }

        // POST: IdentityCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTypeCarte,Code")] CarteIdentite carteIdentite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carteIdentite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTypeCarte"] = new SelectList(_context.TypeCarte, "Id", "Id", carteIdentite.IdTypeCarte);
            return View(carteIdentite);
        }

        // GET: IdentityCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteIdentite = await _context.CarteIdentite.FindAsync(id);
            if (carteIdentite == null)
            {
                return NotFound();
            }
            ViewData["IdTypeCarte"] = new SelectList(_context.TypeCarte, "Id", "Id", carteIdentite.IdTypeCarte);
            return View(carteIdentite);
        }

        // POST: IdentityCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTypeCarte,Code")] CarteIdentite carteIdentite)
        {
            if (id != carteIdentite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carteIdentite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteIdentiteExists(carteIdentite.Id))
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
            ViewData["IdTypeCarte"] = new SelectList(_context.TypeCarte, "Id", "Id", carteIdentite.IdTypeCarte);
            return View(carteIdentite);
        }

        // GET: IdentityCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteIdentite = await _context.CarteIdentite
                .Include(c => c.IdTypeCarteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteIdentite == null)
            {
                return NotFound();
            }

            return View(carteIdentite);
        }

        // POST: IdentityCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carteIdentite = await _context.CarteIdentite.FindAsync(id);
            _context.CarteIdentite.Remove(carteIdentite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteIdentiteExists(int id)
        {
            return _context.CarteIdentite.Any(e => e.Id == id);
        }
    }
}
