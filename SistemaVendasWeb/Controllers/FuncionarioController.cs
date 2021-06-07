using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Models.ViewModels;
using System.Threading.Tasks;
using System.Collections;

namespace SistemaVendasWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioService _funcionariosService;
        private readonly StatusService _statusService;
        private readonly EnderecoService _enderecoService;

        public FuncionarioController(FuncionarioService funcionariosService, StatusService statusService, EnderecoService enderecoService)
        {
            _funcionariosService = funcionariosService;
            _statusService = statusService;
            _enderecoService = enderecoService;
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

        public async Task<IActionResult> Editar(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Funcionario funcionario = await _funcionariosService.BuscarPorIdAsync(id.Value);
            List<Status> statusLista = await _statusService.BuscarTodosAsync();

            if(funcionario == null)
            {
                return NotFound();
            }

            FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel() { Funcionario = funcionario, Statuses = statusLista };

            return View(funcionarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Funcionario funcionario)
        {
            if (funcionario.EnderecoId == 0)
            {
                return NotFound();
            }

            funcionario.Endereco = await _enderecoService.BuscarPorIdAsync(funcionario.EnderecoId);

            try
            {
                await _funcionariosService.AtualizarAsync(funcionario);
            }
            catch(NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            }
            catch (DBUpdateConcurrencyException e)
            {
                throw new NotFoundException(e.Message);
            }          
            
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
