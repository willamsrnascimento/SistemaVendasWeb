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

        public Task AtualizarAsync(Imagem t)
        {
            throw new NotImplementedException();
        }

        public Task<Imagem> BuscarPorIdAsync(long id)
        {
            throw new NotImplementedException();
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
    }
}
