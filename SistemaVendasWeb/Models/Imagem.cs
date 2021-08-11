using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Models
{
    public class Imagem
    {
        public long Id { get; set; }
        public string URL { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataExclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Imagem()
        {
        }

        public Imagem(long id, string url, DateTime dataInclusao, DateTime dataExclusao, DateTime dataAlteracao)
        {
            Id = id;
            URL = url;
            DataInclusao = dataInclusao;
            DataExclusao = dataExclusao;
            DataAlteracao = dataAlteracao;
        }
    }
}
