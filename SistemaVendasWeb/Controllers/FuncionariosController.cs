using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Services;

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
    }
}
