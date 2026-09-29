using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public static class RoleSeed
{
    // IDs fixos para os roles — necessário para o seed ser idempotente
    
    public static void Seed(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = IdentityConstants.Admin.RoleId,
                Name = "Professor",
                NormalizedName = "PROFESSOR",
                ConcurrencyStamp = "a1b2c3d4-0001-0001-0001-000000000001"
            },
            new IdentityRole
            {
                Id = IdentityConstants.Aluno.RoleId,
                Name = "Aluno",
                NormalizedName = "ALUNO",
                ConcurrencyStamp = "a1b2c3d4-0002-0002-0002-000000000002"
            }
        );
    }
}