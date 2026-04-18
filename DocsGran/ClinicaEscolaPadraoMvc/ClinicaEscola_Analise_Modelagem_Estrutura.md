**CLÍNICA-ESCOLA DE PSICOLOGIA**

Análise documental, proposta de desenvolvimento,
definição do banco de dados e estrutura final das classes

*Base orientada para ASP.NET Core MVC, EF Core e Identity*

|  |  |
| --- | --- |
| Objeto | Digitalização integral dos documentos da clínica-escola |
| Contexto | Atendimentos realizados por alunos com acompanhamento da professora responsável |
| Premissa central | Aluno acessa apenas pacientes vinculados; professora administradora possui visão geral |
| Entregáveis consolidados | Modelagem conceitual, estrutura de dados, padronização de classes e organização final de projeto |
|  |  |
|  |  |
|  |  |

# 1. Leitura inicial do problema

**Observação importante:** os formulários enviados caracterizam uma clínica-escola de Psicologia, e não uma clínica psiquiátrica. A própria documentação menciona “Curso de Psicologia”, “Serviço Clínica Escola” e “atendimento psicológico”.

A partir disso, o sistema proposto foi pensado como um prontuário eletrônico acadêmico, com controle rígido de acesso por paciente, supervisão da professora e auditoria integral das ações.

# 2. Base documental analisada

|  |  |  |
| --- | --- | --- |
| Documento | Papel no sistema | Impacto na modelagem |
| IDENTIFICAÇÃO DO PACIENTE | Cadastro base do paciente e do prontuário | Originou Pacientes, Prontuarios, ResponsaveisLegais e TratamentosAnterioresPaciente |
| ANAMNESE ADULTO | Instrumento clínico extenso para adultos | Gerou tabela e model específica para anamnese adulta |
| ANAMNESE PARA ADOLESCENTES | Instrumento clínico distinto para adolescentes | Justificou tabela própria, separada da anamnese adulta |
| PLANTÃO PSICOLÓGICO | Registro inicial/episódico de atendimento | Originou model e fluxo específico de atendimento pontual |
| EVOLUÇÃO DO ATENDIMENTO | Registro longitudinal de sessões | Originou a entidade EvolucaoAtendimento |
| TERMO DE PSICOTERAPIA INDIVIDUAL | Condições de frequência, duração, faltas e desligamento | Exigiu estrutura para sessões, faltas e termo contratual |
| TERMO DE AUTORIZAÇÃO PARA MENORES | Consentimento do responsável legal | Reforçou cadastro de responsável e termo próprio |
| TERMO DE COMPROMISSO | Uso informatizado de dados psicológicos com sigilo | Reforçou auditoria, consentimento e responsabilidade ética |
| TERMO DE RESPONSABILIDADE DO ESTAGIÁRIO | Ciência das normas do estágio | Originou termo institucional vinculado ao aluno, não ao paciente |

# 3. Síntese da análise funcional

O sistema precisa guardar o ciclo completo do atendimento: cadastro do paciente, abertura do prontuário, autorização de acesso ao aluno, preenchimento de documentos clínicos, evolução das sessões e manutenção dos termos assinados.

Os formulários demonstram que um único “campo de observações” não seria suficiente. Há documentos muito distintos entre si, com estruturas próprias. Por isso, a modelagem foi separada por tipo documental.

A relação aluno-paciente é o centro da segurança do sistema. O aluno não pode consultar qualquer prontuário; ele só pode ver e editar os pacientes que a professora administradora liberou formalmente.

Como o contexto envolve dados clínicos e acadêmicos, toda ação relevante deve ser auditável: criação, edição, visualização, finalização, liberação de acesso, revogação de acesso, upload de anexos e consultas ao prontuário.

# 4. Sugestão de desenvolvimento

## 4.1. Stack sugerida

ASP.NET Core MVC para interface web.

Entity Framework Core para persistência e migrations.

ASP.NET Core Identity para autenticação, papéis e gestão de usuários.

SQL Server como banco de dados relacional.

Fluent API para mapear tabelas, relacionamentos, índices e restrições.

## 4.2. Regras centrais de negócio

|  |  |
| --- | --- |
| Regra | Decisão de projeto |
| Professora administradora | Acesso total a pacientes, prontuários, documentos, alunos, vínculos e auditoria |
| Aluno/estagiário | Acesso apenas a pacientes com vínculo ativo e liberado |
| Revogação de vínculo | Remove o acesso futuro, mas preserva a autoria histórica do que já foi produzido |
| Documentos clínicos | Controlados por tabela base e tabelas especializadas |
| Exclusão | Preferência por exclusão lógica em registros sensíveis |
| Auditoria | Registro de quem fez, quando fez, em qual entidade e, quando couber, o que mudou |

## 4.3. Organização em camadas

