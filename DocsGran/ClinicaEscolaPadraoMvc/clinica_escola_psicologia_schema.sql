/*
  Banco de dados inicial - Clínica Escola de Psicologia
  SGBD alvo: SQL Server
  Observação: este script assume que as tabelas do ASP.NET Identity já existem,
  especialmente dbo.AspNetUsers.
*/

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* =========================================================
   PACIENTES
   Baseado na ficha de identificação do paciente.
   ========================================================= */
CREATE TABLE dbo.Pacientes (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Pacientes PRIMARY KEY DEFAULT NEWID(),
    NomeCompleto NVARCHAR(200) NOT NULL,
    DataNascimento DATE NULL,
    Sexo NVARCHAR(20) NULL,
    Naturalidade NVARCHAR(120) NULL,
    EstadoNascimento NVARCHAR(60) NULL,
    Escolaridade NVARCHAR(120) NULL,
    Profissao NVARCHAR(120) NULL,
    RG NVARCHAR(30) NULL,
    CPF NVARCHAR(20) NULL,
    EstadoCivil NVARCHAR(60) NULL,
    Religiao NVARCHAR(120) NULL,
    EnderecoLogradouro NVARCHAR(200) NULL,
    EnderecoNumero NVARCHAR(20) NULL,
    Bairro NVARCHAR(120) NULL,
    Cidade NVARCHAR(120) NULL,
    CEP NVARCHAR(20) NULL,
    Telefone NVARCHAR(30) NULL,
    TelefoneRecado NVARCHAR(30) NULL,
    NomePai NVARCHAR(200) NULL,
    NomeMae NVARCHAR(200) NULL,
    Observacoes NVARCHAR(MAX) NULL,
    Ativo BIT NOT NULL CONSTRAINT DF_Pacientes_Ativo DEFAULT (1),
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_Pacientes_DataCriacao DEFAULT SYSUTCDATETIME(),
    DataAtualizacao DATETIME2 NULL
);
GO

CREATE UNIQUE INDEX UX_Pacientes_CPF
    ON dbo.Pacientes (CPF)
    WHERE CPF IS NOT NULL;
GO

CREATE INDEX IX_Pacientes_NomeCompleto
    ON dbo.Pacientes (NomeCompleto);
GO

/* =========================================================
   PRONTUÁRIOS
   Um prontuário por paciente.
   ========================================================= */
CREATE TABLE dbo.Prontuarios (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Prontuarios PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    NumeroProntuario NVARCHAR(50) NOT NULL,
    DataPrimeiraConsulta DATE NULL,
    SituacaoProntuario NVARCHAR(30) NOT NULL CONSTRAINT DF_Prontuarios_Situacao DEFAULT ('Ativo'),
    ObservacoesGerais NVARCHAR(MAX) NULL,
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_Prontuarios_DataCriacao DEFAULT SYSUTCDATETIME(),
    DataAtualizacao DATETIME2 NULL,
    CONSTRAINT FK_Prontuarios_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT CK_Prontuarios_Situacao CHECK (SituacaoProntuario IN ('Ativo','Arquivado','Encerrado'))
);
GO

CREATE UNIQUE INDEX UX_Prontuarios_PacienteId
    ON dbo.Prontuarios (PacienteId);
GO

CREATE UNIQUE INDEX UX_Prontuarios_NumeroProntuario
    ON dbo.Prontuarios (NumeroProntuario);
GO

/* =========================================================
   TRATAMENTOS ANTERIORES DO PACIENTE
   ========================================================= */
CREATE TABLE dbo.TratamentosAnterioresPaciente (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_TratamentosAnterioresPaciente PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    TipoTratamento NVARCHAR(30) NOT NULL,
    PossuiHistorico BIT NOT NULL CONSTRAINT DF_TratamentosAnterioresPaciente_PossuiHistorico DEFAULT (0),
    MotivoInternacao NVARCHAR(500) NULL,
    Observacoes NVARCHAR(MAX) NULL,
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_TratamentosAnterioresPaciente_DataCriacao DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_TratamentosAnterioresPaciente_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT CK_TratamentosAnterioresPaciente_Tipo CHECK (TipoTratamento IN ('Psicologico','Neurologico','Psiquiatrico','Cardiologico','Internacao','Outro'))
);
GO

