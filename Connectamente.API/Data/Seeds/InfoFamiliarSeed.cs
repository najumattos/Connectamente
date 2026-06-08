using Connectamente.API.Enums;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public static class InfoFamiliarSeed
{
    public static void Seed(EntityTypeBuilder<InfoFamiliarModel> builder)
    {
        // 1. SEED DOS ENDEREÇOS (Value Objects)
        // Mapeia usando a chave de sombra primária da própria tabela 'InfosFamiliares' (Id)
        builder.OwnsOne(x => x.Endereco).HasData(
            new { InfoFamiliarModelId = 1, Logradouro = "Rua das Flores", Numero = "123", Bairro = "Centro", Cidade = "São Paulo", Estado = "SP", CEP = "01001000" }, // Pai - P1
            new { InfoFamiliarModelId = 2, Logradouro = "Rua das Flores", Numero = "123", Bairro = "Centro", Cidade = "São Paulo", Estado = "SP", CEP = "01001000" }, // Mãe - P1
            new { InfoFamiliarModelId = 3, Logradouro = "Avenida da Saudade", Numero = "50", Bairro = "Velho", Cidade = "São Paulo", Estado = "SP", CEP = "01002000" }, // Avó - P1
            new { InfoFamiliarModelId = 4, Logradouro = "Rua das Flores", Numero = "123", Bairro = "Centro", Cidade = "São Paulo", Estado = "SP", CEP = "01001000" }, // Pai - P2
            new { InfoFamiliarModelId = 5, Logradouro = "Rua das Flores", Numero = "123", Bairro = "Centro", Cidade = "São Paulo", Estado = "SP", CEP = "01001000" }, // Mãe - P2
            new { InfoFamiliarModelId = 6, Logradouro = "Avenida da Saudade", Numero = "50", Bairro = "Velho", Cidade = "São Paulo", Estado = "SP", CEP = "01002000" }  // Avó - P2
        );

        // 2. SEED DOS FAMILIARES
        builder.HasData(
            // ================= PACIENTE 1 (Ana) =================
            new 
            {
                Id = 1,
                PacienteId = 1, // Chave de sombra definida na configuração
                NomeCompleto = "Roberto Silva Costa",
                Parentesco = ParentescoEnum.Pai,
                GrauInstrucao = "Superior",
                Profissao = "Administrador",
                DataNascimento = new DateTime(1970, 3, 12),
                CPF = "11122233344",
                Telefone = "11988881111",
                ResponsavelPrincipal = true // PAI É O RESPONSÁVEL DO PACIENTE 1
            },
            new 
            {
                Id = 2,
                PacienteId = 1,
                NomeCompleto = "Maria Aparecida Costa",
                Parentesco = ParentescoEnum.Mae,
                GrauInstrucao = "Superior",
                Profissao = "Professora",
                DataNascimento = new DateTime(1973, 8, 25),
                CPF = "22233344455",
                Telefone = "11988882222",
                ResponsavelPrincipal = false
            },
            new 
            {
                Id = 3,
                PacienteId = 1,
                NomeCompleto = "Antônia Silva",
                Parentesco = ParentescoEnum.AvoMaterna,
                GrauInstrucao = "Fundamental",
                Profissao = "Aposentada",
                DataNascimento = new DateTime(1948, 1, 30),
                CPF = "33344455566",
                Telefone = "11988883333",
                ResponsavelPrincipal = false
            },

            // ================= PACIENTE 2 (Carlos) =================
            new 
            {
                Id = 4,
                PacienteId = 2,
                NomeCompleto = "Roberto Silva Costa",
                Parentesco = ParentescoEnum.Pai,
                GrauInstrucao = "Administrador",
                Profissao = "Gerente",
                DataNascimento = new DateTime(1970, 3, 12),
                CPF = "11122233344",
                Telefone = "11988881111",
                ResponsavelPrincipal = false
            },
            new 
            {
                Id = 5,
                PacienteId = 2,
                NomeCompleto = "Maria Aparecida Costa",
                Parentesco = ParentescoEnum.Mae,
                GrauInstrucao = "Superior",
                Profissao = "Professora",
                DataNascimento = new DateTime(1973, 8, 25),
                CPF = "22233344455",
                Telefone = "11988882222",
                ResponsavelPrincipal = false
            },
            new 
            {
                Id = 6,
                PacienteId = 2,
                NomeCompleto = "Antônia Silva",
                Parentesco = ParentescoEnum.Conjuje,
                GrauInstrucao = "Fundamental",
                Profissao = "Aposentada",
                DataNascimento = new DateTime(1948, 1, 30),
                CPF = "33344455566",
                Telefone = "11988883333",
                ResponsavelPrincipal = true // CONJUJE É RESPONSÁVEL DO PACIENTE 2
            }
        );
    }
}