using FluentValidation;
using System;
using System.Globalization;

namespace SistemaVendasWeb.Models.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(f => f.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(120)
                .WithName("Nome do Funcionário");

            RuleFor(f => f.Email)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(100)
                .EmailAddress()
                .WithName("E-mail do Funcionário");

            RuleFor(f => f.Telefone)
                .NotEmpty()
                .NotNull()
                .MinimumLength(14)
                .MaximumLength(15)
                .WithName("Telefone do Funcionário");

            RuleFor(f => f.RG)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9)
                .WithName("RG do Funcionário");

            RuleFor(f => f.OrgaoExpedidor)
                .NotEmpty()
                .NotNull()
                .MaximumLength(5)
                .WithName("Orgão Expedidor");

            RuleFor(f => f.CPF)
                .NotEmpty()
                .NotNull()
                .Length(14)
                .WithMessage("CPF deve ter exatamente 14 caracteres.")
                .WithName("CPF do Funcionário");

            RuleFor(f => f.NumCarteiraTrabalho)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .WithName("Carteira de Trabalho do Funcionário.");

            RuleFor(f => f.DataNascimento)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTime.Now.AddYears(-18))
                .WithMessage("Você precisa ser maior de 18 anos.")
                .WithName("Data de Nascimento");

            RuleFor(f => f.Sexo)
                .NotEmpty()
                .NotNull()
                .Must(VerificaSexo)
                .WithName("Sexo do Funcionário");

        }

        private bool VerificaSexo(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }

        private bool VerificaDataNascimento(DateTime date)
        {
            DateTime data1 = DateTime.Now.AddYears(-18);
            if(date <= data1)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return date <= DateTime.Now.AddYears(-18);
        }
    }
}
