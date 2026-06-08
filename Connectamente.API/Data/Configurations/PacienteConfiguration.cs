using Connectamente.API.Data.Seeds;
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

        // Propriedades Herdadas de EntityBase e Primitivas Obrigatórias
        builder.Property(p => p.DataCriacao).IsRequired();
        builder.Property(p => p.DataAtualizacao);
        builder.Property(p => p.Ativo).IsRequired();
        
        // Definição de limites e obrigatoriedade (Evita longtext genérico no MySQL)
        builder.Property(p => p.NomeCompleto)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.CPF)
            .HasMaxLength(11); // Apenas números, ou 14 se incluir pontos/traços

        builder.Property(p => p.RG)
            .HasMaxLength(20);

        builder.Property(p => p.Telefone)
            .HasMaxLength(20);

        builder.Property(p => p.TelefoneRecado)
            .HasMaxLength(20);

        builder.Property(p => p.Sexo)
            .HasMaxLength(20);

        builder.Property(p => p.Naturalidade)
            .HasMaxLength(100);

        builder.Property(p => p.EstadoNascimento)
            .HasMaxLength(2); // Sigla do estado (ex: SP, RJ)

        builder.Property(p => p.Escolaridade)
            .HasMaxLength(50);

        builder.Property(p => p.Profissao)
            .HasMaxLength(100);

        builder.Property(p => p.EstadoCivil)
            .HasMaxLength(30);

        builder.Property(p => p.Religiao)
            .HasMaxLength(50);

        builder.Property(p => p.DataNascimento);
        
        builder.Property(p => p.FamiliarResponsavelId).IsRequired(false);

        // Ignora a propriedade calculada (Não vira coluna física no banco de dados)
        builder.Ignore(p => p.Idade);

        // Value Object: Mapeia as propriedades do Endereço na mesma tabela de Pacientes
        builder.OwnsOne(p => p.Endereco, endereco =>
        {
            endereco.Property(e => e.Logradouro).HasColumnName("EnderecoLogradouro").HasMaxLength(200);
            endereco.Property(e => e.Numero).HasColumnName("EnderecoNumero").HasMaxLength(20);
            endereco.Property(e => e.Bairro).HasColumnName("EnderecoBairro").HasMaxLength(100);
            endereco.Property(e => e.Cidade).HasColumnName("EnderecoCidade").HasMaxLength(100);
            endereco.Property(e => e.Estado).HasColumnName("EnderecoEstado").HasMaxLength(2);
            endereco.Property(e => e.CEP).HasColumnName("EnderecoCep").HasMaxLength(8);      
        });

        // RELACIONAMENTO 1:N - Um Paciente tem um Familiar Responsável administrativo
        builder.HasOne(p => p.FamiliarResponsavel)
            .WithMany()
            .HasForeignKey(p => p.FamiliarResponsavelId)
            .OnDelete(DeleteBehavior.Restrict); // Evita deletar o familiar por acidente

        // RELACIONAMENTO 1:1 - Um Paciente tem um único Prontuário Clínico
        builder.HasOne(p => p.Prontuario)
        .WithOne(p => p.Paciente)
        .HasForeignKey<ProntuarioModel>(pr => pr.PacienteId) 
        .OnDelete(DeleteBehavior.Cascade); // Se o Paciente for excluído fisicamente, o prontuário também deve ser
    
    PacienteSeed.Seed(builder);
    }
}