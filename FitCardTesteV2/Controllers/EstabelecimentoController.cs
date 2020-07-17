using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitCardTesteV2.Models;

namespace FitCardTesteV2.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstabelecimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estabelecimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estabelecimentos.ToListAsync());
        }

        // GET: Estabelecimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            return View(estabelecimento);
        }

        // GET: Estabelecimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estabelecimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazaoSocial,NomeFantasia,CNPJ,Email,Endereco,Cidade,Estado,Telefone,DataDeCadastro,Categoria,Status,Agencia,Conta")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estabelecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimentos.FindAsync(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazaoSocial,NomeFantasia,CNPJ,Email,Endereco,Cidade,Estado,Telefone,DataDeCadastro,Categoria,Status,Agencia,Conta")] Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estabelecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstabelecimentoExists(estabelecimento.Id))
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
            return View(estabelecimento);
        }

        // GET: Estabelecimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            return View(estabelecimento);
        }

        // POST: Estabelecimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estabelecimento = await _context.Estabelecimentos.FindAsync(id);
            _context.Estabelecimentos.Remove(estabelecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstabelecimentoExists(int id)
        {
            return _context.Estabelecimentos.Any(e => e.Id == id);
        }
    }
}
