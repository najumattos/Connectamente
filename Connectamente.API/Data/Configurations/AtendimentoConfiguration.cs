using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class AtendimentoConfiguration : IEntityTypeConfiguration<AgendamentoModel>
{
    public void Configure(EntityTypeBuilder<AgendamentoModel> builder)
    {
        builder.ToTable("Atendimentos");
   builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

       builder.Property(a => a.DataCriacao).IsRequired().HasColumnType("datetime");
        builder.Property(a => a.DataAtualizacao).HasColumnType("datetime");
        builder.Property(a => a.Ativo).IsRequired();

        builder.Property(a => a.Observacoes)
            .HasMaxLength(500)
            .IsUnicode(false);

        // Propriedades Nativas
        builder.Property(a => a.TipoAtendimento)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(a => a.DataHoraInicio)
            .HasColumnType("datetime");

        builder.Property(a => a.DataHoraFim)
            .HasColumnType("datetime");

        builder.Property(a => a.StatusAtendimento)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsUnicode(false)
            .IsRequired()
            .HasDefaultValue(Enums.StatusAtendimentoEnum.Agendado);

        builder.HasOne(a => a.VinculoPacientePsicologo)
            .WithMany(v => v.Agendamentos)
            .HasForeignKey(a => a.VinculoPacientePsicologoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
