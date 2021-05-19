using System;
using System.Collections.Generic;
using SistemaVendasWeb.Repository;

namespace SistemaVendasWeb.Models
{
    public class Funcionario : Usuario, IBasico<Funcionario> 
    {
        public string NumCarteiraTrabalho { get; set; }
        public Funcionario() 
            : base()
        {

        }
        public Funcionario(string nome, string email, string cpf, string telefone, string rg, string orgaoExpedidor, char sexo, string login, string senha, DateTime dataNascimento, DateTime dataInclusao, DateTime dataExclusao, DateTime dataAlteracao, string numCarteiraTrabalho) 
            : base(nome, email, cpf, telefone, rg, orgaoExpedidor, sexo, login, senha, dataNascimento, dataInclusao, dataExclusao, dataAlteracao)
        {
            NumCarteiraTrabalho = numCarteiraTrabalho;
        }
        public Funcionario Alterar(Funcionario t)
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        public void Incluir()
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> Listar()
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarPorIr(int id)
        {
            throw new NotImplementedException();
        }
    }
}
