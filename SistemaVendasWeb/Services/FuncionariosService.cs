using SistemaVendasWeb.Data;
using SistemaVendasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Services
{
    public class FuncionariosService
    {
        private readonly SistemaVendasWebContext _context;

        public FuncionariosService(SistemaVendasWebContext context)
        {
            _context = context;
        }

        public List<Funcionario> BuscaTodos()
        {
            return _context.Funcionarios.ToList();
        }
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChanges();
        }
    }
}
