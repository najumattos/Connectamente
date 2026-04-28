# Caso de Uso - Acesso aos Módulos por Permissão

## Descrição
Diagrama de caso de uso UML que ilustra como os diferentes perfis de usuários (Estagiário, Supervisor, Administrador) acessam os módulos do sistema de acordo com suas permissões.

## Atores
- **Estagiário** (azul claro): Acesso básico aos módulos de operação
- **Supervisor** (laranja): Acesso expandido com supervisão e relatórios
- **Administrador** (roxo): Acesso completo ao sistema

## Casos de Uso

### Casos Comuns (Todos os Atores)
- **Autenticar usuário**: Login no sistema
- **Acessar painel inicial**: Dashboard com informações gerais

### Módulos de Operação (Estagiário, Supervisor, Administrador)
- **Acessar módulo de Pacientes**: Gestão de dados de pacientes
- **Acessar módulo de Prontuários**: Visualizar e gerenciar prontuários
- **Acessar módulo de Documentos Clínicos**: Criar e editar documentos
- **Acessar módulo de Vínculos**: Vincular alunos a pacientes
- **Acessar módulo de Atendimentos**: Registrar atendimentos
- **Acessar módulo de Evoluções**: Registrar evoluções de atendimento
- **Acessar módulo de Anexos**: Upload e gerenciamento de arquivos

### Módulos Restritos
- **Acessar módulo Administrativo** (somente Administrador):
  - Gestão de usuários
  - Configuração do sistema
  - Gerenciamento de permissões

- **Acessar relatórios e auditoria** (Supervisor e Administrador):
  - Relatórios clínicos
  - Logs de auditoria
  - Estatísticas do sistema

### Casos de Negação
- **Negar acesso**: Quando usuário não possui permissão
- **Liberar acesso ao módulo**: Validação de permissões após autenticação

## Fluxo de Autenticação e Autorização
1. Usuário autentica-se
2. Sistema valida permissões
3. Se autorizado → Libera acesso ao módulo
4. Se não autorizado → Nega acesso e exibe mensagem

## Permissões por Perfil

| Módulo | Estagiário | Supervisor | Administrador |
|--------|-----------|-----------|--------------|
| Painel Inicial | ✓ | ✓ | ✓ |
| Pacientes | ✓ | ✓ | ✓ |
| Prontuários | ✓ | ✓ | ✓ |
| Documentos Clínicos | ✓ | ✓ | ✓ |
| Vínculos | ✓ | ✓ | ✓ |
| Atendimentos | ✓ | ✓ | ✓ |
| Evoluções | ✓ | ✓ | ✓ |
| Anexos | ✓ | ✓ | ✓ |
| Relatórios/Auditoria | ✗ | ✓ | ✓ |
| Administrativo | ✗ | ✗ | ✓ |

## Propósito
Modelar o sistema de controle de acesso baseado em papéis (RBAC), garantindo que cada usuário tenha acesso apenas aos módulos para os quais está autorizado.
