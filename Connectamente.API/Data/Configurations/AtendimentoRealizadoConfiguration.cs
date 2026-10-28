using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class AtendimentoRealizadoConfiguration : IEntityTypeConfiguration<AtendimentoModel>
{
    public void Configure(EntityTypeBuilder<AtendimentoModel> builder)
    {
        builder.ToTable("AtendimentosRealizados");
        builder.HasKey(a => a.AgendamentoId);

        builder.HasOne(a => a.Agendamento)
            .WithOne()
            .HasForeignKey<AtendimentoModel>(a => a.AgendamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Prontuario)
            .WithMany()
            .HasForeignKey(a => a.ProntuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
