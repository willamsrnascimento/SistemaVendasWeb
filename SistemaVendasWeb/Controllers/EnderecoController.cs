using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Repository;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Services.Exception;

namespace SistemaVendasWeb.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository, IFuncionarioRepository funcionarioRepository)
        {
            _enderecoRepository = enderecoRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar(Endereco endereco)
        {
            return View(endereco);
        }

        public async Task<IActionResult> CriarEnderecoFuncionario(Funcionario funcionario)
        {
            funcionario.Endereco = new Endereco();
            await _funcionarioRepository.AtualizarAsync(funcionario);
            return Criar(funcionario.Endereco);
        }

        public async Task<IActionResult> Editar(long? id)
        {           

            if(id == null)
            {
                return NotFound();
            }

            Endereco endereco = await _enderecoRepository.BuscarPorIdAsync(id.Value);

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
               await _enderecoRepository.AtualizarAsync(endereco);
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
