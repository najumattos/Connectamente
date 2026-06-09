using Connectamente.API.Enums;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public class TratamentoAnteriorSeed : IEntityTypeConfiguration<TratamentoAnteriorModel>
{
    public void Configure(EntityTypeBuilder<TratamentoAnteriorModel> builder)
    {
        builder.HasData(
            new TratamentoAnteriorModel
            {
                Id = 1,
                PacienteId = 1, // Vinculado à Ana Silva Costa
                ProntuarioId = 1, // Vinculado ao Prontuário PRONT-2026-0001
                TipoTratamento = TipoTratamentoAnteriorEnum.Psicologico,
                Internacao = false,
                MotivoInternacao = null,
                Observacoes = "Realizou 6 meses de terapia cognitivo-comportamental em 2024 devido a crises de ansiedade.",
                DataCriacao = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Ativo = true
            },
            new TratamentoAnteriorModel
            {
                Id = 2,
                PacienteId = 2, // Vinculado ao Carlos Eduardo Santos
                ProntuarioId = 2, // Vinculado ao Prontuário PRONT-2026-0002
                TipoTratamento = TipoTratamentoAnteriorEnum.Psiquiatrico, 
                Internacao = true,
                MotivoInternacao = "Surto psicótico agudo decorrente de estresse severo em ambiente corporativo.",
                Observacoes = "Paciente ficou internado por 15 dias na clínica Restaurar em agosto de 2025. Faz uso de medicação controlada.",
                DataCriacao = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                Ativo = true
            }
        );
    }
}