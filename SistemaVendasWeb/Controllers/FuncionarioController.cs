using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Models.ViewModels;


namespace SistemaVendasWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioService _funcionariosService;
        private readonly StatusService _statusService;

        public FuncionarioController(FuncionarioService funcionariosService, StatusService statusService)
        {
            _funcionariosService = funcionariosService;
            _statusService = statusService;
        }
        public IActionResult Index()
        {
            IEnumerable list = _funcionariosService.BuscarTodos();
            return View(list);
        }
        public IActionResult Criar()
        {
            var status = _statusService.BuscarTodos();
            var viewModel = new FuncionarioViewModel() {Statuses = status};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Funcionario funcionario)
        {
            funcionario.Endereco = new Endereco();
            _funcionariosService.Criar(funcionario);
            return RedirectToAction("Atualizar", "Endereco", funcionario.Endereco); 
        }
        public IActionResult Excluir(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Funcionario funcionario = _funcionariosService.BuscarPorId(id.Value);

            if(funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            _funcionariosService.Excluir(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
