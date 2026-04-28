# Fluxograma - Cadastro de Paciente Menor de Idade

## Descrição
Fluxograma que modela o processo de cadastro de um paciente menor de idade, incluindo registro do responsável legal e geração obrigatória de termo de autorização.

## Atores
- **Estagiário/Atendente**: Realiza o cadastro

## Fases do Processo

### Fase 1: Validação de Menoridade
- **Paciente é menor de idade?**
  - Não → Redireciona ao fluxo de cadastro regular
  - Sim → Continua

### Fase 2: Entrada de Dados do Menor
- Preenche dados do paciente menor:
  - Nome completo
  - Data de nascimento
  - Documentação (RG, CPF)
  - Contatos e endereço
  - Dados complementares

### Fase 3: Entrada de Dados do Responsável Legal
- Preenche dados do responsável principal:
  - Nome completo
  - CPF/RG
  - Grau de parentesco
  - Telefone, email, endereço

### Fase 4: Autorização
- Anexa ou registra autorização/termo de consentimento

### Fase 5: Validação do Sistema
1. **Campos do menor preenchidos?**
   - Não → Erro e volta ao passo 2
   - Sim → Continua

2. **Responsável legal válido?**
   - Não → Erro e volta ao passo 3
   - Sim → Continua

3. **Autorização anexada?**
   - Não → Erro e volta ao passo 4
   - Sim → Continua

### Fase 6: Persistência
- Gera registro de Paciente
- Gera registro de ResponsavelLegal
- Gera registro de Prontuario
- Gera registro de TermoAutorizacaoMenor
- Persiste cadastro
- Exibe sucesso

## Validações Obrigatórias
- Confirmação de menoridade
- Dados completos do menor
- Dados válidos do responsável
- Anexação/registro de termo de autorização

## Tabelas Criadas
- Paciente
- ResponsavelLegal
- Prontuario
- TermoAutorizacaoMenor

## Propósito
Modelar o fluxo de cadastro de paciente menor de idade, garantindo a conformidade com requisitos legais e a presença de responsável e autorização documentada.
