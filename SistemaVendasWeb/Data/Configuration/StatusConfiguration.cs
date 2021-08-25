using SistemaVendasWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SistemaVendasWeb.Data.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.Property(s => s.Abreviacao)
                   .IsRequired();

            builder.Property(s => s.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.DataInclusao)
                   .IsRequired();

            builder.Property(s => s.DataAlteracao);

            builder.Property(s => s.DataExclusao);


        }
    }
}
