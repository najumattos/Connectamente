# Caso de Uso - Evolução de Atendimento

## Descrição
Diagrama de caso de uso UML que ilustra os casos de uso relativos a `EvolucaoAtendimento`, exibindo os atores e as ações que podem realizar.

## Atores
- **Estagiário** (azul): Ator principal, realiza as operações de cadastro e edição
- **Supervisor** (laranja): Revisa, aprova e valida as evoluções
- **Paciente** (cinza): Fornece dados contextuais para os atendimentos

## Casos de Uso (8 total)
1. **Registrar Evolução de Atendimento**: Estagiário registra nova evolução
2. **Visualizar Evolução de Atendimento**: Estagiário acessa evoluções registradas
3. **Editar Evolução de Atendimento**: Estagiário modifica evolução já registrada
4. **Consultar Histórico de Evoluções**: Estagiário consulta todas as evoluções anteriores
5. **Gerar Relatório de Evolução**: Estagiário gera relatório com evoluções
6. **Submeter Evolução para Aprovação**: Estagiário envia evolução para aprovação
7. **Excluir Evolução**: Estagiário solicita exclusão de evolução
8. **Visualizar Feedback do Supervisor**: Estagiário recebe feedback na supervisão

## Dados Referenciados
- Documento Clínico
- Atendimento
- Base de Dados

## Propósito
Modelar o workflow de evolução de atendimento e identificar as interações entre estagiário, supervisor e o sistema.
Atores:

Estagiário (azul) - Ator principal, realiza as ações
Supervisor (laranja) - Aprova/rejeita, revisa e valida
Paciente (cinza) - Fornece dados para os atendimentos
Dados referenciados:

Documento Clínico e Atendimento (entidades relacionadas)
Base de Dados (armazenamento)