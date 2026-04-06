using Connectamente.API.Enums;
using Connectamente.API.Helpers;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;
public class PsicologoConfig : IEntityTypeConfiguration<PsicologoModel>
{
    public void Configure(EntityTypeBuilder<PsicologoModel> builder)
    {
        builder.HasKey(p => p.PsicologoId);

        builder.HasOne(p => p.Usuario)
               .WithOne()
               .HasForeignKey<PsicologoModel>(p => p.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new PsicologoModel
            {
                // Use IDs fixos no Seed!
                PsicologoId = SeedDataConstants.USER_COORDENADOR_ID,
                UsuarioId = SeedDataConstants.USER_COORDENADOR_ID,
                CRP = "1235545",
                Descricao = "LET TIME JUST FLYYYYY",
                TipoPerfil = TipoPerfilEnum.Coordenador
            },
            new PsicologoModel
            {
                PsicologoId = SeedDataConstants.USER_CLINICA_ID,
                UsuarioId = SeedDataConstants.USER_CLINICA_ID,
                CRP = "1234555",
                Descricao = "FOUND MY HOPE AND PRIIIDEEE AGAIIN",
                TipoPerfil = TipoPerfilEnum.ClinicaParticular
            },
            new PsicologoModel
            {
                PsicologoId = SeedDataConstants.USER_ESTUDANTE_ID,
                UsuarioId = SeedDataConstants.USER_ESTUDANTE_ID,
                CRP = "12345",
                Descricao = "REBIRTH OF A MAN",
                TipoPerfil = TipoPerfilEnum.Aluno
            }
        );
    }
}