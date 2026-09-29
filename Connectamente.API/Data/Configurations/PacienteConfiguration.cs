using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

       builder.Property(p => p.DataCriacao)
        .ValueGeneratedOnAdd() 
        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(p => p.DataAtualizacao).ValueGeneratedOnAddOrUpdate();

        builder.Property(p => p.Ativo)
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(p => p.Observacoes)
               .HasMaxLength(500);

        // Mapeamento do Complex Type: Identificacao
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
            
            // Otimização: Armazenamento performático como Inteiro no MySQL
            ident.Property(i => i.Escolaridade).IsRequired();
            ident.Property(i => i.Genero).IsRequired();
            ident.Property(i => i.EstadoCivil).IsRequired();
        });

        // Chamada isolada para marcar a propriedade complexa Identificacao como obrigatória na raiz
        builder.ComplexProperty(p => p.Identificacao).IsRequired();

        // Mapeamento do Complex Type: Endereco
        builder.ComplexProperty(p => p.Endereco, end =>
        {
            end.Property(e => e.Logradouro).IsRequired().HasMaxLength(150);
            end.Property(e => e.Numero).IsRequired().HasMaxLength(10);
            end.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            end.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
            end.Property(e => e.Estado).IsRequired().HasMaxLength(2);
            end.Property(e => e.CEP).IsRequired().HasMaxLength(8);
        });

        // Chamada isolada para marcar a propriedade complexa Endereco como obrigatória na raiz
        builder.ComplexProperty(p => p.Endereco).IsRequired();
    }
}