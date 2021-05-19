using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendasWeb.Repository;

namespace SistemaVendasWeb.Models
{
    public abstract class Usuario : IUsuario
    {
        public long Id => throw new NotImplementedException();
        public string Nome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CPF { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Telefone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RG { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OrgaoExpedidor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public char Sexo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Login { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Senha { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataNascimento { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataInclusao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataExclusao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataAlteracao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Usuario()
        {

        }
        public Usuario(string nome, string email, string cpf, string telefone, string rg, string orgaoExpedidor, char sexo, string login, string senha, DateTime dataNascimento, DateTime dataInclusao, DateTime dataExclusao, DateTime dataAlteracao)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            Telefone = telefone;
            RG = rg;
            OrgaoExpedidor = orgaoExpedidor;
            Sexo = sexo;
            Login = login;
            Senha = senha;
            DataNascimento = dataNascimento;
            DataInclusao = dataInclusao;
            DataExclusao = dataExclusao;
            DataAlteracao = dataAlteracao;
        }

    }
}