CREATE INDEX IX_TratamentosAnterioresPaciente_PacienteId
    ON dbo.TratamentosAnterioresPaciente (PacienteId);
GO

/* =========================================================
   RESPONSÁVEIS LEGAIS
   ========================================================= */
CREATE TABLE dbo.ResponsaveisLegais (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_ResponsaveisLegais PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    NomeCompleto NVARCHAR(200) NOT NULL,
    RG NVARCHAR(30) NULL,
    CPF NVARCHAR(20) NULL,
    GrauParentesco NVARCHAR(80) NULL,
    Telefone NVARCHAR(30) NULL,
    Email NVARCHAR(200) NULL,
    Endereco NVARCHAR(300) NULL,
    ResponsavelPrincipal BIT NOT NULL CONSTRAINT DF_ResponsaveisLegais_ResponsavelPrincipal DEFAULT (0),
    Ativo BIT NOT NULL CONSTRAINT DF_ResponsaveisLegais_Ativo DEFAULT (1),
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_ResponsaveisLegais_DataCriacao DEFAULT SYSUTCDATETIME(),
    DataAtualizacao DATETIME2 NULL,
    CONSTRAINT FK_ResponsaveisLegais_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id)
);
GO

CREATE INDEX IX_ResponsaveisLegais_PacienteId
    ON dbo.ResponsaveisLegais (PacienteId);
GO

/* =========================================================
   VÍNCULO ALUNO x PACIENTE
   A professora libera e revoga acesso.
   ========================================================= */
