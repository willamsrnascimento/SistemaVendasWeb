﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaVendasWeb.Data;

namespace SistemaVendasWeb.Migrations
{
    [DbContext(typeof(SistemaVendasWebContext))]
    partial class SistemaVendasWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaVendasWeb.Models.ClasseTeste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("ClasseTeste");
                });

            modelBuilder.Entity("SistemaVendasWeb.Models.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("CEP");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("SistemaVendasWeb.Models.Funcionario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<DateTime>("DataInclusao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<long>("EnderecoId");

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("NumCarteiraTrabalho");

                    b.Property<string>("OrgaoExpedidor");

                    b.Property<string>("RG");

                    b.Property<string>("Senha");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<long>("StatusId");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("StatusId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("SistemaVendasWeb.Models.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abreviacao")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<DateTime>("DataInclusao");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("SistemaVendasWeb.Models.Funcionario", b =>
                {
                    b.HasOne("SistemaVendasWeb.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaVendasWeb.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
