using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Models.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.Rua)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .WithName("Rua");

            RuleFor(e => e.Numero)
                .NotEmpty()
                .WithMessage("O número deve ser preenchido. Caso não haja número para o endereço, você deve colocar \"N/A\"")
                .NotNull()
                .MaximumLength(10)
                .WithName("Número");

            RuleFor(e => e.Complemento)
                .MaximumLength(100)
                .WithName("Complemento");

            RuleFor(e => e.CEP)
                .NotEmpty()
                .NotNull()
                .Length(10)
                .WithMessage("O CEP deve ter exatamento 10 caracteres incluindo pontos (.) e hífem (-).")
                .WithName("CEP");

            RuleFor(e => e.Bairro)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Bairro");

            RuleFor(e => e.Cidade)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .MaximumLength(100)
               .WithName("Cidade");

        }
    }
}
