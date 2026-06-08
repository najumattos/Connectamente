using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public static class PacienteSeed
{
    public static void Seed(EntityTypeBuilder<PacienteModel> builder)
    {
        // 1. SEED DO ENDEREÇO (Value Object aninhado)
        builder.OwnsOne(p => p.Endereco).HasData(
            new { PacienteModelId = 1, Logradouro = "Rua das Flores", Numero = "123", Bairro = "Centro", Cidade = "São Paulo", Estado = "SP", CEP = "01001000" },
            new { PacienteModelId = 2, Logradouro = "Avenida Central", Numero = "99A", Bairro = "Jardins", Cidade = "Campinas", Estado = "SP", CEP = "13010000" }
        );

        // 2. SEED DOS PACIENTES
        builder.HasData(
            new PacienteModel
            {
                Id = 1,
                NomeCompleto = "Ana Silva Costa",
                CPF = "12345678901",
                RG = "MG1234567",
                Telefone = "11999998888",
                Sexo = "Feminino",
                Naturalidade = "Belo Horizonte",
                EstadoNascimento = "MG",
                Escolaridade = "Superior Completo",
                Profissao = "Engenheira",
                EstadoCivil = "Solteira",
                DataNascimento = new DateTime(1995, 5, 15),
                FamiliarResponsavelId = null,
                DataCriacao = new DateTime(2026, 1, 1),
                Ativo = true
            },
            new PacienteModel
            {
                Id = 2,
                NomeCompleto = "Carlos Eduardo Santos",
                CPF = "98765432100",
                RG = "SP7654321",
                Telefone = "19988887777",
                Sexo = "Masculino",
                Naturalidade = "Campinas",
                EstadoNascimento = "SP",
                Escolaridade = "Médio Completo",
                Profissao = "Comerciante",
                EstadoCivil = "Casado",
                DataNascimento = new DateTime(1988, 10, 22),
                FamiliarResponsavelId = null,
                DataCriacao = new DateTime(2026, 1, 2),
                Ativo = true
            }
        );       
    }
}