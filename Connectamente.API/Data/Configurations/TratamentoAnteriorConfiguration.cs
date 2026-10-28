using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class TratamentoAnteriorConfiguration : IEntityTypeConfiguration<TratamentoAnteriorModel>
{
    public void Configure(EntityTypeBuilder<TratamentoAnteriorModel> builder)
    {
      builder.ToTable("TratamentosAnteriores");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

       builder.Property(t => t.DataCriacao).IsRequired().HasColumnType("datetime");
        builder.Property(t => t.DataAtualizacao).HasColumnType("datetime");
        builder.Property(t => t.Ativo).IsRequired();
        builder.Property(t => t.Observacoes).HasMaxLength(500).HasColumnType("varchar(500)");

    builder.Property(t => t.TipoTratamento)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(t => t.Internacao)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(t => t.MotivoInternacao)
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");

        // Relacionamentos
        builder.HasOne(t => t.Prontuario)
            .WithMany(p => p.TratamentosAnteriores)
            .HasForeignKey(t => t.ProntuarioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
