using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Models
{
    public class Imagem
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string NomeGuia { get; set; }
        public string URL { get; set; } 
        public Funcionario Funcionario { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataExclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Imagem()
        {
        }

        public Imagem(long id, string nome, string nomeGuia, string url, DateTime dataInclusao, DateTime dataExclusao, DateTime dataAlteracao)
        {
            Id = id;
            Nome = nome;
            NomeGuia = nomeGuia;
            URL = url;
            DataInclusao = dataInclusao;
            DataExclusao = dataExclusao;
            DataAlteracao = dataAlteracao;
        }
    }
}
