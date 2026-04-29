# CLÍNICA-ESCOLA DE PSICOLOGIA - ARQUITETURA DDD

Reestruturação do projeto para **Domain-Driven Design** ao invés de MVC tradicional.

*Base orientada para ASP.NET Core, EF Core, Identity e Arquitetura em Camadas*

|  |  |
| --- | --- |
| Objeto | Digitalização integral dos documentos da clínica-escola com arquitetura dirigida pelo domínio |
| Contexto | Atendimentos realizados por alunos com acompanhamento da professora responsável |
| Premissa central | Lógica de negócio isolada no Domain; Application Layers convergem para Use Cases; Infrastructure persiste sem conheçer regras |
| Entregas consolidadas | Modelagem conceitual DDD, estrutura de agregados, domain services, application services e organização por bounded contexts |
|  |  |

# 1. Diferenças: MVC tradicional vs DDD

| Aspecto | MVC Tradicional | DDD |
|---|---|---|
| **Foco** | Controllers, Views, Models genéricos | Domain, Use Cases, Agregados |
| **Lógica de Negócio** | Espalhada em Controllers e Services | Concentrada no Domain |
| **Organização** | Por camada técnica | Por Bounded Context (domínio) |
| **Persistência** | Direta via EF Models | Mediada por Repository Pattern |
| **Validação** | Em ViewModel ou Controller | Em Value Objects e Domain Services |
| **Comunicação** | Direto entre camadas | Mediada por Application Services e DTOs |
| **Testabilidade** | Médio-alto | Alto (Domain isolado) |
| **Escalabilidade** | Até média complexidade | Grandes domínios e mudanças frequentes |

# 2. Estrutura de Pastas - DDD

