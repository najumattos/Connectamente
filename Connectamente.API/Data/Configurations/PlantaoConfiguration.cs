using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class PlantaoConfiguration : IEntityTypeConfiguration<PlantaoModel>
{
    public void Configure(EntityTypeBuilder<PlantaoModel> builder)
    {
        builder.ToTable("Plantoes");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.DataCriacao).IsRequired().HasColumnType("datetime");
        builder.Property(p => p.DataAtualizacao).HasColumnType("datetime");
        builder.Property(p => p.Ativo).IsRequired();
        builder.Property(p => p.Observacoes).HasMaxLength(500).HasColumnType("varchar(500)");
        builder.Property(p => p.StatusPlantao).HasConversion<string>().HasMaxLength(30).IsRequired();

        builder.HasOne(p => p.Paciente)
            .WithMany()
            .HasForeignKey(p => p.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.VinculoPacientePsicologo)
            .WithMany()
            .HasForeignKey(p => p.VinculoPacientePsicologoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
