using GestaoObras.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoObras.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Estatísticas simples
            ViewBag.TotalObras = await _context.Obras.CountAsync();
            ViewBag.ObrasAtivas = await _context.Obras.CountAsync(o => o.Ativa);
            ViewBag.TotalClientes = await _context.Clientes.CountAsync();
            ViewBag.TotalMateriais = await _context.Materiais.CountAsync();

            // Últimos movimentos
            ViewBag.MovimentosRecentes = await _context.MovimentosStock
                .Include(m => m.Material)
                .Include(m => m.Obra)
                .OrderByDescending(m => m.DataOperacao)
                .Take(5)
                .ToListAsync();

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
