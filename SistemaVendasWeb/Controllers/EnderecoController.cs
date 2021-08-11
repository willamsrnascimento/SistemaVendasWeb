using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Services.Exception;

namespace SistemaVendasWeb.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoService _enderecoService;
        private readonly FuncionarioService _funcionariosService;

        public EnderecoController(EnderecoService enderecoService, FuncionarioService funcionariosService)
        {
            _enderecoService = enderecoService;
            _funcionariosService = funcionariosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Criar(Endereco endereco)
        {
            return View(endereco);
        }

        public async Task<IActionResult> CriarEnderecoFuncionario(Funcionario funcionario)
        {
            funcionario.Endereco = new Endereco();
            await _funcionariosService.AtualizarAsync(funcionario);
            return await Criar(funcionario.Endereco);
        }

        public async Task<IActionResult> Editar(long? id)
        {           

            if(id == null)
            {
                return NotFound();
            }

            Endereco endereco = await _enderecoService.BuscarPorIdAsync(id.Value);

            if(endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Editar(long id, Endereco endereco)
        {
           
            if (!(endereco.Id == id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(endereco);
            }

            try
            {
               await _enderecoService.AtualizarAsync(endereco);
            }
            catch(NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            }
            catch(DBUpdateConcurrencyException e)
            {
                throw new DBUpdateConcurrencyException(e.Message);
            }
            
            return RedirectToAction("Index", "Funcionario");
        }
    }
}
