using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Models
{
    public class Endereco
    {
        public long Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public Endereco()
        {

        }

        public Endereco(long id, string rua, int numero, string complemento, string cEP, string bairro, string cidade)
        {
            Id = id;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            CEP = cEP;
            Bairro = bairro; 
            Cidade = cidade;          
        }
    }
}
