using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connectamente.API.Migrations
{
    /// <inheritdoc />
    public partial class Versao022810 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Prontuarios_ProntuarioId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentosClinicos_Atendimentos_AtendimentoId",
                table: "DocumentosClinicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Familiares_Prontuarios_ProntuarioId",
                table: "Familiares");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_AspNetUsers_PsicologoResponsavelId",
                table: "Prontuarios");

            migrationBuilder.DropIndex(
                name: "IX_Prontuarios_PsicologoResponsavelId",
                table: "Prontuarios");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CPF",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataPrimeiraConsulta",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "PsicologoResponsavelId",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "SituacaoProntuario",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProntuarioId",
                table: "Familiares",
                newName: "PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Familiares_ProntuarioId",
                table: "Familiares",
                newName: "IX_Familiares_PacienteId");

            migrationBuilder.RenameColumn(
                name: "ProntuarioId",
                table: "Atendimentos",
                newName: "VinculoPacientePsicologoId");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_ProntuarioId",
                table: "Atendimentos",
                newName: "IX_Atendimentos_VinculoPacientePsicologoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "TratamentosAnteriores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "TratamentosAnteriores",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "TratamentosAnteriores",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Prontuarios",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Prontuarios",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Prontuarios",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Prontuarios",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlantaoId",
                table: "Prontuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Genero",
                table: "Pacientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_EstadoCivil",
                table: "Pacientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Escolaridade",
                table: "Pacientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Pacientes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Pacientes",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "SituacaoPaciente",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "TermoAutorizacaoMenor",
                table: "Familiares",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Genero",
                table: "Familiares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_EstadoCivil",
                table: "Familiares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Escolaridade",
                table: "Familiares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Familiares",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Familiares",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "DocumentosClinicos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "DocumentosClinicos",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "DocumentosClinicos",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantaoId",
                table: "DocumentosClinicos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioEmail",
                table: "Auditorias",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Atendimentos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Atendimentos",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Atendimentos",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.CreateTable(
                name: "AtendimentosRealizados",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false),
                    ProntuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosRealizados", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_AtendimentosRealizados_Atendimentos_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtendimentosRealizados_Prontuarios_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VinculosPacientePsicologo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    PsicologoResponsavelId = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusVinculo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataEncerramento = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculosPacientePsicologo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculosPacientePsicologo_AspNetUsers_PsicologoResponsavelId",
                        column: x => x.PsicologoResponsavelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VinculosPacientePsicologo_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plantoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    VinculoPacientePsicologoId = table.Column<int>(type: "int", nullable: false),
                    StatusPlantao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantoes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plantoes_VinculosPacientePsicologo_VinculoPacientePsicologoId",
                        column: x => x.VinculoPacientePsicologoId,
                        principalTable: "VinculosPacientePsicologo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "role-0003-secretaria-00-000000000003", "a1b2c3d4-0003-0003-0003-000000000003", "Secretaria", "SECRETARIA" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ativo", "ConcurrencyStamp", "Crp", "DataCadastro", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Matricula", "NomeCompleto", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a489f241-4fad-4031-b458-6f6ce664f13d", 0, true, "a5c92e41-7b83-4d60-9f12-6e4a8b3c5670", null, new DateTime(2026, 5, 29, 11, 0, 0, 0, DateTimeKind.Utc), "ana.secretaria@connectamente.com", true, false, null, "AL202666", "Ana Julia Mattos", "ANA.SECRETARIA@CONNECTAMENTE.COM", "ANA.SECRETARIA@CONNECTAMENTE.COM", "AQAAAAEAACcQAAAAEBaLWoe8u2D3VTbHYh5Puil95h2FDKPyVzQ6nCEtjK6IsOR7xd8SUKsCgQoLWjKeTA==", "14999193088", false, "d8a71c32-4f65-4e91-a2b3-7c6d9e0f1234", false, "ana.secretaria@connectamente.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role-0003-secretaria-00-000000000003", "a489f241-4fad-4031-b458-6f6ce664f13d" });

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_PlantaoId",
                table: "Prontuarios",
                column: "PlantaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosClinicos_PlantaoId",
                table: "DocumentosClinicos",
                column: "PlantaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosRealizados_ProntuarioId",
                table: "AtendimentosRealizados",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantoes_PacienteId",
                table: "Plantoes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantoes_VinculoPacientePsicologoId",
                table: "Plantoes",
                column: "VinculoPacientePsicologoId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculosPacientePsicologo_PacienteId",
                table: "VinculosPacientePsicologo",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculosPacientePsicologo_PsicologoResponsavelId",
                table: "VinculosPacientePsicologo",
                column: "PsicologoResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_VinculosPacientePsicologo_VinculoPacientePsicol~",
                table: "Atendimentos",
                column: "VinculoPacientePsicologoId",
                principalTable: "VinculosPacientePsicologo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentosClinicos_AtendimentosRealizados_AtendimentoId",
                table: "DocumentosClinicos",
                column: "AtendimentoId",
                principalTable: "AtendimentosRealizados",
                principalColumn: "AgendamentoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentosClinicos_Plantoes_PlantaoId",
                table: "DocumentosClinicos",
                column: "PlantaoId",
                principalTable: "Plantoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Familiares_Pacientes_PacienteId",
                table: "Familiares",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_Plantoes_PlantaoId",
                table: "Prontuarios",
                column: "PlantaoId",
                principalTable: "Plantoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_VinculosPacientePsicologo_VinculoPacientePsicol~",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentosClinicos_AtendimentosRealizados_AtendimentoId",
                table: "DocumentosClinicos");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentosClinicos_Plantoes_PlantaoId",
                table: "DocumentosClinicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Familiares_Pacientes_PacienteId",
                table: "Familiares");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_Plantoes_PlantaoId",
                table: "Prontuarios");

            migrationBuilder.DropTable(
                name: "AtendimentosRealizados");

            migrationBuilder.DropTable(
                name: "Plantoes");

            migrationBuilder.DropTable(
                name: "VinculosPacientePsicologo");

            migrationBuilder.DropIndex(
                name: "IX_Prontuarios_PlantaoId",
                table: "Prontuarios");

            migrationBuilder.DropIndex(
                name: "IX_DocumentosClinicos_PlantaoId",
                table: "DocumentosClinicos");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role-0003-secretaria-00-000000000003", "a489f241-4fad-4031-b458-6f6ce664f13d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-0003-secretaria-00-000000000003");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a489f241-4fad-4031-b458-6f6ce664f13d");

            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "PlantaoId",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "SituacaoPaciente",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PlantaoId",
                table: "DocumentosClinicos");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Familiares",
                newName: "ProntuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Familiares_PacienteId",
                table: "Familiares",
                newName: "IX_Familiares_ProntuarioId");

            migrationBuilder.RenameColumn(
                name: "VinculoPacientePsicologoId",
                table: "Atendimentos",
                newName: "ProntuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_VinculoPacientePsicologoId",
                table: "Atendimentos",
                newName: "IX_Atendimentos_ProntuarioId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "TratamentosAnteriores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "TratamentosAnteriores",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "TratamentosAnteriores",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Prontuarios",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Prontuarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrimeiraConsulta",
                table: "Prontuarios",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PsicologoResponsavelId",
                table: "Prontuarios",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SituacaoProntuario",
                table: "Prontuarios",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Ativo")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Genero",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_EstadoCivil",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Escolaridade",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Pacientes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Pacientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "TermoAutorizacaoMenor",
                table: "Familiares",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Genero",
                table: "Familiares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_EstadoCivil",
                table: "Familiares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacao_Escolaridade",
                table: "Familiares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Familiares",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Familiares",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "DocumentosClinicos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "DocumentosClinicos",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "DocumentosClinicos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.UpdateData(
                table: "Auditorias",
                keyColumn: "UsuarioEmail",
                keyValue: null,
                column: "UsuarioEmail",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioEmail",
                table: "Auditorias",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Atendimentos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Atendimentos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Atendimentos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "AspNetUsers",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TipoUsuario",
                table: "AspNetUsers",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "328b3ebd-50e0-4df8-945e-46540a064859",
                columns: new[] { "Cpf", "TipoUsuario" },
                values: new object[] { "12345678901", "Professor" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb",
                columns: new[] { "Cpf", "TipoUsuario" },
                values: new object[] { "98765432100", "Aluno" });

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_PsicologoResponsavelId",
                table: "Prontuarios",
                column: "PsicologoResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CPF",
                table: "AspNetUsers",
                column: "Cpf",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Prontuarios_ProntuarioId",
                table: "Atendimentos",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentosClinicos_Atendimentos_AtendimentoId",
                table: "DocumentosClinicos",
                column: "AtendimentoId",
                principalTable: "Atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Familiares_Prontuarios_ProntuarioId",
                table: "Familiares",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_AspNetUsers_PsicologoResponsavelId",
                table: "Prontuarios",
                column: "PsicologoResponsavelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
