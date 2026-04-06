using Connectamente.API.Helpers;
using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectamente.API.Data.Configurations;

public class PacienteConfig : IEntityTypeConfiguration<PacienteModel>
{
    public void Configure(EntityTypeBuilder<PacienteModel> builder)
    {
        builder.HasKey(p => p.PacienteId);

        // 2. Configura o relacionamento 1:1 com o Usuario
        builder.HasOne(p => p.Usuario)
               .WithOne()
               .HasForeignKey<PacienteModel>(p => p.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);

        // 3. Configura o relacionamento com o Psicólogo Responsável
        builder.HasOne(p => p.PsicologoResponsavel)
               .WithMany() // Um psicólogo pode ter muitos pacientes
               .HasForeignKey(p => p.PsicologoResponsavelId)
               .OnDelete(DeleteBehavior.Restrict); // Evita deletar o psicólogo e levar os pacientes junto sem querer



        List<PacienteModel> pacientes = [
           new PacienteModel
            {
                PacienteId = SeedDataConstants.USER_CLINICA_ID, // Precisa de um ID próprio se for a Key
                UsuarioId = SeedDataConstants.USER_CLINICA_ID,
                PsicologoResponsavelId = SeedDataConstants.USER_ESTUDANTE_ID, 
                ContatoEmergencia = "14999009858",
                HistoricoPaciente = "Histórico inicial do paciente para testes de sistema."
            }
             ];
        builder.HasData(pacientes);
    }
}
