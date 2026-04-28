# Fluxograma - Evolução de Atendimento com Swimlanes

## Descrição
Fluxograma com swimlanes que modela o processo de registro e aprovação de `EvolucaoAtendimento`, separando as ações do estagiário, do sistema e do supervisor.

## Swimlanes (Faixas)
1. **Estagiário** (azul claro):
   - Inicia evolução
   - Seleciona atendimento
   - Preenche texto da evolução
   - Salva como rascunho
   - Submete para supervisão

2. **Sistema** (cinza):
   - Valida dados obrigatórios
   - Salva evolução
   - Envia para supervisor
   - Registra pendência
   - Notifica estagiário

3. **Supervisor** (laranja):
   - Analisa evolução
   - Aprova ou solicita ajuste
   - Aprova evolução

## Fluxo Principal
1. Estagiário inicia processo e preenche dados
2. Sistema valida dados e salva
3. Supervisor recebe para aprovação
4. Supervisor aprova ou solicita ajustes
5. Se ajustes, volta ao estagiário
6. Se aprovado, evolução é finalizada

## Decisões e Caminhos
- **Dados obrigatórios preenchidos?** (Sim/Não)
- **Supervisor aprova?** (Sim/Não)

## Propósito
Visualizar o fluxo de trabalho colaborativo entre estagiário, sistema e supervisor na criação e aprovação de evoluções de atendimento.
