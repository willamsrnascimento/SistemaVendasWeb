using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Models
{
    public class Status
    {
        public long Id { get; private set; }
        public char Abreviacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataExclusao { get; set; }

        public Status()
        {
        }
        public Status(long id, char abreviacao, string descricao, DateTime dataInclusao, DateTime dataAlteracao, DateTime dataExclusao)
        {
            Id = id;
            Abreviacao = abreviacao;
            Descricao = descricao;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
            DataExclusao = dataExclusao;
        }
    }
}
