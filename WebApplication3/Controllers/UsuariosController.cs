using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;


namespace WebApplication3.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;

        }


        // GET: Usuarios
        public ActionResult Login()
        {
            return View();
        }

        // POST: Usuarios
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                
                {
                    var v = _context.Usuarios.Where(a => a.Usuario.Equals(u.Usuario) && a.Senha.Equals(u.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogadoID")))
                        {
                            HttpContext.Session.SetInt32("usuarioLogadoID", v.Id);
                            HttpContext.Session.SetString("nomeUsuarioLogado", v.Nome);
                        }

                        //var idUsuario = HttpContext.Session.GetInt32("usuarioLogadoID");
                        //var nomeUsuario = HttpContext.Session.GetString("nomeUsuarioLogado");\\z
                        
                        //Session["usuarioLogadoID"] = v.Id.ToString();
                        //Session["nomeUsuarioLogado"] = v.Usuario.ToString();
                        
                        return RedirectToAction("Index","Home");//precisa alterar esse parametro
                    }
                }
            }
            return View(u);
        }
        /*
        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    } 
}
