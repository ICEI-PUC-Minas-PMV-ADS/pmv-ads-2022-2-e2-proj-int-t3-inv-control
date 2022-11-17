using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeEstoque.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using X.PagedList;
using ClosedXML.Excel;
using System.IO;

namespace ControleDeEstoque.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ControleContext _context;

        public UsuariosController(ControleContext context)
        {
            _context = context;
        }


        //Exportar: Excel

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var planilha = workbook.Worksheets.Add("Usuários");
                var linha = 1;
                planilha.Cell(linha, 1).Value = "ID";
                planilha.Cell(linha, 2).Value = "Email";
                planilha.Cell(linha, 3).Value = "Login";
                planilha.Cell(linha, 4).Value = "Perfil";
                planilha.Cell(linha, 4).Value = "DataCadastro";

                foreach (var usuario in _context.Usuarios)
                {
                    linha++;
                    planilha.Cell(linha, 1).Value = usuario.Id;
                    planilha.Cell(linha, 2).Value = usuario.EmaildoUsuario;
                    planilha.Cell(linha, 3).Value = usuario.Login;
                    planilha.Cell(linha, 4).Value = usuario.PerfilUsuario;
                    planilha.Cell(linha, 4).Value = usuario.DataCadastro; 

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "RelatórioUsuários.xlsx");
                }
            }
        }

        // Login
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login([Bind("Login, Senha")] Usuario usuario)
        {

            var user = await _context.Usuarios
                .FirstOrDefaultAsync(a => a.Login == usuario.Login);

            if (user == null)
            {
                ViewBag.Message = "Login e/ou senha inválidos";
                return View();
            }

            bool senhaOK = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);

            if (senhaOK)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.NameIdentifier, user.Login),
                    new Claim(ClaimTypes.Role, user.PerfilUsuario.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                var propriedades = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, propriedades);

                return Redirect("/");
            }

            ViewBag.Message = "Login e/ou senha inválidos";
            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }


        public IActionResult AcessoNegado()
        {
            return View();
        }

     

        // GET: Usuarios
        public async Task<IActionResult> Index(int pagina = 1, string pesquisa = "")
        {
            var prod = from p
                       in _context.Usuarios
                       select p;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                prod = prod.Where(a => a.Login.Contains(pesquisa))
                           .OrderBy(b => b.Login);
            }

            return View(await prod.ToPagedListAsync(pagina, 10));
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmaildoUsuario,Login,Senha,PerfilUsuario,DataCadastro")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmaildoUsuario,Login,Senha,PerfilUsuario,DataCadastro")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ControleContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
