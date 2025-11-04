using GestaoObras.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestaoObras.Controllers
{
    public class MovimentosController : Controller
    {
        private readonly AppDbContext _context;

        public MovimentosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? obraId)
        {
            // pass the selected value (obraId) to the SelectList constructor
            ViewBag.Obras = new SelectList(await _context.Obras.OrderBy(o => o.Nome).ToListAsync(), "Id", "Nome", obraId);
            
            var query = _context.MovimentosStock
                .Include(m => m.Obra)
                .Include(m => m.Obra.Cliente)
                .Include(m => m.Material)
                .AsQueryable();

            if (obraId != null)
                query = query.Where(m => m.ObraId == obraId);

            var movimentos = await query.OrderByDescending(m => m.DataOperacao).ToListAsync();
            return View(movimentos);
        }
    }
}
