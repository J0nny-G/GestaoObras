using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoObras.Data;
using GestaoObras.Models;

namespace GestaoObras.Controllers
{
    public class ObrasController : Controller
    {
        private readonly AppDbContext _context;

        public ObrasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Obras.Include(o => o.Cliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var obra = await _context.Obras
                .Include(o => o.Cliente)
                .Include(o => o.Materiais)
                    .ThenInclude(om => om.Material)
                .Include(o => o.MaoDeObra)
                .Include(o => o.Pagamentos)
                .Include(o => o.MovimentosStock)
                    .ThenInclude(ms => ms.Material)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (obra == null) return NotFound();

            // para o <select> de materiais no formulário
            ViewBag.Materiais = await _context.Materiais
                .OrderBy(m => m.Nome)
                .ToListAsync();

            return View(obra);
        }

        // GET: Obras/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(
                _context.Clientes
                    .Select(c => new { c.Id, NomeCompleto = c.Nome + " (" + c.NIF + ")" })
                    .ToList(),
                "Id",
                "NomeCompleto"
            );

            return View();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Morada,Latitude,Longitude,Ativa,ClienteId")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", obra.ClienteId);
            return View(obra);
        }

        // GET: Obras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(
            _context.Clientes
                .Select(c => new { c.Id, NomeCompleto = c.Nome + " (" + c.NIF + ")" })
                .ToList(),
            "Id",
            "NomeCompleto",
            obra.ClienteId
        );
            return View(obra);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Morada,Latitude,Longitude,Ativa,ClienteId")] Obra obra)
        {
            if (id != obra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", obra.ClienteId);
            return View(obra);
        }

        // GET: Obras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMaterial(int ObraId, int MaterialId, int Quantidade)
        {
            var material = await _context.Materiais.FindAsync(MaterialId);
            if (material != null)
            {
                var registo = new ObraMaterial
                {
                    ObraId = ObraId,
                    MaterialId = MaterialId,
                    Quantidade = Quantidade,
                    DataHora = DateTime.UtcNow
                };

                _context.ObrasMateriais.Add(registo);
                _context.MovimentosStock.Add(new MovimentoStock
                {
                    ObraId = ObraId,
                    MaterialId = MaterialId,
                    Operacao = "REMOVE",
                    Quantidade = Quantidade,
                    DataOperacao = DateTime.UtcNow
                });

                material.StockDisponivel -= Quantidade;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = ObraId });
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMaoDeObra(int ObraId, string Pessoa, double HorasTrabalhadas)
        {
            _context.ObrasMaoDeObra.Add(new ObraMaoDeObra
            {
                ObraId = ObraId,
                Pessoa = Pessoa,
                HorasTrabalhadas = HorasTrabalhadas,
                DataHora = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = ObraId });
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPagamento(int ObraId, string Pessoa, decimal Valor)
        {
            _context.ObrasPagamentos.Add(new ObraPagamento
            {
                ObraId = ObraId,
                Pessoa = Pessoa,
                Valor = Valor,
                DataHora = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = ObraId });
        }


        private bool ObraExists(int id)
        {
            return _context.Obras.Any(e => e.Id == id);
        }
    }
}
