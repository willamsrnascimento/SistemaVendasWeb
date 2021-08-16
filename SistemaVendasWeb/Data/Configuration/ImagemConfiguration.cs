using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendasWeb.Models;

namespace SistemaVendasWeb.Data.Configuration
{
    public class ImagemConfiguration : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.ToTable("Imagem");

            builder.Property(i => i.Nome)
                .HasMaxLength(60);

            builder.Property(i => i.NomeGuia)
                .HasMaxLength(120);

            builder.Property(i => i.URL)
                .HasMaxLength(350);
        }
    }
}
