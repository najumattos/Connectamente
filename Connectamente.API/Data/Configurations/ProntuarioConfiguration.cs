using Connectamente.API.Data.Seeds;
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

        // RELACIONAMENTO 1:N - Um Prontuário possui muitos Tratamentos Anteriores
        builder.HasMany(x => x.TratamentosAnteriores)
            .WithOne(x => x.Prontuario)
            .HasForeignKey(x => x.ProntuarioId)
            .OnDelete(DeleteBehavior.Restrict); 
    
         // Configuração do relacionamento 1:N (Um Psicólogo tem Vários Prontuários)
        builder.HasOne(p => p.PsicologoResponsavel)
            .WithMany(u => u.ProntuariosResponsavel) // Casamento com a propriedade do ApplicationUser
            .HasForeignKey(p => p.PsicologoResponsavelId) // Sua FK explícita string
            .OnDelete(DeleteBehavior.Restrict); // Segurança: Proíbe deletar o psicólogo se ele possuir históricos clínicos ativos
    ProntuarioSeed.Seed(builder);
    }

}