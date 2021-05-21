using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVendasWeb.Models;

namespace SistemaVendasWeb.Data
{
    public class SeedingService
    {
        private SistemaVendasWebContext _context;
        
        public SeedingService(SistemaVendasWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Enderecos.Any() || 
                _context.Status.Any() ||
                _context.Funcionarios.Any())
            {
                Console.WriteLine("Data already exists!");
                return;
            }

            Status s1 = new Status(1, 'A', "Ativo", new DateTime(2021, 05, 21), new DateTime(), new DateTime());
            Status s2 = new Status(2, 'I', "Inativo", new DateTime(2021, 05, 21), new DateTime(), new DateTime());
            Status s3 = new Status(3, 'D', "Deletado", new DateTime(2021, 05, 21), new DateTime(), new DateTime());

            Endereco e1 = new Endereco(1, "Jose Moscow", 3, "Bloco 10, Apto 1", "555", "Candeias", "Jaboatao");
            Endereco e2 = new Endereco(2, "Caracol", 702, "Bloco 5, Apto 123", "444", "Candeias", "Jaboatao");
            Endereco e3 = new Endereco(3, "Rua Carangueijo", 55, "N/A", "222", "Caxangá", "Recife");

            Funcionario f1 = new Funcionario(1, "Raul Gil", "raul@gmail.com", "111", "81888888", "111", "SDS", 'M', "raul", "123", e1, s1, new DateTime(1999, 05, 01), new DateTime(2021, 05, 21), new DateTime(), new DateTime(), "1111111");
            Funcionario f2 = new Funcionario(2, "Carlos Alberto", "carlos@gmail.com", "222", "8122222", "222", "SDS", 'M', "carlos", "123", e2, s2, new DateTime(1899, 12, 03), new DateTime(2021, 05, 21), new DateTime(), new DateTime(), "444444");
            Funcionario f3 = new Funcionario(3, "Maria Lurdes", "maria@gmail.com", "222", "21333333", "333", "SDS", 'F', "maria", "123", e3, s3, new DateTime(2000, 07, 21), new DateTime(2021, 05, 21), new DateTime(), new DateTime(), "555555");

            _context.Status.AddRange(s1, s2, s3);
            _context.Enderecos.AddRange(e1, e2, e3);
            _context.Funcionarios.AddRange(f1, f2, f3);

            _context.SaveChanges();

        }

    }
}
