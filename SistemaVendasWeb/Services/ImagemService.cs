using SistemaVendasWeb.Models;
using SistemaVendasWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Services
{
    public class ImagemService : IBasicoAsync<Imagem>
    {
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

        public Task ExcluirAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