```
ClinicaEscolaDDD/
│
├── src/
│   ├── Core/                                    # Núcleo do negócio
│   │   ├── Domain/                              # Bounded Context 1-3
│   │   │   ├── Pacientes/                       # BC: Gestão de Pacientes
│   │   │   │   ├── Entities/
│   │   │   │   │   ├── Paciente.cs
│   │   │   │   │   ├── ResponsavelLegal.cs
│   │   │   │   │   └── TratamentoAnterior.cs
│   │   │   │   ├── ValueObjects/
│   │   │   │   │   ├── CPF.cs
│   │   │   │   │   ├── Telefone.cs
│   │   │   │   │   └── Endereco.cs
│   │   │   │   ├── Specifications/
│   │   │   │   │   └── PacienteAtivoPorVinculoSpec.cs
│   │   │   │   ├── DomainServices/
│   │   │   │   │   ├── PacienteValidationService.cs
│   │   │   │   │   └── ResponsavelLegalService.cs
│   │   │   │   ├── DomainEvents/
│   │   │   │   │   ├── PacienteCriadoEvent.cs
│   │   │   │   │   └── VinculoLiberadoEvent.cs
│   │   │   │   ├── Repositories/
│   │   │   │   │   └── IPacienteRepository.cs
│   │   │   │   └── PacienteAggregate.cs
│   │   │   │
│   │   │   ├── Prontuarios/                     # BC: Gestão de Prontuários
│   │   │   │   ├── Entities/
│   │   │   │   │   ├── Prontuario.cs
│   │   │   │   │   ├── Atendimento.cs
│   │   │   │   │   └── DocumentoClinico.cs
│   │   │   │   ├── ValueObjects/
│   │   │   │   │   ├── NumeroProntuario.cs
│   │   │   │   │   ├── DescricaoAtendimento.cs
│   │   │   │   │   └── StatusDocumento.cs
│   │   │   │   ├── DocumentosEspecializados/
│   │   │   │   │   ├── AnamneseAdulto.cs
│   │   │   │   │   ├── AnamneseAdolescente.cs
│   │   │   │   │   ├── PlantaoPsicologico.cs
│   │   │   │   │   ├── EvolucaoAtendimento.cs
│   │   │   │   │   └── ...Termos.cs
│   │   │   │   ├── DomainServices/
│   │   │   │   │   ├── ProntuarioValidationService.cs
│   │   │   │   │   ├── DocumentoClinicoPersistenceService.cs
│   │   │   │   │   └── AtendimentoApprovalService.cs
│   │   │   │   ├── Factories/
│   │   │   │   │   ├── DocumentoClinicoFactory.cs
│   │   │   │   │   └── AtendimentoFactory.cs
│   │   │   │   ├── Repositories/
│   │   │   │   │   ├── IProntuarioRepository.cs
│   │   │   │   │   └── IDocumentoClinicoRepository.cs
│   │   │   │   └── ProntuarioAggregate.cs
│   │   │   │
│   │   │   ├── Vinculos/                        # BC: Controle de Acesso
│   │   │   │   ├── Entities/
│   │   │   │   │   └── VinculoAlunoPaciente.cs
│   │   │   │   ├── ValueObjects/
│   │   │   │   │   └── StatusVinculo.cs
│   │   │   │   ├── DomainServices/
│   │   │   │   │   ├── VinculoAccessService.cs
│   │   │   │   │   └── VinculoApprovalService.cs
│   │   │   │   ├── Repositories/
│   │   │   │   │   └── IVinculoRepository.cs
│   │   │   │   └── VinculoAggregate.cs
│   │   │   │
│   │   │   └── Auditoria/                       # BC: Rastreabilidade
│   │   │       ├── Entities/
│   │   │       │   └── RegistroAuditoria.cs
│   │   │       ├── DomainServices/
│   │   │       │   └── AuditoriaService.cs
│   │   │       ├── Repositories/
│   │   │       │   └── IAuditoriaRepository.cs
│   │   │       └── AuditoriaAggregate.cs
│   │   │
│   │   └── SharedKernel/                        # Código compartilhado entre BCs
│   │       ├── ValueObjects/
│   │       │   ├── EntityId.cs
│   │       │   ├── Email.cs
│   │       │   └── Percentual.cs
│   │       ├── DomainEvents/
│   │       │   └── DomainEvent.cs
│   │       └── Specifications/
│   │           └── Specification.cs
│   │
│   ├── Application/                             # Casos de Uso
│   │   ├── Pacientes/
│   │   │   ├── UseCases/
│   │   │   │   ├── CadastrarPaciente/
│   │   │   │   │   ├── CadastrarPacienteCommand.cs
│   │   │   │   │   ├── CadastrarPacienteCommandHandler.cs
│   │   │   │   │   └── CadastrarPacientePresenter.cs
│   │   │   │   ├── BuscarPacienteById/
│   │   │   │   ├── AtualizarPaciente/
│   │   │   │   └── ListarPacientes/
│   │   │   ├── DTOs/
│   │   │   │   ├── CriarPacienteDto.cs
│   │   │   │   ├── PacienteDto.cs
│   │   │   │   └── ResponsavelLegalDto.cs
│   │   │   └── Services/
│   │   │       └── PacienteApplicationService.cs
│   │   │
│   │   ├── Prontuarios/
│   │   │   ├── UseCases/
│   │   │   │   ├── AbrirProntuario/
│   │   │   │   ├── AdicionarAtendimento/
│   │   │   │   ├── RegistrarEvolucao/
│   │   │   │   ├── SubmeterDocumentoClinico/
│   │   │   │   └── AprovarDocumento/
│   │   │   ├── DTOs/
│   │   │   │   ├── ProntuarioDto.cs
│   │   │   │   ├── AtendimentoDto.cs
│   │   │   │   └── DocumentoClinicoDto.cs
│   │   │   └── Services/
│   │   │       └── ProntuarioApplicationService.cs
│   │   │
│   │   ├── Vinculos/
│   │   │   ├── UseCases/
│   │   │   │   ├── LiberarVinculo/
│   │   │   │   ├── RevogarVinculo/
│   │   │   │   ├── AprovarAcessoProntuario/
│   │   │   │   └── ValidarAcessoVinculo/
│   │   │   ├── DTOs/
│   │   │   │   └── VinculoDto.cs
│   │   │   └── Services/
│   │   │       └── VinculoApplicationService.cs
│   │   │
│   │   ├── Auditoria/
│   │   │   ├── UseCases/
│   │   │   │   └── RegistrarAcao/
│   │   │   ├── DTOs/
│   │   │   │   └── AuditoriaDto.cs
│   │   │   └── Services/
│   │   │       └── AuditoriaApplicationService.cs
│   │   │
│   │   └── Common/
│   │       ├── Interfaces/
│   │       │   ├── ICommandHandler.cs
│   │       │   ├── IQueryHandler.cs
│   │       │   └── IUnitOfWork.cs
│   │       ├── Behaviors/
│   │       │   ├── ValidationBehavior.cs
│   │       │   ├── LoggingBehavior.cs
│   │       │   └── AuditingBehavior.cs
│   │       └── Mappers/
│   │           └── AutomapperProfile.cs
│   │
│   └── Infrastructure/                         # Implementações técnicas
│       ├── Persistence/
│       │   ├── Configurations/
│       │   │   ├── PacienteConfiguration.cs
│       │   │   ├── ProntuarioConfiguration.cs
│       │   │   ├── VinculoConfiguration.cs
│       │   │   └── ...
│       │   ├── Repositories/
│       │   │   ├── PacienteRepository.cs
│       │   │   ├── ProntuarioRepository.cs
│       │   │   ├── VinculoRepository.cs
│       │   │   └── AuditoriaRepository.cs
│       │   ├── Migrations/
│       │   │   └── ...
│       │   ├── Seeds/
│       │   │   └── DatabaseSeeder.cs
│       │   └── ClinicaEscolaDbContext.cs
│       │
│       ├── Identity/
│       │   ├── ApplicationUser.cs
│       │   ├── IdentityService.cs
│       │   └── PermissionService.cs
│       │
│       ├── Notifications/
│       │   ├── IEmailNotificationService.cs
│       │   └── EmailNotificationService.cs
│       │
│       ├── ExternalServices/
│       │   ├── IValidationService.cs (CPF, etc)
│       │   └── ValidationService.cs
│       │
│       └── Events/
│           ├── DomainEventDispatcher.cs
│           └── EventHandlers/
│               ├── PacienteCriadoEventHandler.cs
│               └── VinculoLiberadoEventHandler.cs
│
└── Presentation/                                # Camada de Apresentação
    ├── Controllers/
    │   ├── Pacientes/
    │   │   └── PacientesController.cs
    │   ├── Prontuarios/
    │   │   └── ProntuariosController.cs
    │   ├── Vinculos/
    │   │   └── VinculosController.cs
    │   └── Auditoria/
    │       └── AuditoriaController.cs
    │
    ├── ViewModels/
    │   ├── Pacientes/
    │   │   └── CadastrarPacienteViewModel.cs
    │   ├── Prontuarios/
    │   │   └── ProntuarioDetalhesViewModel.cs
    │   └── Vinculos/
    │       └── LiberarVinculoViewModel.cs
    │
    ├── Views/
    │   ├── Pacientes/
    │   ├── Prontuarios/
    │   └── Vinculos/
    │
    └── Startup.cs / Program.cs
```

