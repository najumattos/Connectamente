using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Connectamente.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentoTermoEstagiario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PsicologoResponsavelId",
                table: "Prontuarios",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TermosResponsabilidadeEstagiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstagiarioUsuarioId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MatriculaInformada = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeclarouRecebimentoManual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeclarouCienciaNormas = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataAssinatura = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermosResponsabilidadeEstagiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermosResponsabilidadeEstagiarios_AspNetUsers_EstagiarioUsua~",
                        column: x => x.EstagiarioUsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ativo", "ConcurrencyStamp", "Cpf", "Crp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Matricula", "NomeCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TipoUsuario", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18fbcde-1111-42b1-b4fa-4b8c0c45daaa", 0, true, "c741a86a-dcf9-4279-9a42-82e3747bfd93", "12345678901", "06/12345-6", "mariana.admin@connectamente.com", true, false, null, "PR99955", "Profª. Dra. Mariana Silva", "MARIANA.ADMIN@CONNECTAMENTE.COM", "MARIANA.ADMIN@CONNECTAMENTE.COM", "AQAAAAIAAYagAAAAEDoIXKfB9IJ4sohgbpJSkmvnEKE/0Q+iiBSiLlCIC+eTw+PxaqvRQisWf7ccQ1smtQ==", null, false, "55cb01dc-9dd6-4805-bcf3-151c1b07d459", 1, false, "mariana.admin@connectamente.com" },
                    { "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb", 0, true, "616b8143-a4fb-4a9b-8638-0513abef2347", "98765432100", null, "gabriel.aluno@connectamente.com", true, false, null, "AL202611", "Gabriel Soares Santos", "GABRIEL.ALUNO@CONNECTAMENTE.COM", "GABRIEL.ALUNO@CONNECTAMENTE.COM", "AQAAAAIAAYagAAAAEDJ/66LQ66Qmy3+qT69GE8FJ33GG+OCHk6qqumsYYj+U8tWZRvrXptpzJgnFmbqXtQ==", null, false, "148ee0b3-25c1-44fd-8056-3a955c5b9e99", 2, false, "gabriel.aluno@connectamente.com" }
                });

            migrationBuilder.UpdateData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PsicologoResponsavelId",
                value: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb");

            migrationBuilder.UpdateData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PsicologoResponsavelId",
                value: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_PsicologoResponsavelId",
                table: "Prontuarios",
                column: "PsicologoResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_TermosResponsabilidadeEstagiarios_EstagiarioUsuarioId",
                table: "TermosResponsabilidadeEstagiarios",
                column: "EstagiarioUsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_AspNetUsers_PsicologoResponsavelId",
                table: "Prontuarios",
                column: "PsicologoResponsavelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_AspNetUsers_PsicologoResponsavelId",
                table: "Prontuarios");

            migrationBuilder.DropTable(
                name: "TermosResponsabilidadeEstagiarios");

            migrationBuilder.DropIndex(
                name: "IX_Prontuarios_PsicologoResponsavelId",
                table: "Prontuarios");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18fbcde-1111-42b1-b4fa-4b8c0c45daaa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb");

            migrationBuilder.DropColumn(
                name: "PsicologoResponsavelId",
                table: "Prontuarios");

            migrationBuilder.UpdateData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ativo",
                value: true);
        }
    }
}