CREATE TABLE dbo.VinculosAlunoPaciente (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_VinculosAlunoPaciente PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    AlunoId NVARCHAR(450) NOT NULL,
    LiberadoPorUsuarioId NVARCHAR(450) NOT NULL,
    DataLiberacao DATETIME2 NOT NULL CONSTRAINT DF_VinculosAlunoPaciente_DataLiberacao DEFAULT SYSUTCDATETIME(),
    RevogadoPorUsuarioId NVARCHAR(450) NULL,
    DataRevogacao DATETIME2 NULL,
    StatusVinculo NVARCHAR(20) NOT NULL CONSTRAINT DF_VinculosAlunoPaciente_Status DEFAULT ('Ativo'),
    PermiteLeitura BIT NOT NULL CONSTRAINT DF_VinculosAlunoPaciente_PermiteLeitura DEFAULT (1),
    PermiteEscrita BIT NOT NULL CONSTRAINT DF_VinculosAlunoPaciente_PermiteEscrita DEFAULT (1),
    Observacoes NVARCHAR(MAX) NULL,
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_VinculosAlunoPaciente_DataCriacao DEFAULT SYSUTCDATETIME(),
    DataAtualizacao DATETIME2 NULL,
    CONSTRAINT FK_VinculosAlunoPaciente_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT FK_VinculosAlunoPaciente_Aluno FOREIGN KEY (AlunoId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_VinculosAlunoPaciente_LiberadoPor FOREIGN KEY (LiberadoPorUsuarioId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_VinculosAlunoPaciente_RevogadoPor FOREIGN KEY (RevogadoPorUsuarioId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT CK_VinculosAlunoPaciente_Status CHECK (StatusVinculo IN ('Ativo','Encerrado','Revogado'))
);
GO

CREATE INDEX IX_VinculosAlunoPaciente_PacienteId_Status
    ON dbo.VinculosAlunoPaciente (PacienteId, StatusVinculo);
GO

CREATE INDEX IX_VinculosAlunoPaciente_AlunoId_Status
    ON dbo.VinculosAlunoPaciente (AlunoId, StatusVinculo);
GO

CREATE UNIQUE INDEX UX_VinculosAlunoPaciente_Ativo
    ON dbo.VinculosAlunoPaciente (PacienteId, AlunoId)
    WHERE StatusVinculo = 'Ativo';
GO

/* =========================================================
   ATENDIMENTOS
   ========================================================= */
CREATE TABLE dbo.Atendimentos (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Atendimentos PRIMARY KEY DEFAULT NEWID(),
    ProntuarioId UNIQUEIDENTIFIER NOT NULL,
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    AlunoId NVARCHAR(450) NOT NULL,
    SupervisorId NVARCHAR(450) NULL,
    TipoAtendimento NVARCHAR(30) NOT NULL,
    DataHoraInicio DATETIME2 NOT NULL,
    DataHoraFim DATETIME2 NULL,
    StatusAtendimento NVARCHAR(20) NOT NULL CONSTRAINT DF_Atendimentos_Status DEFAULT ('Agendado'),
    FaltaJustificada BIT NOT NULL CONSTRAINT DF_Atendimentos_FaltaJustificada DEFAULT (0),
    Observacoes NVARCHAR(MAX) NULL,
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_Atendimentos_DataCriacao DEFAULT SYSUTCDATETIME(),
    DataAtualizacao DATETIME2 NULL,
    CONSTRAINT FK_Atendimentos_Prontuarios FOREIGN KEY (ProntuarioId) REFERENCES dbo.Prontuarios(Id),
    CONSTRAINT FK_Atendimentos_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT FK_Atendimentos_Aluno FOREIGN KEY (AlunoId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_Atendimentos_Supervisor FOREIGN KEY (SupervisorId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT CK_Atendimentos_Tipo CHECK (TipoAtendimento IN ('PlantaoPsicologico','SessaoIndividual','Devolutiva','Triagem','Outro')),
    CONSTRAINT CK_Atendimentos_Status CHECK (StatusAtendimento IN ('Agendado','Realizado','Cancelado','FaltaPaciente','FaltaAluno'))
);
GO

CREATE INDEX IX_Atendimentos_PacienteId_DataHoraInicio
    ON dbo.Atendimentos (PacienteId, DataHoraInicio);
GO

CREATE INDEX IX_Atendimentos_ProntuarioId_DataHoraInicio
    ON dbo.Atendimentos (ProntuarioId, DataHoraInicio);
GO

/* =========================================================
   DOCUMENTOS CLÍNICOS - TABELA BASE
   ========================================================= */
CREATE TABLE dbo.DocumentosClinicos (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_DocumentosClinicos PRIMARY KEY DEFAULT NEWID(),
    ProntuarioId UNIQUEIDENTIFIER NOT NULL,
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    AtendimentoId UNIQUEIDENTIFIER NULL,
    TipoDocumento NVARCHAR(50) NOT NULL,
    CriadoPorUsuarioId NVARCHAR(450) NOT NULL,
    SupervisorId NVARCHAR(450) NULL,
    StatusDocumento NVARCHAR(20) NOT NULL CONSTRAINT DF_DocumentosClinicos_Status DEFAULT ('Rascunho'),
    Versao INT NOT NULL CONSTRAINT DF_DocumentosClinicos_Versao DEFAULT (1),
    DataDocumento DATETIME2 NOT NULL CONSTRAINT DF_DocumentosClinicos_DataDocumento DEFAULT SYSUTCDATETIME(),
    FinalizadoEm DATETIME2 NULL,
    Observacoes NVARCHAR(MAX) NULL,
    ExcluidoLogicamente BIT NOT NULL CONSTRAINT DF_DocumentosClinicos_ExcluidoLogicamente DEFAULT (0),
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_DocumentosClinicos_DataCriacao DEFAULT SYSUTCDATETIME(),
    DataAtualizacao DATETIME2 NULL,
    CONSTRAINT FK_DocumentosClinicos_Prontuarios FOREIGN KEY (ProntuarioId) REFERENCES dbo.Prontuarios(Id),
    CONSTRAINT FK_DocumentosClinicos_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT FK_DocumentosClinicos_Atendimentos FOREIGN KEY (AtendimentoId) REFERENCES dbo.Atendimentos(Id),
    CONSTRAINT FK_DocumentosClinicos_CriadoPor FOREIGN KEY (CriadoPorUsuarioId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_DocumentosClinicos_Supervisor FOREIGN KEY (SupervisorId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT CK_DocumentosClinicos_Tipo CHECK (TipoDocumento IN (
        'IdentificacaoPaciente',
        'AnamneseAdulto',
        'AnamneseAdolescente',
        'PlantaoPsicologico',
        'EvolucaoAtendimento',
        'TermoPsicoterapiaIndividual',
        'TermoAutorizacaoMenor',
        'TermoCompromissoInformatizacao'
    )),
    CONSTRAINT CK_DocumentosClinicos_Status CHECK (StatusDocumento IN ('Rascunho','Finalizado','Revisado','Arquivado')),
    CONSTRAINT CK_DocumentosClinicos_Versao CHECK (Versao > 0)
);
GO

CREATE INDEX IX_DocumentosClinicos_PacienteId_Tipo_Data
    ON dbo.DocumentosClinicos (PacienteId, TipoDocumento, DataDocumento);
GO

CREATE INDEX IX_DocumentosClinicos_ProntuarioId_Data
    ON dbo.DocumentosClinicos (ProntuarioId, DataDocumento);
GO

/* =========================================================
   DOCUMENTO - IDENTIFICAÇÃO DO PACIENTE
   ========================================================= */
CREATE TABLE dbo.DocumentoIdentificacaoPaciente (
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_DocumentoIdentificacaoPaciente PRIMARY KEY,
    NumeroProntuarioInformado NVARCHAR(50) NULL,
    DataPrimeiraConsulta DATE NULL,
    NomePacienteNoFormulario NVARCHAR(200) NULL,
    DataNascimentoNoFormulario DATE NULL,
    SexoNoFormulario NVARCHAR(20) NULL,
    IdadeInformada INT NULL,
    ProfissaoNoFormulario NVARCHAR(120) NULL,
    NaturalidadeNoFormulario NVARCHAR(120) NULL,
    EstadoNoFormulario NVARCHAR(60) NULL,
    EscolaridadeNoFormulario NVARCHAR(120) NULL,
    RGNoFormulario NVARCHAR(30) NULL,
    CPFNoFormulario NVARCHAR(20) NULL,
    EstadoCivilNoFormulario NVARCHAR(60) NULL,
    EnderecoNoFormulario NVARCHAR(300) NULL,
    BairroNoFormulario NVARCHAR(120) NULL,
    CidadeNoFormulario NVARCHAR(120) NULL,
    CEPNoFormulario NVARCHAR(20) NULL,
    TelefoneNoFormulario NVARCHAR(30) NULL,
    TelefoneRecadoNoFormulario NVARCHAR(30) NULL,
    ReligiaoNoFormulario NVARCHAR(120) NULL,
    NomePaiNoFormulario NVARCHAR(200) NULL,
    NomeMaeNoFormulario NVARCHAR(200) NULL,
    ResponsavelNoFormulario NVARCHAR(200) NULL,
    GrauParentescoResponsavel NVARCHAR(80) NULL,
    OutrosTratamentos NVARCHAR(MAX) NULL,
    Observacoes NVARCHAR(MAX) NULL,
    CONSTRAINT FK_DocumentoIdentificacaoPaciente_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id)
);
GO

/* =========================================================
   ANAMNESE ADULTO
   ========================================================= */
CREATE TABLE dbo.AnamneseAdulto (
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_AnamneseAdulto PRIMARY KEY,
    FrequenciaAtendimento NVARCHAR(100) NULL,
    DataHoraAtendimento DATETIME2 NULL,
    QueixaPrincipal NVARCHAR(MAX) NULL,
    QueixaSecundaria NVARCHAR(MAX) NULL,
    Sintomas NVARCHAR(MAX) NULL,
    InicioPatologia NVARCHAR(MAX) NULL,
    FrequenciaPatologia NVARCHAR(MAX) NULL,
    IntensidadePatologia NVARCHAR(MAX) NULL,
    TratamentosAnteriores NVARCHAR(MAX) NULL,
    Medicamentos NVARCHAR(MAX) NULL,
    HistoriaInfancia NVARCHAR(MAX) NULL,
    Rotina NVARCHAR(MAX) NULL,
    Vicios NVARCHAR(MAX) NULL,
    Hobbies NVARCHAR(MAX) NULL,
    Trabalho NVARCHAR(MAX) NULL,
    HistoricoFamiliarPais NVARCHAR(MAX) NULL,
    HistoricoFamiliarIrmaos NVARCHAR(MAX) NULL,
    HistoricoFamiliarConjuge NVARCHAR(MAX) NULL,
    HistoricoFamiliarFilhos NVARCHAR(MAX) NULL,
    HistoricoFamiliarLar NVARCHAR(MAX) NULL,
    HistoriaPatologicaPregressa NVARCHAR(MAX) NULL,
    ExameAparencia NVARCHAR(MAX) NULL,
    ExameComportamento NVARCHAR(MAX) NULL,
    AtitudeEntrevistador NVARCHAR(30) NULL,
    OrientacaoAutoIdentificatoria BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_OrientacaoAuto DEFAULT (0),
    OrientacaoCorporal BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_OrientacaoCorporal DEFAULT (0),
    OrientacaoTemporal BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_OrientacaoTemporal DEFAULT (0),
    OrientacaoEspacial BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_OrientacaoEspacial DEFAULT (0),
    OrientacaoPatologia BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_OrientacaoPatologia DEFAULT (0),
    ObservacoesOrientacao NVARCHAR(MAX) NULL,
    AtencaoVigilancia NVARCHAR(MAX) NULL,
    AtencaoTenacidade NVARCHAR(MAX) NULL,
    Memoria NVARCHAR(MAX) NULL,
    Inteligencia NVARCHAR(MAX) NULL,
    SensopercepcaoNormal BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_SensopercepcaoNormal DEFAULT (0),
    SensopercepcaoAlucinacao BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_SensopercepcaoAlucinacao DEFAULT (0),
    PensamentoAcelerado BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_PensamentoAcelerado DEFAULT (0),
    PensamentoRetardado BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_PensamentoRetardado DEFAULT (0),
    PensamentoFuga BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_PensamentoFuga DEFAULT (0),
    PensamentoBloqueio BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_PensamentoBloqueio DEFAULT (0),
    PensamentoProlixo BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_PensamentoProlixo DEFAULT (0),
    PensamentoRepeticao BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_PensamentoRepeticao DEFAULT (0),
    ConteudoObsessoes BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_ConteudoObsessoes DEFAULT (0),
    ConteudoHipocondrias BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_ConteudoHipocondrias DEFAULT (0),
    ConteudoFobias BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_ConteudoFobias DEFAULT (0),
    ConteudoDelirios BIT NOT NULL CONSTRAINT DF_AnamneseAdulto_ConteudoDelirios DEFAULT (0),
    ExpansaoEu NVARCHAR(MAX) NULL,
    RetracaoEu NVARCHAR(MAX) NULL,
    NegacaoEu NVARCHAR(MAX) NULL,
    Afetividade NVARCHAR(MAX) NULL,
    Humor NVARCHAR(50) NULL,
    ConscienciaDoencaAtual NVARCHAR(30) NULL,
    HipoteseDiagnostica NVARCHAR(MAX) NULL,
    CONSTRAINT FK_AnamneseAdulto_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id),
    CONSTRAINT CK_AnamneseAdulto_AtitudeEntrevistador CHECK (AtitudeEntrevistador IN ('Cooperativo','Resistente','Indiferente') OR AtitudeEntrevistador IS NULL),
    CONSTRAINT CK_AnamneseAdulto_Humor CHECK (Humor IN ('Normal','Exaltado','BaixaDeHumor','QuebraSubita') OR Humor IS NULL),
    CONSTRAINT CK_AnamneseAdulto_Consciencia CHECK (ConscienciaDoencaAtual IN ('Sim','Parcialmente','Nao') OR ConscienciaDoencaAtual IS NULL)
);
GO

/* =========================================================
   ANAMNESE ADOLESCENTE
   ========================================================= */
CREATE TABLE dbo.AnamneseAdolescente (
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_AnamneseAdolescente PRIMARY KEY,
    Escola NVARCHAR(200) NULL,
    PaiNome NVARCHAR(200) NULL,
    PaiIdade INT NULL,
    PaiInstrucao NVARCHAR(120) NULL,
    PaiProfissao NVARCHAR(120) NULL,
    MaeNome NVARCHAR(200) NULL,
    MaeIdade INT NULL,
    MaeInstrucao NVARCHAR(120) NULL,
    MaeProfissao NVARCHAR(120) NULL,
    CondicaoConjugalPais NVARCHAR(120) NULL,
    QueixaPrincipal NVARCHAR(MAX) NULL,
    DesdeQuando NVARCHAR(MAX) NULL,
    AtitudeMaeFrenteQueixa NVARCHAR(MAX) NULL,
    AtitudePaiFrenteQueixa NVARCHAR(MAX) NULL,
    AtitudeOutrosFamiliares NVARCHAR(MAX) NULL,
    FoiDesejado NVARCHAR(100) NULL,
    Linguagem NVARCHAR(MAX) NULL,
    DesenvolvimentoPsicomotor NVARCHAR(MAX) NULL,
    Sono NVARCHAR(MAX) NULL,
    Alimentacao NVARCHAR(MAX) NULL,
    Tiques NVARCHAR(MAX) NULL,
    DificuldadeEscolar NVARCHAR(MAX) NULL,
    FamiliarNervoso NVARCHAR(MAX) NULL,
    DescricaoFamiliarNervoso NVARCHAR(MAX) NULL,
    FamiliarProblemaMental NVARCHAR(MAX) NULL,
    ViciosFamilia NVARCHAR(MAX) NULL,
    LocalEstudo NVARCHAR(MAX) NULL,
    TiposDiversao NVARCHAR(MAX) NULL,
    FamiliaFazVisitas NVARCHAR(MAX) NULL,
    FamiliaRecebeVisitas NVARCHAR(MAX) NULL,
    Companheiros NVARCHAR(MAX) NULL,
    QuemEscolheCompanheiros NVARCHAR(MAX) NULL,
    Religiao NVARCHAR(MAX) NULL,
    CONSTRAINT FK_AnamneseAdolescente_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id)
);
GO

/* =========================================================
   PLANTÃO PSICOLÓGICO
   ========================================================= */
CREATE TABLE dbo.PlantaoPsicologico (
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_PlantaoPsicologico PRIMARY KEY,
    SinteseQueixaInicial NVARCHAR(MAX) NULL,
    RelatoAtendimento NVARCHAR(MAX) NULL,
    CondutaEncaminhamento NVARCHAR(MAX) NULL,
    NomeEstagiarioInformado NVARCHAR(200) NULL,
    NomeSupervisorInformado NVARCHAR(200) NULL,
    CRPSupervisor NVARCHAR(50) NULL,
    CONSTRAINT FK_PlantaoPsicologico_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id)
);
GO

/* =========================================================
   EVOLUÇÕES DO ATENDIMENTO
   ========================================================= */
CREATE TABLE dbo.EvolucoesAtendimento (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_EvolucoesAtendimento PRIMARY KEY DEFAULT NEWID(),
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL,
    AtendimentoId UNIQUEIDENTIFIER NULL,
    TextoEvolucao NVARCHAR(MAX) NOT NULL,
    DataEvolucao DATETIME2 NOT NULL CONSTRAINT DF_EvolucoesAtendimento_DataEvolucao DEFAULT SYSUTCDATETIME(),
    CriadoPorUsuarioId NVARCHAR(450) NOT NULL,
    SupervisorId NVARCHAR(450) NULL,
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_EvolucoesAtendimento_DataCriacao DEFAULT SYSUTCDATETIME(),
    DataAtualizacao DATETIME2 NULL,
    CONSTRAINT FK_EvolucoesAtendimento_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id),
    CONSTRAINT FK_EvolucoesAtendimento_Atendimentos FOREIGN KEY (AtendimentoId) REFERENCES dbo.Atendimentos(Id),
    CONSTRAINT FK_EvolucoesAtendimento_CriadoPor FOREIGN KEY (CriadoPorUsuarioId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_EvolucoesAtendimento_Supervisor FOREIGN KEY (SupervisorId) REFERENCES dbo.AspNetUsers(Id)
);
GO

CREATE INDEX IX_EvolucoesAtendimento_DocumentoClinicoId_DataEvolucao
    ON dbo.EvolucoesAtendimento (DocumentoClinicoId, DataEvolucao);
GO

/* =========================================================
   TERMO DE PSICOTERAPIA INDIVIDUAL
   ========================================================= */
CREATE TABLE dbo.TermosPsicoterapiaIndividual (
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_TermosPsicoterapiaIndividual PRIMARY KEY,
    NomeClienteNoTermo NVARCHAR(200) NULL,
    RGCliente NVARCHAR(30) NULL,
    EstadoCivilCliente NVARCHAR(60) NULL,
    ProfissaoCliente NVARCHAR(120) NULL,
    CidadeCliente NVARCHAR(120) NULL,
    RuaCliente NVARCHAR(200) NULL,
    TelefoneCliente NVARCHAR(30) NULL,
    NomeEstagiarioNoTermo NVARCHAR(200) NULL,
    TelefoneEstagiario NVARCHAR(30) NULL,
    DataAssinatura DATE NULL,
    DataInicioVigencia DATE NULL,
    DataFimVigencia DATE NULL,
    FrequenciaSemanal NVARCHAR(100) NULL,
    DuracaoSessaoMinutos INT NULL,
    Abordagem NVARCHAR(120) NULL,
    RegraCancelamento NVARCHAR(MAX) NULL,
    RegraFaltas NVARCHAR(MAX) NULL,
    Observacoes NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TermosPsicoterapiaIndividual_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id)
);
GO

/* =========================================================
   TERMO DE AUTORIZAÇÃO PARA MENOR
   ========================================================= */
CREATE TABLE dbo.TermosAutorizacaoMenor (
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_TermosAutorizacaoMenor PRIMARY KEY,
    ResponsavelLegalId UNIQUEIDENTIFIER NULL,
    RGResponsavel NVARCHAR(30) NULL,
    CPFResponsavel NVARCHAR(20) NULL,
    NomeMenorNoTermo NVARCHAR(200) NULL,
    DataNascimentoMenorNoTermo DATE NULL,
    AutorizaAtendimentoPsicologico BIT NOT NULL CONSTRAINT DF_TermosAutorizacaoMenor_AutorizaAtendimento DEFAULT (1),
    AutorizaColetaInformacoes BIT NOT NULL CONSTRAINT DF_TermosAutorizacaoMenor_AutorizaColeta DEFAULT (0),
    CienteDevolutivaMensal BIT NOT NULL CONSTRAINT DF_TermosAutorizacaoMenor_CienteDevolutiva DEFAULT (0),
    DataAssinatura DATE NULL,
    Observacoes NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TermosAutorizacaoMenor_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id),
    CONSTRAINT FK_TermosAutorizacaoMenor_ResponsaveisLegais FOREIGN KEY (ResponsavelLegalId) REFERENCES dbo.ResponsaveisLegais(Id)
);
GO

/* =========================================================
   TERMO DE COMPROMISSO PARA INFORMATIZAÇÃO
   ========================================================= */
CREATE TABLE dbo.TermosCompromissoInformatizacao (
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_TermosCompromissoInformatizacao PRIMARY KEY,
    EstagiarioUsuarioId NVARCHAR(450) NULL,
    PacienteId UNIQUEIDENTIFIER NULL,
    EnderecoEstagiario NVARCHAR(300) NULL,
    CPFEstagiario NVARCHAR(20) NULL,
    DeclarouAnuenciaPaciente BIT NOT NULL CONSTRAINT DF_TermosCompromissoInformatizacao_Anuencia DEFAULT (0),
    DeclarouSigiloProfissional BIT NOT NULL CONSTRAINT DF_TermosCompromissoInformatizacao_Sigilo DEFAULT (0),
    DataAssinaturaEstagiario DATE NULL,
    DataAssinaturaPaciente DATE NULL,
    Observacoes NVARCHAR(MAX) NULL,
    CONSTRAINT FK_TermosCompromissoInformatizacao_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id),
    CONSTRAINT FK_TermosCompromissoInformatizacao_Estagiario FOREIGN KEY (EstagiarioUsuarioId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_TermosCompromissoInformatizacao_Pacientes FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id)
);
GO