# 3. Conceitos Centrais da Arquitetura DDD

## 3.1 Agregados Raiz

Um agregado é um cluster coeso de objetos tratado como uma unidade para fins de mudanças de dados.

### **Agregado: Paciente**
```csharp
public class PacienteAggregate : AggregateRoot
{
    public Paciente Paciente { get; set; }
    
    public IReadOnlyList<ResponsavelLegal> ResponsaveisLegais 
        => _responsaveisLegais.AsReadOnly();
    
    public IReadOnlyList<TratamentoAnterior> TratamentosAnteriores 
        => _tratamentosAnteriores.AsReadOnly();
    
    // Métodos de negócio
    public void Cadastrar(string nome, string cpf, DateTime dataNascimento)
    {
        if (!ValidarCPF(cpf)) throw new CpfInvalidoException();
        
        Paciente = new Paciente(nome, cpf, dataNascimento);
        
        AddDomainEvent(new PacienteCriadoEvent(Paciente.Id, nome));
    }
    
    public void AdicionarResponsavelLegal(ResponsavelLegal responsavel)
    {
        if (_responsaveisLegais.Count >= 2) 
            throw new LimiteResponsaveisChazeException();
        
        _responsaveisLegais.Add(responsavel);
    }
}
```

### **Agregado: Prontuário**
```csharp
public class ProntuarioAggregate : AggregateRoot
{
    public Prontuario Prontuario { get; set; }
    
    public IReadOnlyList<Atendimento> Atendimentos 
        => _atendimentos.AsReadOnly();
    
    public IReadOnlyList<DocumentoClinico> DocumentosClinicos 
        => _documentosClinicos.AsReadOnly();
    
    // Métodos de negócio
    public void Abrir(Guid pacienteId, Guid estagiarioId)
    {
        Prontuario = new Prontuario(pacienteId, estagiarioId);
        AddDomainEvent(new ProntuarioAbertoDomainEvent(Prontuario.Id));
    }
    
    public void AdicionarAtendimento(Atendimento atendimento)
    {
        if (!ProntuarioEstaAtivo())
            throw new ProntuarioNaoAtivoException();
        
        _atendimentos.Add(atendimento);
    }
    
    public void SubmeterDocumento(DocumentoClinico doc)
    {
        if (doc.Status != StatusDocumento.Rascunho)
            throw new DocumentoJaSubmetidoException();
        
        doc.Submeter();
        _documentosClinicos.Add(doc);
        
        AddDomainEvent(new DocumentoSubmetidoDomainEvent(doc.Id));
    }
}
```

