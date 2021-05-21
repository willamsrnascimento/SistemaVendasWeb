﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendasWeb.Repository;

namespace SistemaVendasWeb.Models
{
    public abstract class Usuario : IUsuario
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string RG { get; set; }
        public string OrgaoExpedidor { get; set; }
        public char Sexo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }
        public Status Status { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataExclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Usuario()
        {

        }
        public Usuario(string nome, string email, string cpf, string telefone, string rg, string orgaoExpedidor, char sexo, string login, string senha, Endereco endereco, Status status, DateTime dataNascimento, DateTime dataInclusao, DateTime dataExclusao, DateTime dataAlteracao)
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
            Endereco = endereco;
            Status = status;
        }

        
    }
}
