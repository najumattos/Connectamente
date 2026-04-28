# ER - ApplicationUser e Relacionamentos

## Descrição
Diagrama de Entidade-Relacionamento (ER) que ilustra `ApplicationUser` e todas as suas linhas de relacionamento com outras tabelas do sistema, incluindo as tabelas do ASP.NET Core Identity.

## Tabelas de Identity (ASP.NET Core)
- **IDENTITY_USER**: Usuário base do Identity
- **IDENTITY_ROLE**: Funções/Papéis do sistema
- **IDENTITY_USER_ROLE**: Associação entre usuários e funções
- **IDENTITY_USER_CLAIM**: Claims de segurança do usuário
- **IDENTITY_USER_LOGIN**: Logins externos (OAuth, etc.)
- **IDENTITY_USER_TOKEN**: Tokens de autenticação
- **IDENTITY_ROLE_CLAIM**: Claims das funções

## Tabela ApplicationUser
- **APPLICATION_USER**: Estende `IdentityUser` com dados adicionais (nomeCompleto, cpf, matricula, crp, tipoUsuario, ativo)

## Relacionamentos de ApplicationUser
- **VINCULO_ALUNO_PACIENTE**: Como aluno, liberador e revogador
- **ATENDIMENTO**: Como aluno que atende e como supervisor
- **DOCUMENTO_CLINICO**: Como criador e supervisor
- **EVOLUCAO_ATENDIMENTO**: Como criador e supervisor
- **TERMO_RESPONSABILIDADE_ESTAGIARIO**: Como estagiário que assina
- **ANEXO**: Como usuário que envia arquivos
- **AUDITORIA**: Como usuário que gera auditorias
- **TERMO_COMPROMISSO_INFORMATIZACAO**: Como estagiário

## Propósito
Visualizar como o usuário do sistema se integra com toda a infraestrutura de segurança do ASP.NET Core e como possui múltiplos papéis e responsabilidades no sistema.
