using System;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Services.Exception;

namespace SistemaVendasWeb.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Atualizar(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Endereco endereco = _enderecoService.BuscarPorId(id.Value);

            if(endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Atualizar(long id, Endereco endereco)
        {
            if(!(endereco.Id == id))
            {
                return BadRequest();
            }
            try
            {
                _enderecoService.Atualizar(endereco);
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
