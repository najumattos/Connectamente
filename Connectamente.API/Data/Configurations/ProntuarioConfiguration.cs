using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class ProntuarioConfiguration : IEntityTypeConfiguration<ProntuarioModel>
{
    public void Configure(EntityTypeBuilder<ProntuarioModel> builder)
    {
      builder.ToTable("Prontuarios");

        // Chave Primária (EntityBase)
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        // Propriedades de EntityBase
            builder.Property(p => p.DataCriacao)
        .ValueGeneratedOnAdd() 
        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(p => p.DataAtualizacao).ValueGeneratedOnAddOrUpdate();
        builder.Property(p => p.Ativo).IsRequired().HasDefaultValue(true);
        builder.Property(p => p.Observacoes).HasMaxLength(500).HasColumnType("varchar(500)");

        // Propriedades Nativas
        builder.Property(p => p.NumeroProntuario)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        builder.Property(p => p.DataPrimeiraConsulta)
            .HasColumnType("date");

        builder.Property(p => p.SituacaoProntuario)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired()
            .HasDefaultValue(Enums.SituacaoEnum.Ativo)
            .HasColumnType("varchar(30)");

        // Configuração do relacionamento 1:1 com PacienteModel
        builder.HasOne(p => p.Paciente)
            .WithOne(pac => pac.Prontuario)
            .HasForeignKey<ProntuarioModel>(p => p.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índices
        builder.HasIndex(p => p.NumeroProntuario)
            .IsUnique()
            .HasDatabaseName("IX_Prontuarios_NumeroProntuario");

            // RELACIONAMENTO 1:N - Um Psicólogo tem Vários Prontuários
        builder.HasOne(p => p.PsicologoResponsavel)
            .WithMany(u => u.ProntuariosResponsavel) 
            .HasForeignKey(p => p.PsicologoResponsavelId) 
            .OnDelete(DeleteBehavior.Restrict) 
            .IsRequired(false);
            
    }

}