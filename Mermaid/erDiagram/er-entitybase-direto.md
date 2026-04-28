# ER - Tabelas que herdam de EntityBase

## Descrição
Diagrama de Entidade-Relacionamento (ER) que ilustra todas as 11 tabelas que herdam diretamente de `EntityBase`, incluindo a classe base.

## Tabelas incluídas
- **ENTITY_BASE**: Classe abstrata base com campos comuns (Id, DataCriacao, DataAtualizacao, Ativo)
- **PACIENTE**: Dados demográficos do paciente
- **PRONTUARIO**: Registro clínico do paciente
- **TRATAMENTO_ANTERIOR_PACIENTE**: Histórico de tratamentos anteriores
- **RESPONSAVEL_LEGAL**: Dados do responsável legal
- **VINCULO_ALUNO_PACIENTE**: Relacionamento entre aluno e paciente
- **DOCUMENTO_CLINICO**: Documentos do prontuário
- **ATENDIMENTO**: Atendimentos realizados
- **EVOLUCAO_ATENDIMENTO**: Evoluções dos atendimentos
- **ANEXO**: Arquivos anexados aos documentos
- **AUDITORIA**: Registro de ações dos usuários
- **TERMO_RESPONSABILIDADE_ESTAGIARIO**: Termos assinados por estagiários

## Campos principais
O diagrama exibe apenas os campos principais de cada tabela para melhor visualização:
- Chaves primárias (PK)
- Chaves estrangeiras (FK)
- Campos principais identificadores
- Enumerações de status

## Relacionamentos
Os relacionamentos mostram a herança de `EntityBase` e as associações entre as tabelas através de chaves estrangeiras.
