using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaVendasWeb.Migrations
{
    public partial class Initial20210823 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(maxLength: 100, nullable: true),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    CEP = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: true),
                    NomeGuia = table.Column<string>(maxLength: 120, nullable: true),
                    URL = table.Column<string>(maxLength: 350, nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abreviacao = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 120, nullable: false),
                    Email = table.Column<string>(maxLength: 120, nullable: false),
                    CPF = table.Column<string>(maxLength: 15, nullable: false),
                    Telefone = table.Column<string>(maxLength: 15, nullable: false),
                    RG = table.Column<string>(maxLength: 10, nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Login = table.Column<string>(maxLength: 35, nullable: true),
                    Senha = table.Column<string>(maxLength: 35, nullable: true),
                    EnderecoId = table.Column<long>(nullable: true),
                    ImagemId = table.Column<long>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    OrgaoExpedidor = table.Column<string>(maxLength: 5, nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    NumCarteiraTrabalho = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Funcionario_Imagem_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Funcionario_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId",
                unique: true,
                filter: "[EnderecoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_ImagemId",
                table: "Funcionario",
                column: "ImagemId",
                unique: true,
                filter: "[ImagemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_StatusId",
                table: "Funcionario",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
