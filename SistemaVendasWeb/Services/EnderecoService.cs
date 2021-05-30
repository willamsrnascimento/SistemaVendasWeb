using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using System.Linq;
using SistemaVendasWeb.Services.Exception;


namespace SistemaVendasWeb.Services
{
    public class EnderecoService 
    {
        private readonly SistemaVendasWebContext _context;
        public EnderecoService(SistemaVendasWebContext context)
        {
            _context = context;
        }

        public void Adicionar(Endereco endereco)
        {
            _context.Add(endereco);
            _context.SaveChanges();
        }

        public Endereco BuscarPorId(long? id)
        {
            if(id == null)
            {
                return null;
            }
            return _context.Enderecos.Find(id);
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
    }
}
