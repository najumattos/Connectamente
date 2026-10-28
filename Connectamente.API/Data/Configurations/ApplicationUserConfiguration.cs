using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUserModel>
{
    public void Configure(EntityTypeBuilder<ApplicationUserModel> builder)
    {
        builder.Property(u => u.NomeCompleto)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("varchar(150)");

        builder.Property(u => u.Matricula)
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

        builder.Property(u => u.Crp)
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");
        
        builder.Property(u => u.Ativo)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(u => u.AssinouTermoResponsabilidadeEstagiario)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(u => u.DataCadastro)
            .IsRequired()
            .HasColumnType("datetime");

        // Relacionamentos 
        // 1:N com DocumentoClinicoModel
        builder.HasMany(u => u.DocumentosCriados)
            .WithOne(d => d.Usuario)
            .HasForeignKey(d => d.UsuarioResponsavelId)
            .OnDelete(DeleteBehavior.Restrict);

        // 1:N com AuditoriaModel
        builder.HasMany(u => u.Auditorias)
            .WithOne() 
            .HasForeignKey("UsuarioId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.VinculosPacientePsicologo)
            .WithOne(v => v.PsicologoResponsavel)
            .HasForeignKey(v => v.PsicologoResponsavelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
