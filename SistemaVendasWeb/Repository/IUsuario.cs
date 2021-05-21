using System;
using SistemaVendasWeb.Models;

namespace SistemaVendasWeb.Repository
{
    interface IUsuario 
    {
        string Nome { get; set; }
        string Email { get; set; }
        string CPF { get; set; }
        string Telefone { get; set; }
        string RG { get; set; }
        string OrgaoExpedidor { get; set; }
        char Sexo { get; set; }
        string Login { get; set; }
        string Senha { get; set; }
        Endereco Endereco { get; set; }
        DateTime DataNascimento { get; set; }
        DateTime DataInclusao { get; set; }
        DateTime DataExclusao { get; set; }
        DateTime DataAlteracao { get; set; }

    }
}
