using Microsoft.AspNetCore.Mvc;
using RGBViagens.Models;
using System.Diagnostics;

namespace RGBViagens.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        public HomeController(Context contexto)
        {
            _context = contexto;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Destinos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Destinos(ComprarDestinos comprarDestinos)
        {
            _context.ComprarDestinos.Add(comprarDestinos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contatos(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Promocoes()
        {
            return View();
        }

        public IActionResult MeusDestinos()
        {
            var carrinho = _context.ComprarDestinos.ToList();
            return View(carrinho);
        }

    }
}