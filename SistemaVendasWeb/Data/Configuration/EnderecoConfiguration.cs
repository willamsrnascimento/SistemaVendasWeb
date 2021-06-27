using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            builder.Property(obj => obj.Rua)
                   .HasMaxLength(100);

            builder.Property(obj => obj.Numero)
                   .HasMaxLength(10);

            builder.Property(obj => obj.Complemento)
                   .HasMaxLength(100);

            builder.Property(obj => obj.CEP)
                   .HasMaxLength(10);

            builder.Property(obj => obj.Bairro)
                   .HasMaxLength(100);

            builder.Property(obj => obj.Cidade)
                   .HasMaxLength(100);
        }
    }
}
