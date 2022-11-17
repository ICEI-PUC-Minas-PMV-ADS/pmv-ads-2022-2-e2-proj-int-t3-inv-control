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
    public class ClientesController : Controller
    {
        private readonly ControleContext _context;

        public ClientesController(ControleContext context)
        {
            _context = context;
        }

        //Exportar: Excel

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var planilha = workbook.Worksheets.Add("Clientes");
                var linha = 1;
                planilha.Cell(linha, 1).Value = "ID";
                planilha.Cell(linha, 2).Value = "Nome/Razão";
                planilha.Cell(linha, 3).Value = "Endereço";
                planilha.Cell(linha, 4).Value = "Cidade";
                planilha.Cell(linha, 5).Value = "Estado";
                planilha.Cell(linha, 5).Value = "DataCadastro";

                foreach (var cliente in _context.Cliente)
                {
                    linha++;
                    planilha.Cell(linha, 1).Value = cliente.Id;
                    planilha.Cell(linha, 2).Value = cliente.NomeOuRazaoSocial;
                    planilha.Cell(linha, 3).Value = cliente.EnderecoCliente;
                    planilha.Cell(linha, 4).Value = cliente.CidadeCliente;
                    planilha.Cell(linha, 5).Value = cliente.UfCliente;
                    planilha.Cell(linha, 5).Value = cliente.DataCadastroCliente.ToString("d/MM/yyyy");

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "RelatórioClientes.xlsx");
                }
            }
        }

        // GET: Clientes
        public async Task<IActionResult> Index(int pagina = 1, string pesquisa = "")
        {
            var prod = from p
                       in _context.Cliente
                       select p;


            if (!String.IsNullOrEmpty(pesquisa))
            {
                prod = prod.Where(a => a.NomeOuRazaoSocial.Contains(pesquisa))
                           .OrderBy(b => b.Id);
            }

            return View(await prod.ToPagedListAsync(pagina, 10));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliente == null )
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeOuRazaoSocial,EnderecoCliente,EmailCliente,CidadeCliente,UfCliente,CepCliente,TelefoneCliente,DataCadastroCliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeOuRazaoSocial,EnderecoCliente,EmailCliente,CidadeCliente,UfCliente,CepCliente,TelefoneCliente,DataCadastroCliente")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
