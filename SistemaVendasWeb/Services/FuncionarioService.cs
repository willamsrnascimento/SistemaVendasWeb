using SistemaVendasWeb.Data;
using SistemaVendasWeb.Services.Exception;
using SistemaVendasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVendasWeb.Repository;
using Microsoft.EntityFrameworkCore;

namespace SistemaVendasWeb.Services
{
    public class FuncionarioService : IBasico<Funcionario>
    {
        private readonly SistemaVendasWebContext _context;

        public FuncionarioService(SistemaVendasWebContext context)
        {
            _context = context;
        }
        public void Criar(Funcionario funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChanges();
        }

        public void Atualizar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Funcionario BuscarPorId(long id)
        {
            Funcionario funcionario = _context.Funcionarios.Include(obj => obj.Status).FirstOrDefault(obj => obj.Id == id);
            if(funcionario == null)
            {
                return null;
            }
            return funcionario;
        }

        public ICollection<Funcionario> BuscarTodos()
        {
            if (!_context.Funcionarios.Any())
            {
                return null;
            }
            return _context.Funcionarios.Include(obj => obj.Status).ToList(); 
        }

        public void Excluir(long id)
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(obj => obj.Id == id);
            if(funcionario == null)
            {
                throw new NotFoundException("Funcionario not found!");
            }
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }

 
    }
}
