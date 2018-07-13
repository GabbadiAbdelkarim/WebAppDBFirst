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
    public class CitoyensController : Controller
    {
        private readonly MaBdContext _context;

        public CitoyensController(MaBdContext context)
        {
            _context = context;
        }

        // GET: Citoyens
        public async Task<IActionResult> Index()
        {
            var maBdContext = _context.Citoyen.Include(c => c.IdAdresseNavigation).Include(c => c.IdCarteNavigation).Include(c => c.IdCompteNavigation).Include(c => c.IdRelationNavigation);
            return View(await maBdContext.ToListAsync());
        }

        // GET: Citoyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citoyen = await _context.Citoyen
                .Include(c => c.IdAdresseNavigation)
                .Include(c => c.IdCarteNavigation)
                .Include(c => c.IdCompteNavigation)
                .Include(c => c.IdRelationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citoyen == null)
            {
                return NotFound();
            }

            return View(citoyen);
        }

        // GET: Citoyens/Create
        public IActionResult Create()
        {
            ViewData["IdAdresse"] = new SelectList(_context.Adresse, "Id", "Id");
            ViewData["IdCarte"] = new SelectList(_context.CarteIdentite, "Id", "Id");
            ViewData["IdCompte"] = new SelectList(_context.Compte, "Id", "Id");
            ViewData["IdRelation"] = new SelectList(_context.Relation, "Id", "Id");
            return View();
        }

        // POST: Citoyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCarte,IdAdresse,IdCompte,IdRelation,Nom,Prenom,Telephone,DateNaissance")] Citoyen citoyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citoyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdresse"] = new SelectList(_context.Adresse, "Id", "Id", citoyen.IdAdresse);
            ViewData["IdCarte"] = new SelectList(_context.CarteIdentite, "Id", "Id", citoyen.IdCarte);
            ViewData["IdCompte"] = new SelectList(_context.Compte, "Id", "Id", citoyen.IdCompte);
            ViewData["IdRelation"] = new SelectList(_context.Relation, "Id", "Id", citoyen.IdRelation);
            return View(citoyen);
        }

        // GET: Citoyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citoyen = await _context.Citoyen.FindAsync(id);
            if (citoyen == null)
            {
                return NotFound();
            }
            ViewData["IdAdresse"] = new SelectList(_context.Adresse, "Id", "Id", citoyen.IdAdresse);
            ViewData["IdCarte"] = new SelectList(_context.CarteIdentite, "Id", "Id", citoyen.IdCarte);
            ViewData["IdCompte"] = new SelectList(_context.Compte, "Id", "Id", citoyen.IdCompte);
            ViewData["IdRelation"] = new SelectList(_context.Relation, "Id", "Id", citoyen.IdRelation);
            return View(citoyen);
        }

        // POST: Citoyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCarte,IdAdresse,IdCompte,IdRelation,Nom,Prenom,Telephone,DateNaissance")] Citoyen citoyen)
        {
            if (id != citoyen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citoyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitoyenExists(citoyen.Id))
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
            ViewData["IdAdresse"] = new SelectList(_context.Adresse, "Id", "Id", citoyen.IdAdresse);
            ViewData["IdCarte"] = new SelectList(_context.CarteIdentite, "Id", "Id", citoyen.IdCarte);
            ViewData["IdCompte"] = new SelectList(_context.Compte, "Id", "Id", citoyen.IdCompte);
            ViewData["IdRelation"] = new SelectList(_context.Relation, "Id", "Id", citoyen.IdRelation);
            return View(citoyen);
        }

        // GET: Citoyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citoyen = await _context.Citoyen
                .Include(c => c.IdAdresseNavigation)
                .Include(c => c.IdCarteNavigation)
                .Include(c => c.IdCompteNavigation)
                .Include(c => c.IdRelationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citoyen == null)
            {
                return NotFound();
            }

            return View(citoyen);
        }

        // POST: Citoyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citoyen = await _context.Citoyen.FindAsync(id);
            _context.Citoyen.Remove(citoyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitoyenExists(int id)
        {
            return _context.Citoyen.Any(e => e.Id == id);
        }
    }
}
