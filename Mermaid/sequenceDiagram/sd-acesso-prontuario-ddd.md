# Diagrama de Sequência: Acesso a Prontuário com Arquitetura DDD

## Descrição

Este diagrama implementa o fluxo completo de acesso a um prontuário de paciente no sistema Connectamente, respeitando a arquitetura em camadas (DDD - Domain-Driven Design) e incluindo validações de segurança, regras de negócio e aprovação por coordenador quando necessário.

## Participantes

| Participante | Camada | Responsabilidade |
|---|---|---|
| **Estagiário** | - | Ator que faz a requisição HTTP |
| **Controller** | HTTP | Recebe requisições, valida token JWT e orquestra a resposta |
| **UseCase** | Application | Orquestra a lógica de aplicação e casos de uso |
| **Domain** | Domain/Business | Implementa regras de negócio e validações |
| **Repository** | Data Access | Acessa e persiste dados no banco de dados |
| **Database** | Persistence | Banco de dados PostgreSQL |
| **Coordenador** | Supervisor | Aprova ou rejeita acesso quando necessário |

## Fluxo Completo

### 1. **Autenticação (Linha 1-3)**
```
Estagiário → Controller: GET /prontuarios/{id} (com token JWT)
↓
Controller valida token JWT
```

**Possível erro:** Token inválido → **HTTP 401 Unauthorized**

### 2. **Validação de Entrada (Linha 4-5)**
```
Controller → UseCase: acessarProntuario(idProntuario, idEstagiario)
↓
UseCase valida entrada
```

**Possível erro:** ID prontuário inválido → **HTTP 404 Not Found**

### 3. **Busca do Prontuário (Linha 6-10)**
```
UseCase → Repository: buscarProntuarioPorId(idProntuario)
↓
Repository → Database: SELECT * FROM prontuarios WHERE id = $1
↓
Database retorna dados do prontuário
```

### 4. **Validação de Regras de Negócio (Linha 11-44)**

A camada Domain aplica 3 regras sequenciais:

#### **Regra 1: Vínculo Ativo**
```
Domain valida: Existe vínculo ativo entre estagiário e paciente?
```
- ✅ Sim → Continua para Regra 2
- ❌ Não → **HTTP 403 Forbidden (sem vínculo)**

#### **Regra 2: Prontuário Ativo**
```
Domain valida: O prontuário está ativo (não arquivado)?
```
- ✅ Sim → Continua para Regra 3
- ❌ Não → **HTTP 403 Forbidden (prontuário arquivado)**

#### **Regra 3: Requer Aprovação?**
```
Domain valida: Este acesso requer aprovação do coordenador?
```
(Baseado em políticas como: acesso de novo estagiário, paciente especial, etc.)

- ✅ Sim → Vai para subprocess de aprovação
- ❌ Não → Continua para registro de acesso

### 5. **Subprocess de Aprovação (Linha 13-32)**

Quando aprovação é necessária:

```
UseCase ↔ Repository: Busca o coordenador responsável do paciente
↓
UseCase → Coordenador: Notifica solicitação de acesso
↓
Coordenador: Revisa e decide
```

**Caminho A - Coordenador Rejeita:**
- Coordenador → UseCase: rejeitarAcesso(motivo)
- Resultado: **HTTP 403 Forbidden (acesso rejeitado)**

**Caminho B - Coordenador Aprova:**
- Coordenador → UseCase: aprovarAcesso()
- UseCase registra acesso e continua

### 6. **Registro de Acesso (Linha 20-28 ou 34-42)**

Quando acesso é permitido:

```
UseCase → Repository: registrarAcessoProntuario(idEstagiario, idProntuario)
↓
Repository → Database: 
  1. INSERT INTO acessos_prontuario (estagiario_id, prontuario_id, data_acesso)
  2. UPDATE prontuarios SET último_acesso = now()
```

### 7. **Resposta Final**

```
Controller: Serializa resposta JSON com dados do prontuário
↓
Controller → Estagiário: HTTP 200 OK {prontuario com dados}
```

## Possíveis Respostas HTTP

| Status | Significado | Causa |
|---|---|---|
| **401** | Unauthorized | Token JWT inválido ou expirado |
| **403** | Forbidden | Sem vínculo ativo, prontuário arquivado, ou acesso rejeitado pelo coordenador |
| **404** | Not Found | ID do prontuário inválido ou não existe |
| **200** | OK | Acesso autorizado com sucesso |

## Caminho de Dados em Banco de Dados

### Tabelas Consultadas:
- `prontuarios` - Busca dados do prontuário
- `vinculos_aluno_paciente` - Valida vínculo ativo
- `pacientes` - Busca coordenador responsável
- `acessos_prontuario` - Registra novo acesso (INSERT)

### Operações:
1. **SELECT** - Busca prontuário, vínculo e coordenador
2. **INSERT** - Registra acesso em `acessos_prontuario`
3. **UPDATE** - Atualiza `último_acesso` em `prontuarios`

## Princípios DDD Implementados

✅ **Separação de Camadas:** Cada participante representa uma camada arquitetural  
✅ **Sem Cruzamento de Limites:** Controller não acessa diretamente Repository  
✅ **Lógica de Negócio Centralizada:** Todas as validações em Domain  
✅ **Persistência Isolada:** Repository como único acesso a dados  
✅ **Orquestração em UseCase:** Define fluxo da aplicação  

## Casos de Uso Demonstrados

1. **Acesso permitido sem aprovação** - Estagiário com vínculo ativo em prontuário comum
2. **Acesso permitido com aprovação** - Novo estagiário precisa de aprovação do coordenador
3. **Acesso negado por sem vínculo** - Estagiário sem vínculo ativo com o paciente
4. **Acesso negado por prontuário arquivado** - Prontuário não está mais ativo
5. **Acesso rejeitado por coordenador** - Coordenador nega a aprovação
6. **Erro de autenticação** - Token JWT inválido
7. **Erro de validação** - ID prontuário inválido

## Auditoria e Logging

O diagrama registra automaticamente:
- `data_acesso` em `acessos_prontuario` (quem acessou)
- `último_acesso` em `prontuarios` (quando foi acessado)

Permitindo rastreabilidade completa de acessos para fins de auditoria.
