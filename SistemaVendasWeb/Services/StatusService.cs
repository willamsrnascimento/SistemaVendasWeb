using Microsoft.EntityFrameworkCore;
using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Services
{
    public class StatusService : IBasicoAsync<Status>
    {
        private readonly SistemaVendasWebContext _context;
        public StatusService(SistemaVendasWebContext context)
        {
            _context = context;
        }

        public async Task AtualizarAsync(Status t)
        {
            throw new NotImplementedException();
        }

        public async Task<Status> BuscarPorIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Status>> BuscarTodosAsync()
        {
            if (!_context.Status.Any())
            {
                return null;
            }
            return await _context.Status.ToListAsync();
        }

        public async Task CriarAsync(Status t)
        {
            throw new NotImplementedException();
        }

        public async Task ExcluirAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