### **Agregado: Vínculo**
```csharp
public class VinculoAggregate : AggregateRoot
{
    public VinculoAlunoPaciente Vinculo { get; set; }
    
    // Métodos de negócio
    public void Liberar(Guid alunoId, Guid pacienteId, Guid professoraId)
    {
        if (JaExisteVinculoAtivo(alunoId, pacienteId))
            throw new VinculoDuplicadoException();
        
        Vinculo = new VinculoAlunoPaciente(alunoId, pacienteId, professoraId);
        
        AddDomainEvent(new VinculoLiberadoDomainEvent(Vinculo.Id, alunoId, pacienteId));
    }
    
    public void Revogar(string motivo, Guid revogadoPor)
    {
        if (!Vinculo.EstaAtivo())
            throw new VinculoJaRevogadoException();
        
        Vinculo.Revogar(motivo, revogadoPor);
        
        AddDomainEvent(new VinculoRevogadoDomainEvent(Vinculo.Id, motivo));
    }
    
    public void ValidarAcesso(Guid estagiarioId, Guid pacienteId)
    {
        if (Vinculo.EstagiarioId != estagiarioId || Vinculo.PacienteId != pacienteId)
            throw new AcessoNaoAutorizadoException();
        
        if (!Vinculo.EstaAtivo())
            throw new VinculoInativoException();
    }
}
```

## 3.2 Value Objects

Value Objects não possuem identidade, apenas valor. São imutáveis.

```csharp
// CPF como Value Object
public class CPF : ValueObject
{
    public string Valor { get; }
    
    private CPF(string valor)
    {
        if (!ValidarCPF(valor))
            throw new CpfInvalidoException($"CPF {valor} é inválido");
        
        Valor = LimparCPF(valor);
    }
    
    public static CPF Criar(string valor)
        => new CPF(valor);
    
    private static bool ValidarCPF(string cpf) 
        => CpfValidator.Validar(cpf);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Valor;
    }
}

// Status do Documento como Value Object
public class StatusDocumento : ValueObject
{
    public static readonly StatusDocumento Rascunho = new("Rascunho");
    public static readonly StatusDocumento Submetido = new("Submetido");
    public static readonly StatusDocumento Aprovado = new("Aprovado");
    public static readonly StatusDocumento Rejeitado = new("Rejeitado");
    
    public string Valor { get; }
    
    private StatusDocumento(string valor) => Valor = valor;
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Valor;
    }
}
```