/* =========================================================
   TERMO DE RESPONSABILIDADE DO ESTAGIÁRIO
   Não depende de paciente.
   ========================================================= */
CREATE TABLE dbo.TermosResponsabilidadeEstagiario (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_TermosResponsabilidadeEstagiario PRIMARY KEY DEFAULT NEWID(),
    EstagiarioUsuarioId NVARCHAR(450) NOT NULL,
    MatriculaInformada NVARCHAR(50) NULL,
    DeclarouRecebimentoManual BIT NOT NULL CONSTRAINT DF_TermosResponsabilidadeEstagiario_RecebimentoManual DEFAULT (0),
    DeclarouCienciaNormas BIT NOT NULL CONSTRAINT DF_TermosResponsabilidadeEstagiario_CienciaNormas DEFAULT (0),
    DataAssinatura DATE NULL,
    Observacoes NVARCHAR(MAX) NULL,
    DataCriacao DATETIME2 NOT NULL CONSTRAINT DF_TermosResponsabilidadeEstagiario_DataCriacao DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_TermosResponsabilidadeEstagiario_Estagiario FOREIGN KEY (EstagiarioUsuarioId) REFERENCES dbo.AspNetUsers(Id)
);
GO

CREATE INDEX IX_TermosResponsabilidadeEstagiario_EstagiarioUsuarioId
    ON dbo.TermosResponsabilidadeEstagiario (EstagiarioUsuarioId, DataAssinatura);
