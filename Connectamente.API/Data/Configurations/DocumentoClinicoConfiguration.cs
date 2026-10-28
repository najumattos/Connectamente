using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class DocumentoClinicoConfiguration : IEntityTypeConfiguration<DocumentoClinicoModel>
{
    public void Configure(EntityTypeBuilder<DocumentoClinicoModel> builder)
    {
        builder.ToTable("DocumentosClinicos");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();

         builder.Property(d => d.DataCriacao).IsRequired().HasColumnType("datetime");
        builder.Property(d => d.DataAtualizacao).HasColumnType("datetime");
        builder.Property(d => d.Ativo).IsRequired();
        builder.Property(d => d.Observacoes).HasMaxLength(500).HasColumnType("varchar(500)");

        builder.Property(d => d.UsuarioResponsavelId)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("varchar(150)");

        builder.Property(d => d.TipoDocumentoClinico)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(d => d.NomeArquivo)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");

        builder.Property(d => d.CaminhoArquivo)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnType("varchar(500)");      

        builder.HasOne(d => d.Prontuario)
            .WithMany(a => a.DocumentosClinicos)
            .HasForeignKey(d => d.ProntuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Atendimento)
            .WithMany()
            .HasForeignKey(d => d.AtendimentoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PlantaoModel>()
            .WithMany(p => p.DocumentosClinicos)
            .HasForeignKey("PlantaoId")
            .OnDelete(DeleteBehavior.Restrict);


        // Relacionamento com o Objeto de Usuário usando a FK física correta
        builder.HasOne(d => d.Usuario)
            .WithMany(u => u.DocumentosCriados)
            .HasForeignKey(d => d.UsuarioResponsavelId) 
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
