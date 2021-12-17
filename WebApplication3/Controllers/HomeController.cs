using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Controllers;
using Microsoft.AspNetCore.Session;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("usuarioLogadoID") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetInt32("usuarioLogadoID") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
