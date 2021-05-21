using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVendasWeb.Models;

namespace SistemaVendasWeb.Data
{
    public class SistemaVendasWebContext : DbContext
    {
        public SistemaVendasWebContext (DbContextOptions<SistemaVendasWebContext> options)
            : base(options)
        {
        }

        public DbSet<ClasseTeste> ClasseTeste { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
