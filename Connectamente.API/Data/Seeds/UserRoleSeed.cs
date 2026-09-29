using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Seeds;

public static class UserRoleSeed
{
    public static void Seed(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = IdentityConstants.Admin.Id,
                RoleId = IdentityConstants.Admin.RoleId
            },
            new IdentityUserRole<string>
            {
                UserId = IdentityConstants.Aluno.Id,
                RoleId = IdentityConstants.Aluno.RoleId
            }
        );
    }
}