Models: classes persistidas e mapeadas pelo EF Core.

ViewModels: classes específicas para formulários, telas, listagens e detalhes do MVC.

Enums: regras enumeradas em pasta própria na raiz do projeto.

Configurations: mapeamentos Fluent API desacoplados das classes.

Data: ApplicationDbContext e infraestrutura de persistência.

# 5. Definição do banco de dados

A definição do banco foi pensada para preservar sigilo, rastreabilidade e separação adequada entre cadastro do paciente, prontuário, vínculo acadêmico e documentos clínicos.

## 5.1. Núcleo cadastral

|  |  |  |
| --- | --- | --- |
| Tabela / classe | Função | Relações principais |
| ApplicationUser | Usuário autenticado via Identity | Participa como professora, aluno, supervisor, autor e agente de auditoria |
| Paciente | Cadastro mestre do paciente | 1:1 com Prontuario; 1:N com documentos, atendimentos e responsáveis |
| Prontuario | Estrutura principal do histórico clínico | 1:1 com Paciente; 1:N com Atendimentos e DocumentosClinicos |
| ResponsavelLegal | Responsável por menor ou por necessidade específica | N:1 com Paciente |
| TratamentoAnteriorPaciente | Histórico de tratamentos anteriores | N:1 com Paciente |

## 5.2. Segurança acadêmica e operacional

|  |  |  |
| --- | --- | --- |
| Tabela / classe | Função | Observação |
| VinculoAlunoPaciente | Controla a autorização de acesso do aluno ao paciente | Guarda quem liberou, quando liberou e eventual revogação |
| Atendimento | Sessão ou ocorrência clínica | Suporta status, tipo, faltas e supervisão |
| Auditoria | Trilha de ações do sistema | Permite rastrear visualização, criação, edição, finalização e alterações |
| Anexo | Arquivos ligados aos documentos clínicos | Serve para PDFs assinados, digitalizações e anexos complementares |

## 5.3. Documentos clínicos

Foi adotada uma tabela base chamada DocumentoClinico para concentrar metadados comuns: paciente, prontuário, tipo, autor, supervisor, status, versão, data do documento e exclusão lógica. A partir dela derivam os tipos especializados abaixo.

|  |  |
| --- | --- |
| Classe especializada | Finalidade |
| DocumentoIdentificacaoPaciente | Formaliza a ficha de identificação como documento institucional |
| AnamneseAdulto | Estrutura própria para anamnese de adulto |
| AnamneseAdolescente | Estrutura própria para anamnese de adolescente |
| PlantaoPsicologico | Registro de plantão psicológico |
| EvolucaoAtendimento | Registro contínuo da evolução clínica |
| TermoPsicoterapiaIndividual | Termo de prestação de serviço e regras de atendimento |
| TermoAutorizacaoMenor | Consentimento do responsável legal |
| TermoCompromissoInformatizacao | Consentimento ligado ao uso informatizado dos dados |
| TermoResponsabilidadeEstagiario | Ciência institucional do aluno sobre regras do estágio |

## 5.4. Restrições e índices recomendados

Um único prontuário por paciente.

Número de prontuário único.

Impedir dois vínculos ativos iguais para o mesmo aluno e paciente.

Índices para busca por nome, CPF e número de prontuário.

Auditoria indexada por entidade, registro e data/hora.

# 6. Padrão final solicitado para as classes

A estrutura anterior foi readequada para o padrão desejado: entidades em Models, classes de tela em ViewModels fora de Models, e todos os enums em uma pasta Enums na raiz.

## 6.1. Estrutura final de pastas

ClinicaEscolaPadraoMvc/

README.md

Models/

AnamneseAdolescente.cs

AnamneseAdulto.cs

Anexo.cs

ApplicationUser.cs

Atendimento.cs

Auditoria.cs

DocumentoClinico.cs

DocumentoIdentificacaoPaciente.cs

EntityBase.cs

EvolucaoAtendimento.cs

Paciente.cs

PlantaoPsicologico.cs

Prontuario.cs

ResponsavelLegal.cs

TermoAutorizacaoMenor.cs

TermoCompromissoInformatizacao.cs

TermoPsicoterapiaIndividual.cs

TermoResponsabilidadeEstagiario.cs

TratamentoAnteriorPaciente.cs

VinculoAlunoPaciente.cs

ViewModels/

AnamneseAdolescenteViewModel.cs

AnamneseAdultoViewModel.cs

PacienteFormViewModel.cs

PlantaoPsicologicoViewModel.cs

ProntuarioDetalhesViewModel.cs

VinculoAlunoPacienteFormViewModel.cs

Enums/

SituacaoProntuario.cs

StatusAtendimento.cs

StatusDocumentoClinico.cs

StatusVinculo.cs

TipoAcaoAuditoria.cs

