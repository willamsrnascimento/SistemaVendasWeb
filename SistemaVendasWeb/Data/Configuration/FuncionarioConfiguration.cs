using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Data.Configuration
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.Property(obj => obj.Nome)
                   .IsRequired()
                   .HasMaxLength(120);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(120);

            builder.Property(p => p.CPF)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(p => p.Telefone)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(p => p.CPF)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(p => p.RG)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(p => p.RG)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(p => p.RG)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(p => p.OrgaoExpedidor)
                   .IsRequired()
                   .HasMaxLength(5);

            builder.Property(p => p.NumCarteiraTrabalho)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(p => p.Login)
                   .HasMaxLength(35);

            builder.Property(p => p.Senha)
                   .HasMaxLength(35);

            builder.Property(p => p.DataNascimento)
                   .IsRequired();

            builder.HasOne(obj => obj.Endereco)
                   .WithMany()
                   .HasForeignKey("EnderecoId")
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(obj => obj.Status)
                   .WithMany()
                   .HasForeignKey("StatusId")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
