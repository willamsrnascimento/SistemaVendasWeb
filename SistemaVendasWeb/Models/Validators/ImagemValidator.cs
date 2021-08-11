using FluentValidation;

namespace SistemaVendasWeb.Models.Validators
{
    public class ImagemValidator : AbstractValidator<Imagem>
    {
        public ImagemValidator()
        {
            RuleFor(i => i.URL)
                .MaximumLength(300);
        }
    }
}