## 3.3 Domain Services

Encapsulam lógica que não pertence naturalmente a uma entidade ou value object.

```csharp
// Validar acesso do estagiário ao prontuário
public interface IValidarAcessoProntuarioService
{
    Task<bool> PodeAcessar(Guid estagiarioId, Guid prontuarioId);
}

public class ValidarAcessoProntuarioService : IValidarAcessoProntuarioService
{
    private readonly IVinculoRepository _vinculoRepository;
    private readonly IProntuarioRepository _prontuarioRepository;
    private readonly IAprovacaoProntuarioService _aprovacaoService;
    
    public async Task<bool> PodeAcessar(Guid estagiarioId, Guid prontuarioId)
    {
        var prontuario = await _prontuarioRepository.GetByIdAsync(prontuarioId);
        if (prontuario == null) return false;
        
        var vinculo = await _vinculoRepository.GetByEstagiarioPacienteAsync(
            estagiarioId, prontuario.PacienteId);
        
        if (vinculo == null || !vinculo.EstaAtivo())
            return false;
        
        // Verificar se requer aprovação
        if (RequerAprovacao(prontuario, vinculo))
        {
            return await _aprovacaoService.FoiAprovado(estagiarioId, prontuarioId);
        }
        
        return true;
    }
    
    private bool RequerAprovacao(Prontuario prontuario, VinculoAlunoPaciente vinculo)
        => vinculo.IsNovoEstagiario() || prontuario.IsEspecial();
}
```

## 3.4 Repositories (Pattern)

Interface no Domain, implementação na Infrastructure.

```csharp
// Contrato no Domain
namespace ClinicaEscola.Core.Domain.Pacientes.Repositories
{
    public interface IPacienteRepository
    {
        Task<PacienteAggregate> GetByIdAsync(Guid id);
        Task<PacienteAggregate> GetByCpfAsync(string cpf);
        Task<IEnumerable<PacienteAggregate>> GetAtivosAsync();
        Task AddAsync(PacienteAggregate aggregate);
        Task UpdateAsync(PacienteAggregate aggregate);
        Task DeleteAsync(Guid id);
    }
}

// Implementação na Infrastructure
namespace ClinicaEscola.Infrastructure.Persistence.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicaEscolaDbContext _context;
        
        public async Task<PacienteAggregate> GetByIdAsync(Guid id)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.ResponsaveisLegais)
                .Include(p => p.TratamentosAnteriores)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            return paciente?.ToAggregate();
        }
        
        public async Task AddAsync(PacienteAggregate aggregate)
        {
            _context.Pacientes.Add(aggregate.Paciente);
            
            foreach (var responsavel in aggregate.ResponsaveisLegais)
                _context.ResponsaveisLegais.Add(responsavel);
            
            await _context.SaveChangesAsync();
        }
    }
}
```

## 3.5 Use Cases com CQRS

Separação entre Commands (escrita) e Queries (leitura).

