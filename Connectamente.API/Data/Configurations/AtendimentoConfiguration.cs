using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class AtendimentoConfiguration : IEntityTypeConfiguration<AtendimentoModel>
{
    public void Configure(EntityTypeBuilder<AtendimentoModel> builder)
    {
        builder.ToTable("Atendimentos");

        // Chave Primária (EntityBase)
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        // Propriedades de EntityBase
       builder.Property(p => p.DataCriacao)
        .ValueGeneratedOnAdd() 
        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(p => p.DataAtualizacao).ValueGeneratedOnAddOrUpdate();

        builder.Property(a => a.Ativo)
            .IsRequired()
            .HasDefaultValue(true);

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

        // Relacionamentos
        builder.HasOne(a => a.Prontuario)
            .WithMany(p => p.Atendimentos)
            .HasForeignKey(a => a.ProntuarioId)
            .OnDelete(DeleteBehavior.Restrict);      
    }
}