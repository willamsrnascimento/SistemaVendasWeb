using SistemaVendasWeb.Data;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVendasWeb.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SistemaVendasWeb.Models.Enums;

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
            Funcionario funcionario = await _context.Funcionarios.Include(obj => obj.Status).Include(obj => obj.Endereco).FirstOrDefaultAsync(obj => obj.Id == id);
            if(funcionario == null)
            {
                return null;
            }
            return funcionario;
        }

        public async Task<List<Funcionario>> BuscarTodosAsync()
        {
            if (! await _context.Funcionarios.AnyAsync())
            {
                return null;
            }
            return await _context.Funcionarios.OrderBy(obj => obj.Nome).Include(obj => obj.Status).ToListAsync(); 
        }

        public async Task<List<Funcionario>> BuscarPorFiltroAsync(Filtros sFiltro, string txtProcurar)
        {
            var result = from obj in _context.Funcionarios select obj;

            switch (sFiltro)
            {
                case Filtros.Nome:
                    result = result.Where(obj => obj.Nome.ToUpper().Contains(txtProcurar.ToUpper()));
                    break;
                case Filtros.Email:
                    result = result.Where(obj => obj.Email.ToUpper().Contains(txtProcurar.ToUpper()));
                    break;
                case Filtros.Telefone:
                    result = result.Where(obj => obj.Telefone.ToUpper().Contains(txtProcurar.ToUpper()));
                    break;
                default:
                    Console.WriteLine("Nenhum filtro selecionado!!");
                    break;
            }

            return await result.Include(obj => obj.Status).ToListAsync();
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
