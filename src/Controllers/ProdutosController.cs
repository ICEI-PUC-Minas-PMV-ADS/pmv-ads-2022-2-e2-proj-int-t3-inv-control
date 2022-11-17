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

namespace ControleDeEstoque.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ControleContext _context;

        public ProdutosController(ControleContext context)
        {
            _context = context;
        }

        //Exportar: Excel

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var planilha = workbook.Worksheets.Add("Produtos");
                var linha = 1;
                planilha.Cell(linha, 1).Value = "ID";
                planilha.Cell(linha, 2).Value = "Nome";
                planilha.Cell(linha, 3).Value = "Preço";
                planilha.Cell(linha, 4).Value = "Quantidade";
                planilha.Cell(linha, 5).Value = "Categoria";
                planilha.Cell(linha, 5).Value = "Fornecedor";

                foreach (var produto in _context.Produto)
                {
                    linha++;
                    planilha.Cell(linha, 1).Value = produto.Id;
                    planilha.Cell(linha, 2).Value = produto.NomeProd;
                    planilha.Cell(linha, 3).Value = produto.PrecoProd;
                    planilha.Cell(linha, 4).Value = produto.QtdProd;
                    planilha.Cell(linha, 5).Value = produto.CategoriaProd;
                    planilha.Cell(linha, 5).Value = produto.FornecedorId;


                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "RelatórioProdutos.xlsx");
                }
            }
        }


        // GET: Produtos
        public async Task<IActionResult> Index( int pagina = 1, string pesquisa = "")
        {

            var prod = from p 
                       in _context.Produto.Include(p => p.Fornecedor)
                       select p;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                prod = prod.Where(a => a.NomeProd.Contains(pesquisa))
                           .OrderBy(b => b.NomeProd);
            }

            return View(await prod.ToPagedListAsync(pagina, 10));
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "RazaoSocial");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProd,PrecoProd,DescricaoProd,QtdProd,CategoriaProd,FornecedorId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "RazaoSocial", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "RazaoSocial", produto.FornecedorId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProd,PrecoProd,DescricaoProd,QtdProd,CategoriaProd,FornecedorId")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "RazaoSocial", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'ControleContext.Produto'  is null.");
            }
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return _context.Produto.Any(e => e.Id == id);
        }
    }
}
