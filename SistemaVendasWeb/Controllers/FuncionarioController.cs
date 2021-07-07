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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? sFiltro, string txtProcurar)
        {
            IEnumerable list = null;

            if (sFiltro != null && (!String.IsNullOrEmpty(txtProcurar)))
            {
                list = await _funcionariosService.BuscarPorFiltroAsync(sFiltro.Value, txtProcurar);
                return View(list);
            }

            list = await _funcionariosService.BuscarTodosAsync();
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
            return RedirectToAction("Editar", "Endereco", funcionario.Endereco); 
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
        public async Task<IActionResult> Editar(long id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            if(funcionario.EnderecoId == null)
            {
                funcionario.Endereco = new Endereco();
            }
            else
            {
                funcionario.Endereco = await _enderecoService.BuscarPorIdAsync(funcionario.EnderecoId.Value);
            }
            
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
            
            return RedirectToAction("Editar", "Endereco", funcionario.Endereco);
        }

        public async Task<IActionResult> Detalhes(long? id)
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

            Funcionario funcionario = await _funcionariosService.BuscarPorIdAsync(id.Value);

            if(funcionario == null)
            {
                return NotFound();
            }
            
            await _funcionariosService.ExcluirAsync(funcionario.Id);
            await _enderecoService.ExcluirAsync(funcionario.EnderecoId.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
