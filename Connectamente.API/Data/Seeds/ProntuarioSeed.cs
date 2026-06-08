using Connectamente.API.Enums;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public static class ProntuarioSeed
{
    public static void Seed(EntityTypeBuilder<ProntuarioModel> builder)
    {
        builder.HasData(
            new ProntuarioModel
            {
                Id = 1,
                PacienteId = 1, // Vinculado à Ana Silva Costa
                NumeroProntuario = "PRONT-2026-0001",
                DataPrimeiraConsulta = new DateTime(2026, 1, 1),
                SituacaoProntuario = SituacaoProntuarioEnum.Ativo,
                ObservacoesGerais = "Paciente encaminhada para acompanhamento psicológico padrão.",
                DataCriacao = new DateTime(2026, 1, 1),
                Ativo = true,
                PsicologoResponsavelId = "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb"
            },
            new ProntuarioModel
            {
                Id = 2,
                PacienteId = 2, // Vinculado ao Carlos Eduardo Santos
                NumeroProntuario = "PRONT-2026-0002",
                DataPrimeiraConsulta = new DateTime(2026, 1, 2),
                SituacaoProntuario = SituacaoProntuarioEnum.Ativo,
                ObservacoesGerais = "Paciente relata queixas relacionadas a estresse ocupacional severo.",
                DataCriacao = new DateTime(2026, 1, 2),
                Ativo = true,
                PsicologoResponsavelId = "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb"
            }
        );
    }
}