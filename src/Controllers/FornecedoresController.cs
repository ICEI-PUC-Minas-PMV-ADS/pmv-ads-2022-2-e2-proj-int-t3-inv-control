using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeEstoque.Models;
using X.PagedList;
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.EMMA;

namespace ControleDeEstoque.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ControleContext _context;

        public FornecedoresController(ControleContext context)
        {
            _context = context;
        }

        //Exportar: Excel

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var planilha = workbook.Worksheets.Add("Fornecedores");
                var linha = 1;
                planilha.Cell(linha, 1).Value = "ID";
                planilha.Cell(linha, 2).Value = "Razão Social";
                planilha.Cell(linha, 3).Value = "Email";
                planilha.Cell(linha, 4).Value = "Telefone";
                planilha.Cell(linha, 5).Value = "Estado";
                planilha.Cell(linha, 5).Value = "Produtos";
                planilha.Cell(linha, 5).Value = "DataCadastro";

                foreach (var fornecedor in _context.Fornecedores)
                {
                    linha++;
                    planilha.Cell(linha, 1).Value = fornecedor.Id;
                    planilha.Cell(linha, 2).Value = fornecedor.RazaoSocial;
                    planilha.Cell(linha, 3).Value = fornecedor.EmailFornecedor;
                    planilha.Cell(linha, 4).Value = fornecedor.TelefoneFornecedor;
                    planilha.Cell(linha, 5).Value = fornecedor.UfFornecedor;
                    planilha.Cell(linha, 5).Value = fornecedor.Produtos != null && fornecedor.Produtos.Any() ? fornecedor.Produtos.Count() : 0;
                    planilha.Cell(linha, 5).Value = fornecedor.DataCadastroFornecedor;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "RelatórioFornecedores.xlsx");
                }
            }
        }


        // GET: Fornecedores
        public async Task<IActionResult> Index(int pagina = 1, string pesquisa = "")
        {
            var prod = from p
                       in _context.Fornecedores.Include(p => p.Produtos)
                       select p;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                prod = prod.Where(a => a.RazaoSocial.Contains(pesquisa))
                           .OrderBy(b => b.RazaoSocial);
            }

            return View(await prod.ToPagedListAsync(pagina, 10));
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazaoSocial,EmailFornecedor,CidadeFornecedor,TelefoneFornecedor,DataCadastroFornecedor,UfFornecedor")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazaoSocial,EmailFornecedor,CidadeFornecedor,TelefoneFornecedor,DataCadastroFornecedor,UfFornecedor")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
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
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fornecedores == null)
            {
                return Problem("Entity set 'ControleContext.Fornecedores'  is null.");
            }
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
          return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