```csharp
// COMMAND: Cadastrar Paciente
public class CadastrarPacienteCommand : ICommand<Guid>
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public Endereco Endereco { get; set; }
}

// Command Handler
public class CadastrarPacienteCommandHandler : ICommandHandler<CadastrarPacienteCommand, Guid>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditoriaService _auditoria;
    
    public async Task<Guid> Handle(CadastrarPacienteCommand command)
    {
        // Verificar duplicação
        var jaExiste = await _pacienteRepository.GetByCpfAsync(command.CPF);
        if (jaExiste != null)
            throw new PacienteDuplicadoException(command.CPF);
        
        // Criar agregado
        var aggregate = new PacienteAggregate();
        aggregate.Cadastrar(command.Nome, command.CPF, command.DataNascimento);
        
        // Persistir
        await _pacienteRepository.AddAsync(aggregate);
        await _unitOfWork.CommitAsync();
        
        // Registrar auditoria
        await _auditoria.RegistrarAsync(
            TipoAcao.Criacao,
            "Paciente",
            aggregate.Paciente.Id
        );
        
        // Disparar eventos de domínio
        await _mediator.PublishAsync(aggregate.DomainEvents);
        
        return aggregate.Paciente.Id;
    }
}

// QUERY: Obter Detalhes do Prontuário
public class ObterProntuarioDetalhadoQuery : IQuery<ProntuarioDetalhadoDto>
{
    public Guid ProntuarioId { get; set; }
    public Guid EstagiarioId { get; set; }
    
    public ObterProntuarioDetalhadoQuery(Guid prontuarioId, Guid estagiarioId)
    {
        ProntuarioId = prontuarioId;
        EstagiarioId = estagiarioId;
    }
}

// Query Handler
public class ObterProntuarioDetalhadoQueryHandler 
    : IQueryHandler<ObterProntuarioDetalhadoQuery, ProntuarioDetalhadoDto>
{
    private readonly IProntuarioRepository _prontuarioRepository;
    private readonly IValidarAcessoProntuarioService _validarAcesso;
    private readonly IMapper _mapper;
    
    public async Task<ProntuarioDetalhadoDto> Handle(ObterProntuarioDetalhadoQuery query)
    {
        // Validar acesso
        var temAcesso = await _validarAcesso.PodeAcessar(query.EstagiarioId, query.ProntuarioId);
        if (!temAcesso)
            throw new AcessoNegadoException();
        
        // Buscar dados
        var prontuario = await _prontuarioRepository.GetByIdAsync(query.ProntuarioId);
        if (prontuario == null)
            throw new ProntuarioNaoEncontradoException();
        
        return _mapper.Map<ProntuarioDetalhadoDto>(prontuario);
    }
}
```

## 3.6 Behaviors (Pipeline Middleware)

Validação, logging e auditoria automáticos em todos os commands/queries.

```csharp
// Validação automática
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, 
        Func<Task<TResponse>> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = (await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken))))
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();
        
        if (failures.Count != 0)
            throw new ValidationException(failures);
        
        return await next();
    }
}

// Auditoria automática
public class AuditingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IAuditableRequest
{
    private readonly IAuditoriaService _auditoria;
    
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, 
        Func<Task<TResponse>> next)
    {
        var startTime = DateTime.UtcNow;
        
        try
        {
            var response = await next();
            
            await _auditoria.RegistrarAsync(
                request.TipoAcao,
                request.Entidade,
                request.IdEntidade,
                resultado: "Sucesso",
                duracao: DateTime.UtcNow - startTime
            );
            
            return response;
        }
        catch (Exception ex)
        {
            await _auditoria.RegistrarAsync(
                request.TipoAcao,
                request.Entidade,
                request.IdEntidade,
                resultado: "Erro",
                detalhes: ex.Message,
                duracao: DateTime.UtcNow - startTime
            );
            throw;
        }
    }
}
```

# 4. Fluxo Completo: Cadastro de Paciente em DDD

