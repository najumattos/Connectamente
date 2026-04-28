# Fluxograma - Vínculo Aluno-Paciente

## Descrição
Fluxograma que modela o processo de criação de vínculo entre aluno estagiário e paciente, incluindo validações de elegibilidade e alteração de permissões.

## Atores
- **Estagiário/Supervisor**: Cria o vínculo

## Fases do Processo

### Fase 1: Seleção e Acesso
- Acessa módulo de vínculos
- Seleciona paciente
- Seleciona aluno estagiário
- Informa motivo da liberação
- Define permissões:
  - Permissão de leitura (padrão: true)
  - Permissão de escrita (padrão: true)
- Salva vínculo

### Fase 2: Validação do Sistema
1. **Paciente existe e está ativo?**
   - Não → Erro de validação e volta à seleção de paciente
   - Sim → Continua

2. **Aluno existe e está ativo?**
   - Não → Erro de validação e volta à seleção de aluno
   - Sim → Continua

3. **Já existe vínculo ativo?**
   - Sim → Erro de validação e volta à seleção de aluno
   - Não → Continua

### Fase 3: Persistência
- Gera registro de VinculoAlunoPaciente
- Registra DataLiberacao (data/hora atual)
- Salva LiberadoPorUsuarioId (usuário que está criando o vínculo)
- Persiste status Ativo
- Exibe sucesso

### Fase 4: Associações Opcionais
- Pode revogar vínculo anterior, se necessário
- Atualiza tabela ApplicationUser (se aplicável)

## Validações Principais
- Paciente ativo
- Aluno ativo
- Vínculo único (não duplicado)

## Campos Registrados
- PacienteId
- AlunoId
- LiberadoPorUsuarioId
- DataLiberacao
- StatusVinculo (Ativo)
- PermiteLeitura
- PermiteEscrita

## Possível Revogação
- RevogadoPorUsuarioId (quando revogado)
- DataRevogacao (quando revogado)
- StatusVinculo (muda para Revogado)

## Propósito
Modelar o fluxo de criação de vínculo entre aluno e paciente, garantindo apenas alunos ativos possam ser vinculados a pacientes ativos, e que não haja duplicação de vínculos.
