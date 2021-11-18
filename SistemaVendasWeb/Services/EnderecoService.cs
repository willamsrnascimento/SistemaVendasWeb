using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using System.Linq;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaVendasWeb.Services
{
    public class EnderecoService : IEnderecoRepository
    {
        private readonly SistemaVendasWebContext _context;
        public EnderecoService(SistemaVendasWebContext context)
        {
            _context = context;
        }

        public async Task CriarAsync(Endereco endereco)
        {
            _context.Add(endereco);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarAsync(Endereco endereco)
        {
            if (!_context.Enderecos.Any(x => x.Id == endereco.Id)){
                throw new NotFoundException("Id not Found.");
            }

            try
            {
                endereco.DataAlteracao = DateTime.Now;
                _context.Enderecos.Update(endereco);
                await _context.SaveChangesAsync();
            }
            catch(DBUpdateConcurrencyException e)
            {
                throw new DBUpdateConcurrencyException(e.Message);
            }
        }

        public async Task<Endereco> BuscarPorIdAsync(long id)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Endereco>> BuscarTodosAsync()
        {
            if (!_context.Enderecos.Any())
            {
                return null;
            }
            return await _context.Enderecos.ToListAsync();
        }
        public async Task ExcluirAsync(long id)
        {
            Endereco endereco = await _context.Enderecos.FindAsync(id);
            if(endereco == null)
            {
                throw new NotFoundException("EnderecoId not found!");
            }

            try
            {
                _context.Remove(endereco);
                await _context.SaveChangesAsync();
            }
            catch(DBUpdateConcurrencyException e)
            {
                throw new DBUpdateConcurrencyException(e.Message);
            }
        }
    }
}
