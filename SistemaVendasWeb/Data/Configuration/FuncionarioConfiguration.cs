using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendasWeb.Models;

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

            builder.HasOne(f => f.Endereco)
                   .WithOne(e => e.Funcionario)
                   .HasForeignKey<Funcionario>(f => f.EnderecoId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(f => f.Status)
                   .WithMany()
                   .HasForeignKey("StatusId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Imagem)
                   .WithOne(i => i.Funcionario)
                   .HasForeignKey<Funcionario>(f => f.ImagemId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
