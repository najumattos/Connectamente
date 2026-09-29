using Connectamente.API.Enums;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public static class ApplicationUserSeed
{
    public static void Seed(EntityTypeBuilder<ApplicationUserModel> builder)
    {
        // 1. Instância da Professora Administradora (Senha: Admin@Connect9)
        var admin = new ApplicationUserModel
        {
           Id = IdentityConstants.Admin.Id, 
            NomeCompleto = "Profª. Dra. Mariana Silva",
            Cpf = "12345678901",
            Matricula = "PR99955",
            Crp = "06/12345-6",
            TipoUsuario = TipoUsuarioEnum.Professor,
            Ativo = true,
            DataCadastro = new DateTime(2026, 05, 29, 10, 0, 0, DateTimeKind.Utc), 
            UserName = "mariana.admin@connectamente.com",
            NormalizedUserName = "MARIANA.ADMIN@CONNECTAMENTE.COM",
            Email = IdentityConstants.Admin.Email,
            NormalizedEmail = IdentityConstants.Admin.NormalizedEmail,
            EmailConfirmed = true,
            SecurityStamp = "ef7a1510-9177-4c44-b0cf-5b12da6bf121",
            ConcurrencyStamp = "ef7a1510-9177-4c44-b0cf-5b12da6bf121",
            PasswordHash = IdentityConstants.Admin.HashSenha,
            PhoneNumber = "14999009858"
        };

        // 2. Instância do Aluno (Senha: Aluno@Connect9)
        var aluno = new ApplicationUserModel
        {
           Id = IdentityConstants.Aluno.Id, 
            NomeCompleto = "Gabriel Soares Santos",
            Cpf = "98765432100",
            Matricula = "AL202611",
            Crp = null,
            TipoUsuario = TipoUsuarioEnum.Aluno,
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

        builder.HasData(admin, aluno);
    }
}