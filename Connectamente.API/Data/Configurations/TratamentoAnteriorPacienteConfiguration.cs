using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class TratamentoAnteriorPacienteConfiguration : IEntityTypeConfiguration<TratamentoAnteriorModel>
{
    public void Configure(EntityTypeBuilder<TratamentoAnteriorModel> builder)
    {
        builder.ToTable("TratamentosAnterioresPaciente");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataCriacao).IsRequired();
        builder.Property(x => x.DataAtualizacao);
        builder.Property(x => x.Ativo).IsRequired();
        builder.Property(x => x.Internacao).IsRequired();
        builder.Property(x => x.TipoTratamento).IsRequired();
        builder.Property(x => x.MotivoInternacao);
        builder.Property(x => x.Observacoes);
        
        // Chaves Estrangeiras Físicas (Mapeamento de tipos)
        builder.Property(x => x.PacienteId).IsRequired();
        builder.Property(x => x.ProntuarioModelId); // Pode ser nulo se o prontuário for gerado depois

        // RELACIONAMENTO 1:N - Um Prontuário tem Muitos Tratamentos Anteriores
        builder.HasOne(x => x.Prontuario)
            .WithMany(x => x.TratamentosAnteriores)
            .HasForeignKey(x => x.ProntuarioModelId)
            .OnDelete(DeleteBehavior.Cascade); // Se o Prontuário sumir, apasta os tratamentos dele

        // RELACIONAMENTO 1:N - Um Paciente tem Muitos Tratamentos Anteriores
        builder.HasOne(x => x.Paciente)
            .WithMany()
            .HasForeignKey(x => x.PacienteId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}