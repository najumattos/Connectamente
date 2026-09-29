using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class FamiliarConfiguration : IEntityTypeConfiguration<FamiliarModel>
{
    public void Configure(EntityTypeBuilder<FamiliarModel> builder)
    {
        builder.ToTable("Familiares");

        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id)
               .ValueGeneratedOnAdd();

        builder.Property(f => f.DataCriacao).ValueGeneratedOnAddOrUpdate()
               .IsRequired();

        builder.Property(f => f.DataAtualizacao).ValueGeneratedOnAddOrUpdate();

        builder.Property(f => f.Ativo)
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(f => f.Observacoes)
               .HasMaxLength(500);        

                builder.Property(x => x.ResponsavelPrincipal).IsRequired();
        builder.Property(x => x.TermoAutorizacaoMenor).IsRequired();

        builder.Property(x => x.Parentesco).HasConversion<int>().IsRequired();


        // FORMA CORRETA 1: Configura o comportamento exigido diretamente no escopo do ComplexProperty
        builder.ComplexProperty(f => f.Identificacao, ident =>
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
            
            ident.Property(i => i.Escolaridade).IsRequired();
            ident.Property(i => i.Genero).IsRequired();
            ident.Property(i => i.EstadoCivil).IsRequired();
            
        });
        
        // Aplica a obrigatoriedade do objeto na raiz usando a referência direta do modelo
        builder.ComplexProperty(f => f.Identificacao).IsRequired();

        // FORMA CORRETA 2: Configura o Endereco
        builder.ComplexProperty(f => f.Endereco, end =>
        {
            end.Property(e => e.Logradouro).IsRequired().HasMaxLength(150);
            end.Property(e => e.Numero).IsRequired().HasMaxLength(10);
            end.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            end.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
            end.Property(e => e.Estado).IsRequired().HasMaxLength(2);
            end.Property(e => e.CEP).IsRequired().HasMaxLength(8);
        });
  builder.HasOne(t => t.Prontuario)
            .WithMany(p => p.Familiares)
            .HasForeignKey(t => t.ProntuarioId)
            .OnDelete(DeleteBehavior.Cascade);
        // Aplica a obrigatoriedade do objeto na raiz
        builder.ComplexProperty(f => f.Endereco).IsRequired();
    }
}