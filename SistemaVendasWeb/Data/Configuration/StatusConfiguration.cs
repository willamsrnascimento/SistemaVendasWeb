using SistemaVendasWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaVendasWeb.Data.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.Property(obj => obj.Abreviacao)
                   .IsRequired();

            builder.Property(obj => obj.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);
       
        }
    }
}