TipoAtendimento.cs

TipoDocumentoClinico.cs

TipoTratamentoAnterior.cs

TipoUsuario.cs

Configurations/

AnamneseAdolescenteConfiguration.cs

AnamneseAdultoConfiguration.cs

AnexoConfiguration.cs

ApplicationUserConfiguration.cs

AtendimentoConfiguration.cs

AuditoriaConfiguration.cs

DocumentoClinicoConfiguration.cs

DocumentoIdentificacaoPacienteConfiguration.cs

EvolucaoAtendimentoConfiguration.cs

PacienteConfiguration.cs

PlantaoPsicologicoConfiguration.cs

ProntuarioConfiguration.cs

ResponsavelLegalConfiguration.cs

TermoAutorizacaoMenorConfiguration.cs

TermoCompromissoInformatizacaoConfiguration.cs

TermoPsicoterapiaIndividualConfiguration.cs

TermoResponsabilidadeEstagiarioConfiguration.cs

TratamentoAnteriorPacienteConfiguration.cs

VinculoAlunoPacienteConfiguration.cs

Data/

ApplicationDbContext.cs

## 6.2. Classes em Models

|  |  |
| --- | --- |
| Classe | Papel |
| AnamneseAdolescente | Documento clínico de anamnese adolescente |
| AnamneseAdulto | Documento clínico de anamnese adulta |
| Anexo | Arquivo ligado ao documento |
| ApplicationUser | Usuário do sistema baseado em Identity |
| Atendimento | Sessão ou ocorrência clínica |
| Auditoria | Trilha de auditoria do sistema |
| DocumentoClinico | Metadados base de qualquer documento clínico |
| DocumentoIdentificacaoPaciente | Ficha documental de identificação |
| EntityBase | Classe base com Id, datas e indicador de ativo |
| EvolucaoAtendimento | Registro de evolução longitudinal |
| Paciente | Cadastro mestre do paciente |
| PlantaoPsicologico | Documento clínico de plantão |
| Prontuario | Prontuário principal do paciente |
| ResponsavelLegal | Responsável legal do paciente |
| TermoAutorizacaoMenor | Termo de autorização para menor |
| TermoCompromissoInformatizacao | Termo sobre uso informatizado com sigilo |
| TermoPsicoterapiaIndividual | Termo da psicoterapia individual |
| TermoResponsabilidadeEstagiario | Termo institucional do estagiário |
| TratamentoAnteriorPaciente | Histórico de tratamentos anteriores |
| VinculoAlunoPaciente | Autorização de acesso do aluno ao paciente |

## 6.3. Classes em ViewModels

|  |  |
| --- | --- |
| Classe | Uso principal |
| AnamneseAdolescenteViewModel | Formulário MVC para anamnese adolescente |
| AnamneseAdultoViewModel | Formulário MVC para anamnese adulta |
| PacienteFormViewModel | Tela de cadastro e edição do paciente |
| PlantaoPsicologicoViewModel | Formulário MVC de plantão psicológico |
| ProntuarioDetalhesViewModel | Tela consolidada do prontuário |
| VinculoAlunoPacienteFormViewModel | Tela de liberação do aluno para um paciente |

## 6.4. Enums na raiz

|  |  |
| --- | --- |
| Enum | Função |
| SituacaoProntuario | Situação do prontuário |
| StatusAtendimento | Status da sessão/atendimento |
| StatusDocumentoClinico | Estado do documento clínico |
| StatusVinculo | Situação do vínculo aluno-paciente |
| TipoAcaoAuditoria | Tipo de ação auditada |
| TipoAtendimento | Classificação do atendimento |
| TipoDocumentoClinico | Classificação do documento clínico |
| TipoTratamentoAnterior | Categoria de tratamento anterior |
| TipoUsuario | Papel principal do usuário no sistema |

# 7. Estrutura de dados final

A estrutura final ficou equilibrada para crescimento do projeto: uma base forte de persistência, separação clara entre modelo de banco e modelo de tela, uso de enums independentes e mapeamentos Fluent API desacoplados.

Models concentram a verdade estrutural e relacional do banco.

ViewModels atendem o MVC sem poluir as classes persistidas.

Enums permanecem na raiz para fácil reuso entre camadas.

Configurations preservam a leitura das entidades e deixam o mapeamento no local certo.

ApplicationDbContext centraliza os DbSets e a aplicação das configurações.

# 8. Encerramento

Com essa organização, o projeto já tem base suficiente para iniciar a implementação do sistema web: autenticação, autorização por vínculo, cadastro de pacientes, prontuários, documentos clínicos e trilha completa de auditoria.

A etapa seguinte mais natural é criar controllers, services, ViewModels adicionais de listagem e as primeiras telas MVC para paciente, prontuário, vínculo e documentos.
