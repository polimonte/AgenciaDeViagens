#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RGBViagens.Models;

namespace RGBViagens.Controllers
{
    public class ComprarDestinosController : Controller
    {
        private readonly Context _context;

        public ComprarDestinosController(Context context)
        {
            _context = context;
        }

        // GET: ComprarDestinos
        public async Task<IActionResult> Index()
        {
            var context = _context.ComprarDestinos.Include(c => c.Destinos);
            return View(await context.ToListAsync());
        }

        // GET: ComprarDestinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprarDestinos = await _context.ComprarDestinos
                .Include(c => c.Destinos)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comprarDestinos == null)
            {
                return NotFound();
            }

            return View(comprarDestinos);
        }

        // GET: ComprarDestinos/Create
        public IActionResult Create()
        {
            ViewData["Nome_lugar"] = new SelectList(_context.Destinos, "Nome_lugar", "Nome_lugar");
            ViewData["ID_Destinos"] = new SelectList(_context.Destinos, "ID_Destinos", "ID_Destinos");
            return View();
        }

        // POST: ComprarDestinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Origem,ID_Destinos,Ida,Volta,N_Passageiros,Classe")] ComprarDestinos comprarDestinos)
        {

            _context.Add(comprarDestinos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));

            ViewData["Nome_lugar"] = new SelectList(_context.Destinos, "Nome_lugar", "Nome_lugar", comprarDestinos.ID_Destinos);
            ViewData["ID_Destinos"] = new SelectList(_context.Destinos, "ID_Destinos", "ID_Destinos", comprarDestinos.ID_Destinos);
            return View(comprarDestinos);
        }

        // GET: ComprarDestinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprarDestinos = await _context.ComprarDestinos.FindAsync(id);
            if (comprarDestinos == null)
            {
                return NotFound();
            }
            ViewData["ID_Destinos"] = new SelectList(_context.Destinos, "ID_Destinos", "ID_Destinos", comprarDestinos.ID_Destinos);
            return View(comprarDestinos);
        }

        // POST: ComprarDestinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Origem,ID_Destinos,Ida,Volta,N_Passageiros,Classe")] ComprarDestinos comprarDestinos)
        {
            if (id != comprarDestinos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprarDestinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprarDestinosExists(comprarDestinos.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(HomeController.MeusDestinos));
            }
            ViewData["ID_Destinos"] = new SelectList(_context.Destinos, "ID_Destinos", "ID_Destinos", comprarDestinos.ID_Destinos);
            return View(comprarDestinos);
        }

        // GET: ComprarDestinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprarDestinos = await _context.ComprarDestinos
                .Include(c => c.Destinos)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comprarDestinos == null)
            {
                return NotFound();
            }

            return View(comprarDestinos);
        }

        // POST: ComprarDestinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprarDestinos = await _context.ComprarDestinos.FindAsync(id);
            _context.ComprarDestinos.Remove(comprarDestinos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HomeController.MeusDestinos));
        }

        private bool ComprarDestinosExists(int id)
        {
            return _context.ComprarDestinos.Any(e => e.ID == id);
        }
    }
}
