using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class TermoResponsabilidadeEstagiarioConfiguration : IEntityTypeConfiguration<TermoResponsabilidadeEstagiario>
{
    public void Configure(EntityTypeBuilder<TermoResponsabilidadeEstagiario> builder)
    {
        builder.ToTable("TermosResponsabilidadeEstagiarios");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.EstagiarioUsuarioId).IsRequired();
        builder.Property(t => t.DeclarouRecebimentoManual).IsRequired();
        builder.Property(t => t.DeclarouCienciaNormas).IsRequired();
        builder.HasIndex(t => t.EstagiarioUsuarioId)
            .IsUnique(); 

        // Configuração do relacionamento bidirecional 1:1
        builder.HasOne(t => t.EstagiarioUsuario)
            .WithOne(u => u.TermoResponsabilidade) 
            .HasForeignKey<TermoResponsabilidadeEstagiario>(t => t.EstagiarioUsuarioId) // Indica qual tabela carrega a FK
            .OnDelete(DeleteBehavior.Restrict); // Impede que o usuário suma se deletarem o termo de forma avulsa
    }
}