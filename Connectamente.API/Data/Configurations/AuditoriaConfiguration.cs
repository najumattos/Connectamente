using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class AuditoriaConfiguration : IEntityTypeConfiguration<AuditoriaModel>
{
    public void Configure(EntityTypeBuilder<AuditoriaModel> builder)
    {
        builder.ToTable("Auditorias");

        // Chave Primária bigint
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(a => a.UsuarioEmail)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("varchar(150)");

        builder.Property(a => a.TipoAcao)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired()
            .HasColumnType("varchar(30)");

        builder.Property(a => a.NomeTabela)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder.Property(a => a.RegistroId)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");

        builder.Property(a => a.DataHora)
            .IsRequired()
            .HasColumnType("datetime");
    }
}
