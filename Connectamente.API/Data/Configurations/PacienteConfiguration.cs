using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class PacienteConfiguration : IEntityTypeConfiguration<PacienteModel>
{
    public void Configure(EntityTypeBuilder<PacienteModel> builder)
    {        
        builder.ToTable("Pacientes");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

       builder.Property(p => p.DataCriacao).IsRequired().HasColumnType("datetime");

        builder.Property(p => p.DataAtualizacao).ValueGeneratedOnAddOrUpdate();
        builder.Property(p => p.Ativo).IsRequired();

        builder.Property(p => p.Observacoes)
               .HasMaxLength(500);

        builder.ComplexProperty(p => p.Identificacao, ident =>
        {
            ident.Property(i => i.NomeCompleto).IsRequired().HasMaxLength(150);
            ident.Property(i => i.DataNascimento).IsRequired();
            ident.Property(i => i.CPF).HasMaxLength(11);
            ident.Property(i => i.RG).HasMaxLength(20);
            ident.Property(i => i.TelefonePrincipal).IsRequired().HasMaxLength(20);
            ident.Property(i => i.TelefoneRecado).HasMaxLength(20);
            ident.Property(i => i.Profissao).HasMaxLength(100);
            ident.Property(i => i.Email).HasMaxLength(150);
            ident.Property(i => i.Naturalidade).HasMaxLength(100);
            ident.Property(i => i.EstadoNascimento).HasMaxLength(2);
            ident.Property(i => i.Religiao).HasMaxLength(50);
            
           ident.Property(i => i.Escolaridade);
            ident.Property(i => i.Genero);
            ident.Property(i => i.EstadoCivil);
        });
        builder.ComplexProperty(p => p.Identificacao).IsRequired();
    builder.ComplexProperty(p => p.Endereco, end =>
        {
            end.Property(e => e.Logradouro).IsRequired().HasMaxLength(150);
            end.Property(e => e.Numero).IsRequired().HasMaxLength(10);
            end.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            end.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
            end.Property(e => e.Estado).IsRequired().HasMaxLength(2);
            end.Property(e => e.CEP).IsRequired().HasMaxLength(8);
        });
        builder.ComplexProperty(p => p.Endereco).IsRequired();

          builder.HasOne(p => p.Prontuario)
            .WithOne(p => p.Paciente)
            .HasForeignKey<ProntuarioModel>(p => p.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
