using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Models.ViewModels
{
    public class FuncionarioViewModel
    {
        public Funcionario Funcionario { get; set; }
        public List<Status> Status { get; set; }
        public Imagem Imagem { get; set; }
    }
}
