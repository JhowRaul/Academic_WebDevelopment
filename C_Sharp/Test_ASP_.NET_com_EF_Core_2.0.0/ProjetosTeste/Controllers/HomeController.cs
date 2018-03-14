using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetosTeste.Models;

namespace ProjetosTeste.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoContexto _context;

        public HomeController(ProdutoContexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Produtos.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
