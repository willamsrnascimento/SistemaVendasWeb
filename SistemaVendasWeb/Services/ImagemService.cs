using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Repository;
using SistemaVendasWeb.Services.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Services
{
    public class ImagemService : IBasicoAsync<Imagem>
    {
        private readonly SistemaVendasWebContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImagemService(SistemaVendasWebContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AtualizarAsync(Imagem imagem)
        {
            if (!_context.Imagens.Any(i => i.Id == imagem.Id))
            {
                throw new NotFoundException("Id not Found.");
            }

            try
            {
                imagem.DataAlteracao = DateTime.Now;
                _context.Imagens.Update(imagem);
                await _context.SaveChangesAsync();
            }
            catch (DBUpdateConcurrencyException e)
            {
                throw new DBUpdateConcurrencyException(e.Message);
            }
        }

        public async Task<Imagem> BuscarPorIdAsync(long id)
        {
            return await _context.Imagens.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<Imagem>> BuscarTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task CriarAsync(Imagem t)
        {
            throw new NotImplementedException();
        }

        public async Task ExcluirAsync(long id)
        {
            Imagem imagem = await _context.Imagens.FirstOrDefaultAsync(i => i.Id == id);

            if (imagem == null)
            {
                throw new NotFoundException("Excluir: Imagem não encontrada!");
            }

            Util.ImagemUtil.ExcluirImagem(imagem, _webHostEnvironment);

            try
            {
                _context.Imagens.Remove(imagem);
                await _context.SaveChangesAsync();
            }
            catch (DBUpdateConcurrencyException e)
            {
                throw new DBUpdateConcurrencyException(e.Message);
            }
        }

        public async Task<Imagem> ProcessaImagem(IFormFile file)
        {
            return await Util.ImagemUtil.ProcessaImagem(file, _webHostEnvironment);
        }

        public async Task<Imagem> ProcessaImagem(Imagem imagem, IFormFile file)
        {
            Imagem imagemAux = await BuscarPorIdAsync(imagem.Id);

            if(file != null)
            {
                try
                {
                    Util.ImagemUtil.ExcluirImagem(imagemAux, _webHostEnvironment);
                    imagem = await Util.ImagemUtil.ProcessaImagem(file, _webHostEnvironment);
                    imagemAux.Nome = imagem.Nome;
                    imagemAux.NomeGuia = imagem.NomeGuia;
                    imagemAux.URL = imagem.URL;

                    await AtualizarAsync(imagemAux);
                }
                catch (ApplicationException e)
                {
                    throw new ApplicationException(e.Message);
                }
            }

            return imagemAux;
        }
    }
}