```
┌─────────────────────────────────────────────────────────────────┐
│ APRESENTAÇÃO (MVC)                                              │
├─────────────────────────────────────────────────────────────────┤
│ PacientesController.CadastrarAsync(viewModel)                    │
│  └─> MapPara(CadastrarPacienteCommand)                           │
└────────────────────────┬────────────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────────────┐
│ APPLICATION LAYER (Use Case)                                    │
├─────────────────────────────────────────────────────────────────┤
│ CadastrarPacienteCommandHandler.Handle(command)                  │
│  ├─> ValidationBehavior (valida entrada)                        │
│  ├─> AuthorizationBehavior (verifica permissão)                 │
│  └─> AuditingBehavior (prepara auditoria)                       │
└────────────────────────┬────────────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────────────┐
│ DOMAIN LAYER (Lógica de Negócio)                                │
├─────────────────────────────────────────────────────────────────┤
│ PacienteAggregate.Cadastrar(...)                                 │
│  ├─> Validar CPF (Value Object CPF)                             │
│  ├─> Validar duplicação (IPacienteRepository)                   │
│  ├─> Criar Paciente (Entity)                                    │
│  ├─> Criar Prontuário associado (Domain Service)                │
│  ├─> Gerar Domain Event: PacienteCriadoEvent                    │
│  └─> Adicionar eventos ao agregado                              │
└────────────────────────┬────────────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────────────┐
│ INFRASTRUCTURE LAYER                                             │
├─────────────────────────────────────────────────────────────────┤
│ PacienteRepository.AddAsync(aggregate)                           │
│  ├─> Persistir Paciente, Prontuário, Responsáveis               │
│  └─> Retornar Guid                                              │
└────────────────────────┬────────────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────────────┐
│ EVENT HANDLING (Sideeffects)                                    │
├─────────────────────────────────────────────────────────────────┤
│ DomainEventDispatcher.PublishAsync(events)                      │
│  ├─> PacienteCriadoEventHandler                                 │
│  │   └─> Enviar email de confirmação                            │
│  ├─> PacienteCriadoNotificationHandler                          │
│  │   └─> Notificar Coordenador                                  │
│  └─> PacienteCriadoAuditoriaHandler                             │
│      └─> Registrar em auditoria detalhada                       │
└─────────────────────────────────────────────────────────────────┘

RESULTADO: Paciente cadastrado, prontuário aberto, eventos disparados,
tudo auditado, sem acoplamento entre camadas!
```

# 5. Benefícios da Arquitetura DDD vs MVC

| Benefício | Descrição |
|---|---|
| **Isolamento de Lógica** | Regras de negócio concentradas no Domain, fácil de testar |
| **Escalabilidade** | Novos agregados não afetam os existentes |
| **Rastreabilidade** | Domain Events permitem auditoria detalhada |
| **Reusabilidade** | Use Cases independentes podem ser composto |
| **Testabilidade** | Domain não depende de Infrastructure |
| **Evolução** | Mudanças de requisitos isoladas por Bounded Context |
| **Performance** | CQRS permite otimizações específicas de read/write |
| **Comunicação** | Linguagem ubíqua clara entre negócio e desenvolvimento |

# 6. Transição de MVC para DDD

1. **Fase 1**: Identificar agregados raiz e elementos do domínio
2. **Fase 2**: Criar Value Objects e Entities
3. **Fase 3**: Implementar Domain Services
4. **Fase 4**: Criar Use Cases (Commands/Queries)
5. **Fase 5**: Implementar Repositories e Infrastructure
6. **Fase 6**: Wiring com Dependency Injection
7. **Fase 7**: Testar com testes unitários de agregados
8. **Fase 8**: Controllers apenas como adaptadores para HTTP

# 7. Stack Recomendada para DDD

| Componente | Tecnologia |
|---|---|
| **Framework Web** | ASP.NET Core 6+ |
| **ORM** | Entity Framework Core 6+ |
| **Validação** | FluentValidation |
| **Mediator CQRS** | MediatR |
| **Mapping** | AutoMapper |
| **Logging** | Serilog |
| **Event Bus** | MassTransit ou NServiceBus (opcional) |
| **Tests** | xUnit + Moq + FluentAssertions |
| **DDD Utils** | NHibernate.Specification (para Specifications) |

# 8. Exemplo Completo de Use Case

