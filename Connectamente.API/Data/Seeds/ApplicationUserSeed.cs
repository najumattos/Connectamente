using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public static class ApplicationUserSeed
{
    public static void Seed(EntityTypeBuilder<ApplicationUserModel> builder)
    {
        // 1. Instância da Professora (Senha: Admin@Connect9)
        var admin = new ApplicationUserModel
        {
           Id = IdentityConstants.Professor.Id, 
            NomeCompleto = "Profª. Dra. Mariana Silva",
            Matricula = "PR99955",
            Crp = "06/12345-6",
            Ativo = true,
            DataCadastro = new DateTime(2026, 05, 29, 10, 0, 0, DateTimeKind.Utc), 
            UserName = "mariana.admin@connectamente.com",
            NormalizedUserName = "MARIANA.ADMIN@CONNECTAMENTE.COM",
            Email = IdentityConstants.Professor.Email,
            NormalizedEmail = IdentityConstants.Professor.NormalizedEmail,
            EmailConfirmed = true,
            SecurityStamp = "ef7a1510-9177-4c44-b0cf-5b12da6bf121",
            ConcurrencyStamp = "ef7a1510-9177-4c44-b0cf-5b12da6bf121",
            PasswordHash = IdentityConstants.Professor.HashSenha,
            PhoneNumber = "14999009858"
        };

        // 2. Instância do Aluno (Senha: Aluno@Connect9)
        var aluno = new ApplicationUserModel
        {
           Id = IdentityConstants.Aluno.Id, 
            NomeCompleto = "Gabriel Soares Santos",
            Matricula = "AL202611",
            Crp = null,
            Ativo = true,
            DataCadastro = new DateTime(2026, 05, 29, 11, 0, 0, DateTimeKind.Utc), 
            UserName = "gabriel.aluno@connectamente.com",
            NormalizedUserName = "GABRIEL.ALUNO@CONNECTAMENTE.COM",
            Email = IdentityConstants.Aluno.Email,
            NormalizedEmail = IdentityConstants.Aluno.NormalizedEmail,
            EmailConfirmed = true,
            SecurityStamp = "bc3101aa-2831-4e44-88aa-cc1234567890",
            ConcurrencyStamp = "bc3101aa-2831-4e44-88aa-cc1234567890",   
            PasswordHash = IdentityConstants.Aluno.HashSenha   ,
            PhoneNumber = "14999193077"     
        };

          // 2. Instância da Secretaria (Senha: Secretaria@Connect9)
        var secretaria = new ApplicationUserModel
        {
           Id = IdentityConstants.Secretaria.Id, 
            NomeCompleto = "Ana Julia Mattos",
            Matricula = "AL202666",
            Crp = null,
            Ativo = true,
            DataCadastro = new DateTime(2026, 05, 29, 11, 0, 0, DateTimeKind.Utc), 
            UserName = "ana.secretaria@connectamente.com",
            NormalizedUserName = "ANA.SECRETARIA@CONNECTAMENTE.COM",
            Email = IdentityConstants.Secretaria.Email,
            NormalizedEmail = IdentityConstants.Secretaria.NormalizedEmail,
            EmailConfirmed = true,
            SecurityStamp = "d8a71c32-4f65-4e91-a2b3-7c6d9e0f1234",
            ConcurrencyStamp = "a5c92e41-7b83-4d60-9f12-6e4a8b3c5670",
            PasswordHash = IdentityConstants.Secretaria.HashSenha   ,
            PhoneNumber = "14999193088"     
        };

        builder.HasData(admin, aluno, secretaria);
    }
}