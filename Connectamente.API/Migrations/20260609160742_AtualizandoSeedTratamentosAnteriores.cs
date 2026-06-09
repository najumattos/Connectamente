using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connectamente.API.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoSeedTratamentosAnteriores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TratamentosAnterioresPaciente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataCriacao", "MotivoInternacao", "Observacoes", "PacienteId", "ProntuarioId", "TipoTratamento" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Problema no coração", "Doente de amor procurou remedio na vida noturna", 1, 1, 4 });

            migrationBuilder.InsertData(
                table: "TratamentosAnterioresPaciente",
                columns: new[] { "Id", "Ativo", "DataAtualizacao", "DataCriacao", "Internacao", "MotivoInternacao", "Observacoes", "PacienteId", "ProntuarioId", "TipoTratamento" },
                values: new object[] { 3, true, null, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, "Surto psicótico agudo decorrente de estresse severo em ambiente corporativo.", "Paciente ficou internado por 15 dias na clínica Restaurar em agosto de 2025. Faz uso de medicação controlada.", 2, 2, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TratamentosAnterioresPaciente",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "TratamentosAnterioresPaciente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataCriacao", "MotivoInternacao", "Observacoes", "PacienteId", "ProntuarioId", "TipoTratamento" },
                values: new object[] { new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Surto psicótico agudo decorrente de estresse severo em ambiente corporativo.", "Paciente ficou internado por 15 dias na clínica Restaurar em agosto de 2025. Faz uso de medicação controlada.", 2, 2, 3 });
        }
    }
}
