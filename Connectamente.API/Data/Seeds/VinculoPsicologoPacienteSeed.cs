using Connectamente.API.Enums;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Data.Seeds;

public static class VinculoPsicologoPacienteSeed
{
    private const string PsicologoId = "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb";

    public static void Seed(DbContext context)
    {
        var vinculos = context.Set<VinculoPacientePsicologoModel>();

        if (!vinculos.Any(vinculo =>
                vinculo.PacienteId == 2 && vinculo.PsicologoResponsavelId == PsicologoId))
        {
            vinculos.Add(CriarVinculo());
            context.SaveChanges();
        }
    }

    public static async Task SeedAsync(DbContext context, CancellationToken cancellationToken)
    {
        var vinculos = context.Set<VinculoPacientePsicologoModel>();

        if (!await vinculos.AnyAsync(vinculo =>
                vinculo.PacienteId == 2 && vinculo.PsicologoResponsavelId == PsicologoId,
                cancellationToken))
        {
            vinculos.Add(CriarVinculo());
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    private static VinculoPacientePsicologoModel CriarVinculo() => new()
    {
        PacienteId = 2,
        PsicologoResponsavelId = PsicologoId,
        StatusVinculo = StatusVinculoEnum.Ativo,
        DataCriacao = new DateTime(2026, 1, 15, 12, 0, 0, DateTimeKind.Utc),
        Ativo = true
    };
}
