using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaVendasWeb.Services;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Models.ViewModels;
using System.Threading.Tasks;
using SistemaVendasWeb.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;

namespace SistemaVendasWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioService _funcionariosService;
        private readonly StatusService _statusService;
        private readonly EnderecoService _enderecoService;
        private readonly ImagemService _imagemService;

        public FuncionarioController(FuncionarioService funcionariosService, StatusService statusService, EnderecoService enderecoService, ImagemService imagemService)
        {
            _funcionariosService = funcionariosService;
            _statusService = statusService;
            _enderecoService = enderecoService;
            _imagemService = imagemService;
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

        public async Task<IActionResult> Exportar()
        {
            List<Funcionario> funcionarios = await _funcionariosService.BuscarTodosAsync();
            StringBuilder dados = new StringBuilder();
            dados.AppendLine("Nome;CPF;RG;Orgão Expedidor;E-mail;Telefone;Sexo;Endereço;Status");

            foreach(Funcionario funcionario in funcionarios)
            {
                string endereco = "";

                if(funcionario.Endereco != null)
                {
                    endereco = $"{funcionario.Endereco.Rua}, {funcionario.Endereco.Numero}, {funcionario.Endereco.Complemento}, {funcionario.Endereco.Bairro}, {funcionario.Endereco.Cidade} - {funcionario.Endereco.CEP}";
                }

                dados.AppendLine($"{funcionario.Nome};{funcionario.CPF};{funcionario.RG};{funcionario.OrgaoExpedidor};{funcionario.Email};{funcionario.Telefone};{((funcionario.Sexo) == 'M' ? "Masculino" : "Feminino")};{endereco};{funcionario.Status.Descricao}");
            }

            return File(Encoding.ASCII.GetBytes(dados.ToString()), "text/csv", $"RelFuncionarios_{DateTime.Now.ToString("yyyyMMdd")}.csv");
        }

        public async Task<IActionResult> Criar()
        {
            var status = await _statusService.BuscarTodosAsync();
            Imagem imagem = new Imagem() { URL = "~/images/funcionario/default.png" };
            var viewModel = new FuncionarioViewModel() {Status = status, Imagem = imagem };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(long? id, Funcionario funcionario, IFormFile imagem)
        {           
            if (ModelState.IsValid)
            {
                if(id != 0 && id != null)
                {
                    ViewData["informacao"] = "Usuário já cadastrado!";
                    funcionario = await _funcionariosService.BuscarPorIdAsync(id.Value);
                }
                else
                {
                   funcionario.Imagem = await _imagemService.ProcessaImagem(imagem);
                   await _funcionariosService.CriarAsync(funcionario);
                   ViewData["informacao"] = "Usuário cadastrado com sucesso.";
                }                
            }
            else
            {
                ViewData["informacao"] = "Favor preencher as informações corretamente.";
                funcionario.Imagem = new Imagem() { URL = "~/images/funcionario/default.png" };
            }

            var status = await _statusService.BuscarTodosAsync();
            FuncionarioViewModel viewModel = new FuncionarioViewModel() { Funcionario = funcionario, Status = status, Imagem = funcionario.Imagem };

            return View("Criar", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarEndereco(long? id, Funcionario funcionario)
        {
            
            if (!ModelState.IsValid || id == null || id == 0)
            {
                ViewData["informacao"] = "Funcionário ainda não registrado. Favor primeiro preencher as informações e salvar.";
                var status = await _statusService.BuscarTodosAsync();
                Imagem imagem = new Imagem() { URL = "~/images/funcionario/default.png" };
                FuncionarioViewModel viewModel = new FuncionarioViewModel() { Funcionario = funcionario, Status = status, Imagem = imagem };
                return View("Criar", viewModel);
            }

            funcionario = await _funcionariosService.BuscarPorIdAsync(id.Value);

            if(funcionario == null)
            {
                return BadRequest();
            }

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

            FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel() { Funcionario = funcionario, Status = statusLista };

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
                return null;
            }

            Funcionario funcionario = await _funcionariosService.BuscarPorIdAsync(id.Value);

            if(funcionario == null)
            {
                return null;
            }
            
            await _funcionariosService.ExcluirAsync(funcionario.Id);
            
            if(funcionario.EnderecoId != null)
            {
                await _enderecoService.ExcluirAsync(funcionario.EnderecoId.Value);
            }

            if(funcionario.ImagemId != null)
            {
                await _imagemService.ExcluirAsync(funcionario.ImagemId.Value);
            }

            return RedirectToAction("Index", "Funcionario");
        }
    }
}
