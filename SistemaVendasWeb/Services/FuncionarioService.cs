using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVendasWeb.Repository;

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
            throw new NotImplementedException();
        }

        public ICollection<Funcionario> BuscarTodos()
        {
            if (!_context.Funcionarios.Any())
            {
                return null;
            }
            return _context.Funcionarios.ToList(); ;
        }

        public void Excluir(long id)
        {
            throw new NotImplementedException();
        }

 
    }
}
