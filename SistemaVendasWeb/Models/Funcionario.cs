using System;
using System.Collections.Generic;
using SistemaVendasWeb.Repository;

namespace SistemaVendasWeb.Models
{
    public class Funcionario : Usuario
    {
        public string NumCarteiraTrabalho { get; set; }
        public Funcionario() 
            : base()
        {

        }
        public Funcionario(long id, string nome, string email, string cpf, string telefone, string rg, string orgaoExpedidor, char sexo, string login, string senha, Endereco endereco, Status status, DateTime dataNascimento, DateTime dataInclusao, DateTime dataExclusao, DateTime dataAlteracao, string numCarteiraTrabalho) 
            : base(id, nome, email, cpf, telefone, rg, orgaoExpedidor, sexo, login, senha, endereco, status, dataNascimento, dataInclusao, dataExclusao, dataAlteracao)
        {
            NumCarteiraTrabalho = numCarteiraTrabalho;
        }
        
    }
}
