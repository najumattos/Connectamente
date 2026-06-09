using Connectamente.API.Enums;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public class ApplicationUserSeed : IEntityTypeConfiguration<ApplicationUserModel>
{
private const string ADMIN_ID = "a18fbcde-1111-42b1-b4fa-4b8c0c45daaa";
    private const string ADMIN_STAMP = "ef7a1510-9177-4c44-b0cf-5b12da6bf121";

    private const string ALUNO_ID = "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb";
    private const string ALUNO_STAMP = "bc3101aa-2831-4e44-88aa-cc1234567890";

    public void Configure(EntityTypeBuilder<ApplicationUserModel> builder)
    {
       
        // 1. Instância da Professora Administradora (Senha: Admin@Connect9)
        var admin = new ApplicationUserModel
        {
            Id = ADMIN_ID,
            NomeCompleto = "Profª. Dra. Mariana Silva",
            Cpf = "12345678901",
            Matricula = "PR99955",
            Crp = "06/12345-6",
            TipoUsuario = TipoUsuarioEnum.ProfessoraAdministradora,
            Ativo = true,
            UserName = "mariana.admin@connectamente.com",
            NormalizedUserName = "MARIANA.ADMIN@CONNECTAMENTE.COM",
            Email = "mariana.admin@connectamente.com",
            NormalizedEmail = "MARIANA.ADMIN@CONNECTAMENTE.COM",
            EmailConfirmed = true,
            SecurityStamp = ADMIN_STAMP,
            ConcurrencyStamp = ADMIN_STAMP,
            PasswordHash = "AQAAAAIAAYagAAAAEJ1Z8b7vN3qXyR8vLmR6w7qN1mXyPzR9WvB5tQwMTlzNzhBcDFFM0FkR2g3Yg=="
        };

        // 2. Instância do Aluno (Senha: Aluno@Connect9)
        var aluno = new ApplicationUserModel
        {
          Id = ALUNO_ID,
            NomeCompleto = "Gabriel Soares Santos",
            Cpf = "98765432100",
            Matricula = "AL202611",
            Crp = null,
            TipoUsuario = TipoUsuarioEnum.Aluno,
            Ativo = true,
            UserName = "gabriel.aluno@connectamente.com",
            NormalizedUserName = "GABRIEL.ALUNO@CONNECTAMENTE.COM",
            Email = "gabriel.aluno@connectamente.com",
            NormalizedEmail = "GABRIEL.ALUNO@CONNECTAMENTE.COM",
            EmailConfirmed = true,
            SecurityStamp = ALUNO_STAMP, 
            ConcurrencyStamp = ALUNO_STAMP,
            PasswordHash = "AQAAAAIAAYagAAAAEM6W2m1Hk8zN3qXyR8vLmR6w7qN1mXyPzR9WvB5tQwMTlzNzhBcDFFM0FkR2g3Yg=="
            };

        // 3. Injeta os dados no builder do Entity Framework
        builder.HasData(admin, aluno);
    }
}