```csharp
// ========== COMMAND ==========
public class AprovarDocumentoClinicoCommand : ICommand<Unit>, IAuditableRequest
{
    public Guid DocumentoId { get; set; }
    public Guid SupervisorId { get; set; }
    
    public string TipoAcao => "Aprovação";
    public string Entidade => "DocumentoClinico";
    public Guid IdEntidade => DocumentoId;
}

// ========== VALIDATOR ==========
public class AprovarDocumentoClinicoCommandValidator 
    : AbstractValidator<AprovarDocumentoClinicoCommand>
{
    public AprovarDocumentoClinicoCommandValidator()
    {
        RuleFor(x => x.DocumentoId)
            .NotEmpty().WithMessage("ID do documento inválido");
        
        RuleFor(x => x.SupervisorId)
            .NotEmpty().WithMessage("ID do supervisor inválido");
    }
}

// ========== HANDLER ==========
public class AprovarDocumentoClinicoCommandHandler 
    : ICommandHandler<AprovarDocumentoClinicoCommand>
{
    private readonly IDocumentoClinicoRepository _documentoRepository;
    private readonly IApplicationUserRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _mediatrPublisher;
    
    public async Task<Unit> Handle(AprovarDocumentoClinicoCommand command, 
        CancellationToken cancellationToken)
    {
        // Validar permissão
        var supervisor = await _usuarioRepository.GetByIdAsync(command.SupervisorId);
        if (supervisor?.Role != UserRole.Supervisor)
            throw new PermissionDeniedException("Apenas supervisores podem aprovar");
        
        // Buscar agregado
        var prontuarioAggregate = await _documentoRepository
            .GetProntuarioByDocumentoIdAsync(command.DocumentoId, cancellationToken);
        
        if (prontuarioAggregate == null)
            throw new DocumentoNaoEncontradoException();
        
        // Aplicar regra de negócio
        prontuarioAggregate.AprovarDocumento(command.DocumentoId, supervisor.Id);
        
        // Persistir
        await _documentoRepository.UpdateAsync(prontuarioAggregate, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        
        // Disparar eventos
        foreach (var domainEvent in prontuarioAggregate.DomainEvents)
            await _mediatrPublisher.Publish((INotification)domainEvent, cancellationToken);
        
        return Unit.Value;
    }
}

// ========== DOMAIN EVENT HANDLER ==========
public class DocumentoAprovadoDomainEventHandler 
    : INotificationHandler<DocumentoAprovadoDomainEvent>
{
    private readonly IEmailService _emailService;
    private readonly IAuditoriaService _auditoria;
    
    public async Task Handle(DocumentoAprovadoDomainEvent @event, 
        CancellationToken cancellationToken)
    {
        // Notificar estagiário
        await _emailService.EnviarAsync(
            @event.EstagiarioEmail,
            "Documento Aprovado",
            $"Seu documento {DocumentoType.GetDescription(@event.TipoDocumento)} foi aprovado",
            cancellationToken
        );
        
        // Registrar auditoria detalhada
        await _auditoria.RegistrarAsync(
            TipoAcao.Aprovacao,
            "DocumentoClinico",
            @event.DocumentoId,
            detalhes: $"Aprovado por {@event.AprovadoPor} em {DateTime.UtcNow:G}",
            cancellationToken: cancellationToken
        );
    }
}

// ========== CONTROLLER ==========
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Supervisor")]
public class DocumentosController : ControllerBase
{
    private readonly IMediator _mediator;
    
    [HttpPost("{documentoId:guid}/aprovar")]
    public async Task<IActionResult> Aprovar(Guid documentoId)
    {
        var supervisorId = User.GetUserId(); // Extrair do JWT
        
        var command = new AprovarDocumentoClinicoCommand 
        { 
            DocumentoId = documentoId,
            SupervisorId = supervisorId
        };
        
        try
        {
            await _mediator.Send(command);
            return Ok(new { message = "Documento aprovado com sucesso" });
        }
        catch (DomainException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
```

# 9. Considerações Finais

A arquitetura DDD é ideal para o Connectamente porque:

1. **Domínio complexo**: Regras de acesso, aprovações e auditoria são intrincadas
2. **Evolução frequente**: Requisitos de psicologia mudam; DDD isola mudanças
3. **Auditoria crítica**: Events permitem rastreamento completo
4. **Múltiplos atores**: Estagiários, supervisores, administradores com permissões distintas
5. **Dados sensíveis**: Isolamento de lógica reduz risco de vazamentos

**Próximas etapas sugeridas:**
- Implementar a base de Infrastructure (Repositories, DbContext)
- Criar agg regados existentes como Bounded Contexts
- Implementar Use Cases mais críticos primeiro (acesso prontuário, aprovação)
- Adicionar testes de domínio com especificações
- Integrar com Identity framework para autorização baseada em roles
