using Connectamente.API.Data.Seeds;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : IdentityDbContext<ApplicationUserModel>(options)
{
   public DbSet<PacienteModel> Pacientes => Set<PacienteModel>();
    public DbSet<FamiliarModel> Familiares => Set<FamiliarModel>();
    public DbSet<ProntuarioModel> Prontuarios => Set<ProntuarioModel>();
    public DbSet<TratamentoAnteriorModel> TratamentosAnteriores => Set<TratamentoAnteriorModel>();
    public DbSet<AtendimentoModel> Atendimentos => Set<AtendimentoModel>();
    public DbSet<DocumentoClinicoModel> DocumentosClinicos => Set<DocumentoClinicoModel>();
    public DbSet<AuditoriaModel> Auditorias { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditEntries = OnBeforeSaveChanges();
        var result = await base.SaveChangesAsync(cancellationToken);
        await OnAfterSaveChanges(auditEntries);
        return result;
    }

    private List<AuditEntry> OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is AuditoriaModel || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var auditEntry = new AuditEntry(entry)
            {
                NomeTabela = entry.Metadata.GetTableName() ?? entry.Metadata.Name,                
                UsuarioEmail = currentUserService.UserEmail ?? "Sistema/Anônimo"
            };

            auditEntries.Add(auditEntry);

            switch (entry.State)
            {
                case EntityState.Added:
                    auditEntry.TipoAcao = TipoAcaoAuditoriaEnum.Insercao.ToString(); // Alinhe com seu Enum
                    foreach (var property in entry.Properties)
                    {
                        if (property.IsTemporary)
                        {
                            auditEntry.PropriedadesTemporarias.Add(property);
                            continue;
                        }
                        auditEntry.ValoresNovos[property.Metadata.Name] = property.CurrentValue!;
                    }
                    break;

                case EntityState.Deleted:
                    auditEntry.TipoAcao = TipoAcaoAuditoriaEnum.ExclusaoFisica.ToString();
                    foreach (var property in entry.Properties)
                    {
                        auditEntry.ValoresAntigos[property.Metadata.Name] = property.OriginalValue!;
                    }
                    auditEntry.RegistroId = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue?.ToString() ?? "0";
                    break;

                case EntityState.Modified:
                    auditEntry.TipoAcao = TipoAcaoAuditoriaEnum.Atualizacao.ToString();
                    foreach (var property in entry.Properties)
                    {
                        if (property.IsModified)
                        {
                            auditEntry.ValoresAntigos[property.Metadata.Name] = property.OriginalValue!;
                            auditEntry.ValoresNovos[property.Metadata.Name] = property.CurrentValue!;
                        }
                    }
                    auditEntry.RegistroId = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue?.ToString() ?? "0";
                    break;
            }
        }

        foreach (var auditEntry in auditEntries.Where(_ => !_.PropriedadesTemporarias.Any()))
        {
            Auditorias.Add(auditEntry.ToAudit());
        }

        return auditEntries.Where(_ => _.PropriedadesTemporarias.Any()).ToList();
    }

    private async Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
    {
        if (auditEntries == null || auditEntries.Count == 0) return;

        foreach (var auditEntry in auditEntries)
        {
            foreach (var prop in auditEntry.PropriedadesTemporarias)
            {
                if (prop.Metadata.IsPrimaryKey())
                {
                    auditEntry.RegistroId = prop.CurrentValue!.ToString()!;
                }
                auditEntry.ValoresNovos[prop.Metadata.Name] = prop.CurrentValue!;
            }
            Auditorias.Add(auditEntry.ToAudit());
        }
        await base.SaveChangesAsync();
    }
       protected override void OnModelCreating(ModelBuilder builder)
    {
       base.OnModelCreating(builder);       
       builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        builder.Entity<ApplicationUserModel>(ApplicationUserSeed.Seed);
    builder.Entity<IdentityRole>(RoleSeed.Seed);
    builder.Entity<IdentityUserRole<string>>(UserRoleSeed.Seed);
    }
}
