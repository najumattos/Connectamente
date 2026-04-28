# Fluxograma - Evolução de Atendimento

## Descrição
Fluxograma do processo de cadastro de `EvolucaoAtendimento` com validação, persistência e revisão do supervisor.

## Fases do Processo

### Fase 1: Entrada do Estagiário
- Inicia evolução
- Seleciona atendimento
- Carrega documento clínico
- Preenche data da evolução
- Digita texto da evolução
- Informa supervisor (opcional)
- Salva evolução

### Fase 2: Validação e Persistência do Sistema
1. **Validação**: Atendimento e documento clínico são válidos?
   - Não → Exibe erro de validação
   - Sim → Continua

2. **Validação**: TextoEvolucao está preenchido?
   - Não → Exibe erro e volta ao preenchimento
   - Sim → Continua

3. **Persistência**:
   - Gera EvolucaoAtendimento
   - Associa DocumentoClinico
   - Associa Atendimento (se houver)
   - Registra CriadoPorUsuarioId
   - Registra SupervisorId (se informado)
   - Persiste na base de dados
   - Exibe sucesso

### Fase 3: Revisão do Supervisor
- Recebe evolução para análise
- Revisa conteúdo clínico
- Aprova evolução
  - Se rejeitado: Solicita ajuste
  - Se aprovado: Aprova para histórico

## Fluxo de Erro
Erros de validação retornam o usuário aos campos de entrada para correção.

## Propósito
Documentar o fluxo de cadastro de evolução de atendimento com foco no processo integrado de cadastro, validação, persistência e supervisão.
