using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Models.ViewModels;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            IEnumerable list = await _funcionariosService.BuscarTodosAsync();
            return View(list);
        }
        public async Task<IActionResult> Criar()
        {
            var status = await _statusService.BuscarTodosAsync();
            var viewModel = new FuncionarioViewModel() {Statuses = status};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Funcionario funcionario)
        {
            funcionario.Endereco = new Endereco();
            await _funcionariosService.CriarAsync(funcionario);
            return RedirectToAction("Atualizar", "Endereco", funcionario.Endereco); 
        }
        public async Task<IActionResult> Excluir(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Funcionario funcionario = await _funcionariosService.BuscarPorIdAsync(id.Value);

            if(funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            await _funcionariosService.ExcluirAsync(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
