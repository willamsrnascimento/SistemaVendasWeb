﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SistemaVendasWeb.Repository;

namespace SistemaVendasWeb.Models
{
    public class Funcionario : Usuario
    {
        [Display(Name = "Carteira de Trabalho")]
        public string NumCarteiraTrabalho { get; set; }
        public Funcionario() 
            : base()
        {

        }
        public Funcionario(long id, string nome, string email, string cpf, string telefone, string rg, string orgaoExpedidor, char sexo, string login, string senha, Endereco endereco, Status status, Imagem imagem, DateTime dataNascimento, DateTime dataInclusao, DateTime dataExclusao, DateTime dataAlteracao, string numCarteiraTrabalho) 
            : base(id, nome, email, cpf, telefone, rg, orgaoExpedidor, sexo, login, senha, endereco, status, imagem, dataNascimento, dataInclusao, dataExclusao, dataAlteracao)
        {
            NumCarteiraTrabalho = numCarteiraTrabalho;
        }
        
    }
}
