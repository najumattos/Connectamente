using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class VinculoPacientePsicologoConfiguration : IEntityTypeConfiguration<VinculoPacientePsicologoModel>
{
    public void Configure(EntityTypeBuilder<VinculoPacientePsicologoModel> builder)
    {
        builder.ToTable("VinculosPacientePsicologo");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).ValueGeneratedOnAdd();
        builder.Property(v => v.DataCriacao).IsRequired().HasColumnType("datetime");
        builder.Property(v => v.DataAtualizacao).HasColumnType("datetime");
        builder.Property(v => v.Ativo).IsRequired();
        builder.Property(v => v.Observacoes).HasMaxLength(500).HasColumnType("varchar(500)");
        builder.Property(v => v.PsicologoResponsavelId).IsRequired().HasMaxLength(450);
        builder.Property(v => v.StatusVinculo).HasConversion<string>().HasMaxLength(30).IsRequired();
        builder.Property(v => v.DataEncerramento).HasColumnType("datetime");

        builder.HasOne(v => v.Paciente)
            .WithMany(p => p.VinculosPacientePsicologo)
            .HasForeignKey(v => v.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(v => v.PsicologoResponsavel)
            .WithMany(u => u.VinculosPacientePsicologo)
            .HasForeignKey(v => v.PsicologoResponsavelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
