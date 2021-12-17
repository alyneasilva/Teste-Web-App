using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Microsoft.AspNetCore.Session;

namespace WebApplication3.Controllers
{
    public class EquipamentosController : Controller
    {
        private readonly Context _context;

        public EquipamentosController(Context context)
        {
            _context = context;

        }

        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {

            /*
            var usuariologado = HttpContext.Session.GetInt32("usuarioLogadoID");
            if ( usuariologado != null)
            {
                return View(await _context.Equipamentos.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }*/

            //return View(await _context.Equipamentos.ToListAsync());
            return View();
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentos = await _context.Equipamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipamentos == null)
            {
                return NotFound();
            }
            /*/Verifica login
            var usuariologado = HttpContext.Session.GetInt32("usuarioLogadoID");
            if (usuariologado != null)
            {
                return View(equipamentos);
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
            //Fim verifica login*/
            return View(equipamentos);
        }

        // GET: Equipamentos/Create
        public IActionResult Create()
        {
            /*/Verifica login
            var usuariologado = HttpContext.Session.GetInt32("usuarioLogadoID");
            if (usuariologado != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
            *///Fim verifica login

            return View();
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Equipamento,Modelo,SerialNumber,Tipo,Local,Armario,Prateleira,AplicativoInstalado,SistemaAutomação,LocalUtilização,Usuario,Data")] Equipamentos equipamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Equipamentos.Add(equipamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //Verifica login
            var usuariologado = HttpContext.Session.GetInt32("usuarioLogadoID");
            if (usuariologado != null)
            {
                return View(equipamentos);
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
            //Fim verifica login
            //return View(equipamentos);
        }

        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentos = await _context.Equipamentos.FindAsync(id);
            if (equipamentos == null)
            {
                return NotFound();
            }
            return View(equipamentos);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Equipamento,Modelo,SerialNumber,Tipo,Local,Armario,Prateleira,AplicativoInstalado,SistemaAutomação,LocalUtilização,Usuario,Data")] Equipamentos equipamentos)
        {
            if (id != equipamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentosExists(equipamentos.Id))
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
            return View(equipamentos);
        }

        // GET: Equipamentos/Usar
        public async Task<IActionResult> Usar2(int? id)
        {
            var transacao = new Transacoes();
            transacao.IdEquipamento = (int)id;
            return View(transacao);
        }

        // POST: Equipamentos/Use/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Usar([Bind("Id,Transacao,Usuario,Data,Local,IdEquipamento")] Transacoes transacoes)

        
        {
            
            var equipamentos = await _context.Equipamentos.FindAsync(transacoes.IdEquipamento);
            //equipamentos.Status = "Utilizado";
            //equipamentos.Data = DateTime.Now;

            transacoes.Data = DateTime.Now;
            transacoes.Transacao = "Utilizado";
            var a = HttpContext.Session.GetString("nomeUsuarioLogado");
            transacoes.Usuario = a;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Transacoes.Add(transacoes);
                    await _context.SaveChangesAsync();
                    
                    _context.Equipamentos.Update(equipamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentosExists(equipamentos.Id))
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

            //Alyne Verifica Login
            var usuariologado = HttpContext.Session.GetInt32("usuarioLogadoID");
            if (usuariologado != null)
            {
                return View(equipamentos);
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
            // Fim Alyne

            //return View(equipamentos);
        }

        // GET: Equipamentos/Devolver
        public async Task<IActionResult> Devolver2(int? id)
        {
            var equipamentos = await _context.Equipamentos.FindAsync(id);

            return View(equipamentos);
        }
        // POST: Equipamentos/Devolver/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolver([Bind("Id,Local,Armario,Prateleira")] Equipamentos equipamentos)


        {
            var equipamentos2 = await _context.Equipamentos.FindAsync(equipamentos.Id);
            equipamentos2.Local = equipamentos.Local;
            equipamentos2.Armario = equipamentos.Armario;
            equipamentos2.Prateleira = equipamentos.Prateleira; 
            //equipamentos2.Status = "Disponível";


            var transacoes = new Transacoes(); //await _context.Transacoes.FindAsync(transacoes.IdEquipamento);
            transacoes.Data = DateTime.Now;
            transacoes.Transacao = "Devolver";
            var usuarioLogado = HttpContext.Session.GetString("nomeUsuarioLogado");
            transacoes.Usuario = usuarioLogado;
            transacoes.IdEquipamento = equipamentos2.Id;
            transacoes.Local = equipamentos2.Local; 

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Transacoes.Add(transacoes);
                    await _context.SaveChangesAsync();

                    _context.Equipamentos.Update(equipamentos2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentosExists(equipamentos.Id))
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

            //Alyne Verifica Login
            var usuariologado = HttpContext.Session.GetInt32("usuarioLogadoID");
            if (usuariologado != null)
            {
                return View(equipamentos);
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
            // Fim Alyne

            //return View(equipamentos);
        }
        // POST: Equipamentos/Devolver/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        public async Task<IActionResult> Devolver(int? id)
        {
            var equipamentos = await _context.Equipamentos.FindAsync(id);
            equipamentos.Status = "Disponível";
            equipamentos.Data = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentosExists(equipamentos.Id))
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
            return View(equipamentos);
        }

        */
        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentos = await _context.Equipamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipamentos == null)
            {
                return NotFound();
            }

            return View(equipamentos);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipamentos = await _context.Equipamentos.FindAsync(id);
            _context.Equipamentos.Remove(equipamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamentosExists(int id)
        {
            return _context.Equipamentos.Any(e => e.Id == id);
        }
    }
}
