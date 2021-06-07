using SistemaVendasWeb.Data;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVendasWeb.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Services
{
    public class FuncionarioService : IBasicoAsync<Funcionario>
    {
        private readonly SistemaVendasWebContext _context;

        public FuncionarioService(SistemaVendasWebContext context)
        {
            _context = context;
        }
        public async Task CriarAsync(Funcionario funcionario)
        {
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task<Funcionario> BuscarPorIdAsync(long id)
        {
            Funcionario funcionario = await _context.Funcionarios.Include(obj => obj.Status).FirstOrDefaultAsync(obj => obj.Id == id);
            if(funcionario == null)
            {
                return null;
            }
            return funcionario;
        }

        public async Task<ICollection<Funcionario>> BuscarTodosAsync()
        {
            if (! await _context.Funcionarios.AnyAsync())
            {
                return null;
            }
            return await _context.Funcionarios.Include(obj => obj.Status).ToListAsync(); 
        }

        public async Task ExcluirAsync(long id)
        {
            Funcionario funcionario = await _context.Funcionarios.FirstOrDefaultAsync(obj => obj.Id == id);
            if(funcionario == null)
            {
                throw new NotFoundException("Funcionario not found!");
            }

            try
            {
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
            catch (DBUpdateConcurrencyException e)
            {

                throw new DBUpdateConcurrencyException(e.Message);
            }
        }

 
    }
}
