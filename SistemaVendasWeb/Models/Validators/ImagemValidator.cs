using FluentValidation;

namespace SistemaVendasWeb.Models.Validators
{
    public class ImagemValidator : AbstractValidator<Imagem>
    {
        public ImagemValidator()
        {
            RuleFor(i => i.Nome)
                .MaximumLength(60);

            RuleFor(i => i.NomeGuia)
                .MaximumLength(120);

            RuleFor(i => i.URL)
                .MaximumLength(350);
        }
    }
}
