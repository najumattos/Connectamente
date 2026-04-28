# Fluxograma - Cadastro Real de Evolução de Atendimento

## Descrição
Fluxograma detalhado que modela o processo real de cadastro de `EvolucaoAtendimento`, incluindo seleção de atendimento, validação, persistência e aprovação, com swimlanes para estagiário, sistema e supervisor.

## Swimlanes (Faixas)
1. **Estagiário** (azul claro):
   - Acessa módulo de evolução
   - Seleciona atendimento concluído
   - Carrega paciente e documento clínico
   - Preenche texto da evolução
   - Informa conduta e observações
   - Salva como rascunho
   - Submete para supervisão

2. **Sistema** (cinza):
   - Valida atendimento e vínculo
   - Valida campos obrigatórios
   - Gera registro de EvolucaoAtendimento
   - Atribui versão inicial
   - Registra data e usuário criador
   - Salva vínculo com DocumentoClinico e Atendimento
   - Notifica supervisor
   - Registra erros de validação
   - Mantém como rascunho

3. **Supervisor** (laranja):
   - Recebe evolução para análise
   - Revisa texto e coerência clínica
   - Solicita ajustes ou aprova
   - Confirma aprovação
   - Libera para histórico

## Validações
1. **Atendimento e vínculo estão válidos?** (Não → erro; Sim → continua)
2. **Campos obrigatórios preenchidos?** (Não → rascunho; Sim → continua)
3. **Supervisor aprova?** (Não → ajustes; Sim → finalizado)

## Entidades Geradas
- EvolucaoAtendimento
- ResponsavelLegal
- Prontuario
- TermoAutorizacaoMenor

## Propósito
Modelar o fluxo completo e realista de cadastro de evolução de atendimento, desde a seleção do paciente até a aprovação final do supervisor.
