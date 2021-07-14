using FluentValidation;
using System;

namespace SistemaVendasWeb.Models.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(obj => obj.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(120)
                .WithName("Nome do Funcionário");

            RuleFor(obj => obj.Email)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(100)
                .EmailAddress()
                .WithName("E-mail do Funcionário");

            RuleFor(obj => obj.Telefone)
                .NotEmpty()
                .NotNull()
                .MinimumLength(14)
                .MaximumLength(15)
                .WithName("Telefone do Funcionário");

            RuleFor(obj => obj.RG)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9)
                .WithName("RG do Funcionário");

            RuleFor(obj => obj.OrgaoExpedidor)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10)
                .WithName("Orgão Expedidor");

            RuleFor(obj => obj.CPF)
                .NotEmpty()
                .NotNull()
                .Length(14)
                .WithMessage("CPF deve ter exatamente 14 caracteres.")
                .WithName("CPF do Funcionário");

            RuleFor(obj => obj.NumCarteiraTrabalho)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .WithName("Carteira de Trabalho do Funcionário");

            RuleFor(obj => obj.DataNascimento)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTime.Now.AddYears(-18))
                .WithName("Data de Nascimento");

            RuleFor(obj => obj.Sexo)
                .NotEmpty()
                .NotNull()
                .Must(VerificaSexo)
                .WithName("Sexo do Funcionário");

        }

        private bool VerificaSexo(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}
