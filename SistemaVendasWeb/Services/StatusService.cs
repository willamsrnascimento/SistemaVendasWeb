using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using SistemaVendasWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SistemaVendasWeb.Services
{
    public class StatusService : IBasico<Status>
    {
        private readonly SistemaVendasWebContext _context;
        public StatusService(SistemaVendasWebContext context)
        {
            _context = context;
        }
        public void Criar(Status t)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Status status)
        {
            throw new NotImplementedException();
        }

        public Status BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Status> BuscarTodos()
        {
            if (!_context.Status.Any())
            {
                return null;
            }
            return _context.Status.ToList();
        }

        public void Excluir(long id)
        {
            throw new NotImplementedException();
        }

    }
}
