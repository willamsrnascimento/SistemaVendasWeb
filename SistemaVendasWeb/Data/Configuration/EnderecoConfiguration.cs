using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendasWeb.Models;

namespace SistemaVendasWeb.Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.Property(e => e.Rua)
                   .HasMaxLength(100);

            builder.Property(e => e.Numero)
                   .HasMaxLength(10);

            builder.Property(e => e.Complemento)
                   .HasMaxLength(100);

            builder.Property(e => e.CEP)
                   .HasMaxLength(10);

            builder.Property(e => e.Bairro)
                   .HasMaxLength(100);

            builder.Property(e => e.Cidade)
                   .HasMaxLength(100);

            builder.HasOne(e => e.Funcionario)
                   .WithOne(f => f.Endereco)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