GO

/* =========================================================
   ANEXOS
   ========================================================= */
CREATE TABLE dbo.Anexos (
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Anexos PRIMARY KEY DEFAULT NEWID(),
    DocumentoClinicoId UNIQUEIDENTIFIER NOT NULL,
    NomeOriginal NVARCHAR(255) NOT NULL,
    NomeArmazenado NVARCHAR(255) NOT NULL,
    Extensao NVARCHAR(20) NULL,
    MimeType NVARCHAR(100) NULL,
    TamanhoBytes BIGINT NOT NULL,
    CaminhoArquivo NVARCHAR(500) NOT NULL,
    HashArquivo NVARCHAR(128) NULL,
    EnviadoPorUsuarioId NVARCHAR(450) NOT NULL,
    DataUpload DATETIME2 NOT NULL CONSTRAINT DF_Anexos_DataUpload DEFAULT SYSUTCDATETIME(),
    Ativo BIT NOT NULL CONSTRAINT DF_Anexos_Ativo DEFAULT (1),
    CONSTRAINT FK_Anexos_DocumentosClinicos FOREIGN KEY (DocumentoClinicoId) REFERENCES dbo.DocumentosClinicos(Id),
    CONSTRAINT FK_Anexos_EnviadoPor FOREIGN KEY (EnviadoPorUsuarioId) REFERENCES dbo.AspNetUsers(Id)
);
GO

