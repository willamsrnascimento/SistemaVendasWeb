﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Models.ViewModels;
using System.Threading.Tasks;
using SistemaVendasWeb.Models.Enums;

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
            List<Funcionario> list = await _funcionariosService.BuscarTodosAsync();
            
            if(list == null)
            {
                ViewData["informacao"] = "Não há informações a serem exibidas.";
                list = new List<Funcionario>();
            }

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Filtros? sFiltro, string txtProcurar)
        {
            List<Funcionario> list = null;

            if (sFiltro != null && (!String.IsNullOrEmpty(txtProcurar)))
            {
                list = await _funcionariosService.BuscarPorFiltroAsync(sFiltro.Value, txtProcurar);
                
                if(list.Count == 0)
                {
                    ViewData["informacao"] = $"O filtro '{sFiltro}' '{txtProcurar}' procurado, não existe.";
                }
            
                return View(list);
            }

            list = await _funcionariosService.BuscarTodosAsync();

            if(list == null)
            {
                ViewData["informacao"] = "Não há informações a serem exibidas.";
                list = new List<Funcionario>();
            }

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
            if (!ModelState.IsValid)
            {
                var status = await _statusService.BuscarTodosAsync();
                FuncionarioViewModel viewModel = new FuncionarioViewModel() { Funcionario = funcionario, Statuses = status };
                return View("Criar", viewModel);
            }

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

            if (funcionario == null)
            {
                return NotFound();
            }

            if (funcionario.Endereco == null)
            {
                funcionario.Endereco = new Endereco();
                try
                {
                    await _funcionariosService.AtualizarAsync(funcionario);
                }
                catch (NotFoundException e)
                {
                    throw new NotFoundException(e.Message);
                }
                catch (DBUpdateConcurrencyException e)
                {
                    throw new NotFoundException(e.Message);
                }
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

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Excluir(int? id)
        {
            if(id == null)
            {
                return null;
            }

            Funcionario funcionario = await _funcionariosService.BuscarPorIdAsync(id.Value);

            if(funcionario == null)
            {
                return null;
            }
            
            await _funcionariosService.ExcluirAsync(funcionario.Id);
            await _enderecoService.ExcluirAsync(funcionario.EnderecoId.Value);

            return Json(funcionario);
        }
    }
}
