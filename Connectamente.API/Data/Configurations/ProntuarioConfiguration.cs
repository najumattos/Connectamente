using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class ProntuarioConfiguration : IEntityTypeConfiguration<ProntuarioModel>
{
    public void Configure(EntityTypeBuilder<ProntuarioModel> builder)
    {
        builder.ToTable("Prontuarios");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataCriacao).IsRequired();
        builder.Property(x => x.DataAtualizacao);
        builder.Property(x => x.Ativo).IsRequired();
        builder.Property(x => x.PacienteId).IsRequired();
        builder.Property(x => x.NumeroProntuario).IsRequired();
        builder.Property(x => x.DataPrimeiraConsulta).IsRequired();
        builder.Property(x => x.SituacaoProntuario).IsRequired();
        builder.Property(x => x.ObservacoesGerais);

        // RELACIONAMENTO 1:1 - Um Paciente tem um único Prontuário
        builder.HasOne(x => x.Paciente)
            .WithOne(x => x.Prontuario)
            .HasForeignKey<ProntuarioModel>(x => x.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // RELACIONAMENTO 1:N - Um Prontuário possui muitos Tratamentos Anteriores
        builder.HasMany(x => x.TratamentosAnteriores)
            .WithOne(x => x.Prontuario)
            .HasForeignKey(x => x.ProntuarioModelId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}