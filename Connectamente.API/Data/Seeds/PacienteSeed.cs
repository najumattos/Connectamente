using Connectamente.API.Enums;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Data.Seeds;

public static class PacienteSeed
{
    public static void Seed(DbContext context)
    {
        var pacientes = context.Set<PacienteModel>();

        if (!pacientes.Any(paciente => paciente.Id == 1))
        {
            pacientes.Add(CriarPacienteUm());
        }

        if (!pacientes.Any(paciente => paciente.Id == 2))
        {
            pacientes.Add(CriarPacienteDois());
        }

        context.SaveChanges();
    }

    public static async Task SeedAsync(DbContext context, CancellationToken cancellationToken)
    {
        var pacientes = context.Set<PacienteModel>();

        if (!await pacientes.AnyAsync(paciente => paciente.Id == 1, cancellationToken))
        {
            pacientes.Add(CriarPacienteUm());
        }

        if (!await pacientes.AnyAsync(paciente => paciente.Id == 2, cancellationToken))
        {
            pacientes.Add(CriarPacienteDois());
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    private static PacienteModel CriarPacienteUm() => new()
    {
        Id = 1,
        DataCriacao = new DateTime(2026, 1, 15, 12, 0, 0, DateTimeKind.Utc),
        Ativo = true,
        SituacaoPaciente = SituacaoPacienteEnum.Ativo,
        Identificacao = new Identificacao(
            "Gilson Barreto Filho", new DateTime(1990, 4, 12), "12345678901", "123456789",
            "11987654321", null, EscolaridadeEnum.EnsinoSuperior, GeneroEnum.HomemCis,
            "Profissional liberal", "gilsonbarreto@connecta.com", EstadoCivilEnum.Solteiro,
            "São Paulo", "SP", null),
        Endereco = new Endereco("Rua das Flores", "100", "Centro", "São Paulo", "SP", "01001000")
    };

    private static PacienteModel CriarPacienteDois() => new()
    {
        Id = 2,
        DataCriacao = new DateTime(2026, 1, 15, 12, 0, 0, DateTimeKind.Utc),
        Ativo = true,
        SituacaoPaciente = SituacaoPacienteEnum.Ativo,
        Identificacao = new Identificacao(
            "André Coelho Matos", new DateTime(1985, 8, 23), "98765432100", null,
            "11912345678", null, EscolaridadeEnum.EnsinoMedio, GeneroEnum.HomemCis,
            "Comerciante", "andrematos@connecta.com", EstadoCivilEnum.Casado,
            "Campinas", "SP", null),
        Endereco = new Endereco("Avenida Brasil", "250", "Jardim", "Campinas", "SP", "13010000")
    };
}
