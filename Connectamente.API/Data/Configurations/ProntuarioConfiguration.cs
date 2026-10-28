using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class ProntuarioConfiguration : IEntityTypeConfiguration<ProntuarioModel>
{
    public void Configure(EntityTypeBuilder<ProntuarioModel> builder)
    {
      builder.ToTable("Prontuarios");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

       builder.Property(p => p.DataCriacao).IsRequired().HasColumnType("datetime");

        builder.Property(p => p.DataAtualizacao).ValueGeneratedOnAddOrUpdate();
        builder.Property(p => p.Ativo).IsRequired();
        builder.Property(p => p.Observacoes).HasMaxLength(500).HasColumnType("varchar(500)");

         builder.Property(p => p.NumeroProntuario)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        builder.Property(p => p.DataInicio).IsRequired().HasColumnType("datetime");
        builder.Property(p => p.DataFim).HasColumnType("datetime");

       builder.HasOne(p => p.Paciente)
            .WithOne(pac => pac.Prontuario)
            .HasForeignKey<ProntuarioModel>(p => p.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.NumeroProntuario)
            .IsUnique()
            .HasDatabaseName("IX_Prontuarios_NumeroProntuario");

        builder.HasOne(p => p.Plantao)
            .WithMany()
            .HasForeignKey(p => p.PlantaoId)
            .OnDelete(DeleteBehavior.Restrict);


    }

}