CREATE INDEX IX_Anexos_DocumentoClinicoId
    ON dbo.Anexos (DocumentoClinicoId);
GO

/* =========================================================
   AUDITORIA
   ========================================================= */
CREATE TABLE dbo.Auditoria (
    Id BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Auditoria PRIMARY KEY,
    UsuarioId NVARCHAR(450) NULL,
    TipoAcao NVARCHAR(30) NOT NULL,
    Entidade NVARCHAR(120) NOT NULL,
    RegistroId NVARCHAR(120) NULL,
    PacienteId UNIQUEIDENTIFIER NULL,
    ProntuarioId UNIQUEIDENTIFIER NULL,
    DataHora DATETIME2 NOT NULL CONSTRAINT DF_Auditoria_DataHora DEFAULT SYSUTCDATETIME(),
    IP NVARCHAR(45) NULL,
    UserAgent NVARCHAR(500) NULL,
    ValoresAntesJson NVARCHAR(MAX) NULL,
    ValoresDepoisJson NVARCHAR(MAX) NULL,
    Observacoes NVARCHAR(MAX) NULL,
    CONSTRAINT FK_Auditoria_Usuario FOREIGN KEY (UsuarioId) REFERENCES dbo.AspNetUsers(Id),
    CONSTRAINT FK_Auditoria_Paciente FOREIGN KEY (PacienteId) REFERENCES dbo.Pacientes(Id),
    CONSTRAINT FK_Auditoria_Prontuario FOREIGN KEY (ProntuarioId) REFERENCES dbo.Prontuarios(Id),
    CONSTRAINT CK_Auditoria_TipoAcao CHECK (TipoAcao IN (
        'Login','Logout','Insercao','Atualizacao','ExclusaoLogica',
        'Visualizacao','LiberacaoAcesso','RevogacaoAcesso',
        'FinalizacaoDocumento','Download','Impressao'
    ))
);
GO

CREATE INDEX IX_Auditoria_Entidade_RegistroId_DataHora
    ON dbo.Auditoria (Entidade, RegistroId, DataHora);
GO

CREATE INDEX IX_Auditoria_PacienteId_DataHora
    ON dbo.Auditoria (PacienteId, DataHora);
GO

CREATE INDEX IX_Auditoria_ProntuarioId_DataHora
    ON dbo.Auditoria (ProntuarioId, DataHora);
GO
