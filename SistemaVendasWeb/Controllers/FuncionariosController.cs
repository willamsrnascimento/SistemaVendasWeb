using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Models;

namespace SistemaVendasWeb.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionariosService _funcionariosService;
        public FuncionariosController(FuncionariosService funcionariosService)
        {
            _funcionariosService = funcionariosService;
        }
        public IActionResult Index()
        {
            IEnumerable list = _funcionariosService.BuscaTodos();
            return View(list);
        }
        public IActionResult NovoFuncionario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NovoFuncionario(Funcionario funcinario)
        {
            _funcionariosService.AdicionarFuncionario(funcinario);
            return RedirectToAction(nameof(Index));
        }    
    }
}
