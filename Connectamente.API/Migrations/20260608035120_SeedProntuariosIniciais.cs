using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Connectamente.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProntuariosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentosClinicos_Pacientes_PacienteId",
                table: "DocumentosClinicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_Pacientes_PacienteId",
                table: "Prontuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosAnterioresPaciente_Prontuarios_ProntuarioModelId",
                table: "TratamentosAnterioresPaciente");

            migrationBuilder.RenameColumn(
                name: "ProntuarioModelId",
                table: "TratamentosAnterioresPaciente",
                newName: "ProntuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TratamentosAnterioresPaciente_ProntuarioModelId",
                table: "TratamentosAnterioresPaciente",
                newName: "IX_TratamentosAnterioresPaciente_ProntuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "TelefoneRecado",
                table: "Pacientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Pacientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Religiao",
                table: "Pacientes",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Pacientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Profissao",
                table: "Pacientes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Pacientes",
                keyColumn: "NomeCompleto",
                keyValue: null,
                column: "NomeCompleto",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Pacientes",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Naturalidade",
                table: "Pacientes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FamiliarResponsavelId",
                table: "Pacientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoNascimento",
                table: "Pacientes",
                type: "varchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoCivil",
                table: "Pacientes",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Escolaridade",
                table: "Pacientes",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoNumero",
                table: "Pacientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoLogradouro",
                table: "Pacientes",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEstado",
                table: "Pacientes",
                type: "varchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoCidade",
                table: "Pacientes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoCep",
                table: "Pacientes",
                type: "varchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoBairro",
                table: "Pacientes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Pacientes",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "InfosFamiliares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Ativo", "CPF", "DataAtualizacao", "DataCriacao", "DataNascimento", "Escolaridade", "EstadoCivil", "EstadoNascimento", "FamiliarResponsavelId", "Naturalidade", "NomeCompleto", "Profissao", "RG", "Religiao", "Sexo", "Telefone", "TelefoneRecado", "EnderecoBairro", "EnderecoCep", "EnderecoCidade", "EnderecoEstado", "EnderecoLogradouro", "EnderecoNumero" },
                values: new object[,]
                {
                    { 1, true, "12345678901", null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superior Completo", "Solteira", "MG", null, "Belo Horizonte", "Ana Silva Costa", "Engenheira", "MG1234567", null, "Feminino", "11999998888", null, "Centro", "01001000", "São Paulo", "SP", "Rua das Flores", "123" },
                    { 2, true, "98765432100", null, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Médio Completo", "Casado", "SP", null, "Campinas", "Carlos Eduardo Santos", "Comerciante", "SP7654321", null, "Masculino", "19988887777", null, "Jardins", "13010000", "Campinas", "SP", "Avenida Central", "99A" }
                });

            migrationBuilder.InsertData(
                table: "InfosFamiliares",
                columns: new[] { "Id", "CPF", "CondicaoConjugal", "DataNascimento", "Email", "GrauInstrucao", "NomeCompleto", "PacienteId", "Parentesco", "Profissao", "RG", "ResponsavelPrincipal", "Telefone", "EnderecoBairro", "EnderecoCep", "EnderecoCidade", "EnderecoEstado", "EnderecoLogradouro", "EnderecoNumero" },
                values: new object[,]
                {
                    { 1, "11122233344", null, new DateTime(1970, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Superior", "Roberto Silva Costa", 1, 1, "Administrador", null, true, "11988881111", "Centro", "01001000", "São Paulo", "SP", "Rua das Flores", "123" },
                    { 2, "22233344455", null, new DateTime(1973, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Superior", "Maria Aparecida Costa", 1, 2, "Professora", null, false, "11988882222", "Centro", "01001000", "São Paulo", "SP", "Rua das Flores", "123" },
                    { 3, "33344455566", null, new DateTime(1948, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fundamental", "Antônia Silva", 1, 4, "Aposentada", null, false, "11988883333", "Velho", "01002000", "São Paulo", "SP", "Avenida da Saudade", "50" },
                    { 4, "11122233344", null, new DateTime(1970, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Administrador", "Roberto Silva Costa", 2, 1, "Gerente", null, false, "11988881111", "Centro", "01001000", "São Paulo", "SP", "Rua das Flores", "123" },
                    { 5, "22233344455", null, new DateTime(1973, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Superior", "Maria Aparecida Costa", 2, 2, "Professora", null, false, "11988882222", "Centro", "01001000", "São Paulo", "SP", "Rua das Flores", "123" },
                    { 6, "33344455566", null, new DateTime(1948, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fundamental", "Antônia Silva", 2, 5, "Aposentada", null, true, "11988883333", "Velho", "01002000", "São Paulo", "SP", "Avenida da Saudade", "50" }
                });

            migrationBuilder.InsertData(
                table: "Prontuarios",
                columns: new[] { "Id", "Ativo", "DataAtualizacao", "DataCriacao", "DataPrimeiraConsulta", "NumeroProntuario", "ObservacoesGerais", "PacienteId", "SituacaoProntuario" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRONT-2026-0001", "Paciente encaminhada para acompanhamento psicológico padrão.", 1, 1 },
                    { 2, true, null, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRONT-2026-0002", "Paciente relata queixas relacionadas a estresse ocupacional severo.", 2, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentosClinicos_Pacientes_PacienteId",
                table: "DocumentosClinicos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_Pacientes_PacienteId",
                table: "Prontuarios",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosAnterioresPaciente_Prontuarios_ProntuarioId",
                table: "TratamentosAnterioresPaciente",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentosClinicos_Pacientes_PacienteId",
                table: "DocumentosClinicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_Pacientes_PacienteId",
                table: "Prontuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_TratamentosAnterioresPaciente_Prontuarios_ProntuarioId",
                table: "TratamentosAnterioresPaciente");

            migrationBuilder.DeleteData(
                table: "InfosFamiliares",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InfosFamiliares",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InfosFamiliares",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InfosFamiliares",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InfosFamiliares",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InfosFamiliares",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prontuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "ProntuarioId",
                table: "TratamentosAnterioresPaciente",
                newName: "ProntuarioModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TratamentosAnterioresPaciente_ProntuarioId",
                table: "TratamentosAnterioresPaciente",
                newName: "IX_TratamentosAnterioresPaciente_ProntuarioModelId");

            migrationBuilder.AlterColumn<string>(
                name: "TelefoneRecado",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Religiao",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Profissao",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Naturalidade",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FamiliarResponsavelId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstadoNascimento",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldMaxLength: 2,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoCivil",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Escolaridade",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoNumero",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoLogradouro",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEstado",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldMaxLength: 2,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoCidade",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoCep",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoBairro",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Pacientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "InfosFamiliares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentosClinicos_Pacientes_PacienteId",
                table: "DocumentosClinicos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_Pacientes_PacienteId",
                table: "Prontuarios",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TratamentosAnterioresPaciente_Prontuarios_ProntuarioModelId",
                table: "TratamentosAnterioresPaciente",
                column: "ProntuarioModelId",
                principalTable: "Prontuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
