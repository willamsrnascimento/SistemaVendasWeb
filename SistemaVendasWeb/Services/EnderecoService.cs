using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using System.Linq;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Repository;
using System.Collections.Generic;

namespace SistemaVendasWeb.Services
{
    public class EnderecoService : IBasico<Endereco>
    {
        private readonly SistemaVendasWebContext _context;
        public EnderecoService(SistemaVendasWebContext context)
        {
            _context = context;
        }

        public void Criar(Endereco endereco)
        {
            _context.Add(endereco);
            _context.SaveChanges();
        }
        public void Atualizar(Endereco endereco)
        {
            if (!_context.Enderecos.Any(x => x.Id == endereco.Id)){
                throw new NotFoundException("Id not Found.");
            }

            try
            {
                _context.Enderecos.Update(endereco);
                _context.SaveChanges();
            }
            catch(DBUpdateConcurrencyException e)
            {
                throw new DBUpdateConcurrencyException(e.Message);
            }
        }

        public Endereco BuscarPorId(long id)
        {
            if (id == 0)
            {
                return null;
            }
            return _context.Enderecos.Find(id);
        }

        public ICollection<Endereco> BuscarTodos()
        {
            throw new System.NotImplementedException();
        }
        public void Excluir(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
