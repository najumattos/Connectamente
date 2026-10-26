points

# Connectamente 🧠

Sistema web para **gestão de prontuários e atendimentos em clínicas-escola de Psicologia**.

O Connectamente foi desenvolvido como projeto acadêmico com o objetivo de digitalizar processos relacionados ao acompanhamento de pacientes, organização de prontuários e registro de atendimentos, substituindo processos manuais por uma aplicação centralizada.

Além da implementação das funcionalidades do sistema, o projeto também foi utilizado como espaço de estudo e aplicação prática de conceitos de **arquitetura de software, APIs REST, autenticação, persistência de dados, testes automatizados e organização de código**.

---

## 📌 Sobre o projeto

Clínicas-escola possuem diferentes informações relacionadas ao paciente e ao acompanhamento psicológico, como:

* dados de identificação;
* prontuários;
* atendimentos;
* documentos clínicos;
* tratamentos anteriores;
* familiares;
* psicólogos responsáveis;
* vínculos entre psicólogos e prontuários;
* histórico de alterações.

O Connectamente busca centralizar essas informações em uma aplicação web, organizando o acesso aos dados de acordo com os diferentes usuários do sistema.

---

## 🏗️ Arquitetura

O backend foi organizado seguindo uma separação de responsabilidades baseada em camadas:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Entity Framework Core
    ↓
MySQL
```

### Principais responsabilidades

**Controllers**

Responsáveis por receber as requisições HTTP, validar a entrada básica e direcionar a operação para os serviços correspondentes.

**Services**

Concentram as regras de negócio e coordenam as operações realizadas pela aplicação.

**Repositories**

Responsáveis pelo acesso e persistência dos dados.

**DTOs**

Definem os dados que entram e saem da API, evitando o acoplamento direto entre as entidades do domínio e os contratos da API.

**Data**

Contém o `DbContext`, configurações das entidades, auditoria, seeds e demais componentes relacionados à persistência.

---

## 🔐 Autenticação

A API utiliza **ASP.NET Core Identity** para gerenciamento de usuários e **JWT (JSON Web Token)** para autenticação baseada em tokens.

O fluxo principal é:

```text
Usuário
   │
   │ credenciais
   ▼
POST /api/auth/login
   │
   ▼
AuthService
   │
   ├── valida usuário
   └── gera JWT
          │
          ▼
       Access Token
          │
          ▼
Requisições autenticadas
```

O token contém informações do usuário, como:

* identificador;
* e-mail;
* informações necessárias para autenticação da requisição.

A aplicação também possui estrutura para utilização de **roles**, permitindo a evolução do sistema para diferentes níveis de acesso.

---

## 🧾 Auditoria

Uma das funcionalidades implementadas no backend é o registro de alterações realizadas no banco de dados.

A aplicação intercepta as operações de persistência realizadas pelo `DbContext` para registrar informações como:

* usuário responsável pela alteração;
* entidade afetada;
* operação realizada;
* valores anteriores;
* novos valores;
* data da alteração.

Essa abordagem permite manter um histórico das alterações realizadas sobre os dados do sistema.

---

## 📚 Endpoints

### AuthController

| Endpoint                 | Função                                            | Autorização        |
| ------------------------ | --------------------------------------------------- | -------------------- |
| `POST /api/auth/login` | Autenticar usuário e emitir token JWT.             | Público             |
| `GET /api/auth/me`     | Retornar informações básicas do usuário logado. | Usuário autenticado |

### ApplicationUserController

| Endpoint                               | Função                                                                        | Autorização                 |
| -------------------------------------- | ------------------------------------------------------------------------------- | ----------------------------- |
| `GET /api/usuarios`                  | Listar usuários.                                                               | Professor, Secretaria (ADMIN) |
| `GET /api/usuarios/arquivados`       | Listar usuários inativos ou arquivados.                                        | Professor, Secretaria (ADMIN) |
| `GET /api/usuarios/{id}`             | Buscar usuário por ID.                                                         | Professor, Secretaria (ADMIN) |
| `POST /api/usuarios`                 | Cadastrar usuário.                                                             | Professor, Secretaria (ADMIN) |
| `PUT /api/usuarios/{id}`             | Atualizar dados do usuário, respeitando os campos permitidos para cada perfil. | Professor, Secretaria (ADMIN) |
| `PATCH /api/usuarios/{id}/arquivar`  | Desativar ou arquivar usuário, sem exclusão física.                          | Professor                     |
| `PATCH /api/usuarios/{id}/restaurar` | Reativar usuário arquivado.                                                    | Professor                     |

### AtendimentoController

| Endpoint                                   | Função                                                            | Autorização              | Observação                                           |
| ------------------------------------------ | ------------------------------------------------------------------- | -------------------------- | ------------------------------------------------------ |
| `GET /api/atendimentos`                  | Listar atendimentos dentro do escopo autorizado.                    | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/atendimentos/{id}`             | Buscar atendimento por ID, validando o acesso do aluno ao paciente. | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `POST /api/atendimentos`                 | Registrar atendimento.                                              | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PUT /api/atendimentos/{id}`             | Atualizar atendimento.                                              | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/atendimentos/arquivados`       | Listar atendimentos arquivados.                                     | Professor                  |                                                        |
| `PATCH /api/atendimentos/{id}/arquivar`  | Arquivar atendimento.                                               | Professor                  |                                                        |
| `PATCH /api/atendimentos/{id}/restaurar` | Restaurar atendimento arquivado.                                    | Professor                  |                                                        |

### AgendamentoController

| Endpoint                                   | Função                         | Autorização                 | Observação                                           |
| ------------------------------------------ | -------------------------------- | ----------------------------- | ------------------------------------------------------ |
| `GET /api/agendamentos`                  | Listar todos agendamentos        | Professor, Secretaria, Aluno  | Aluno só tem acesso aos agendamentos vinculados a ele |
| `GET /api/agendamentos/{id}`             | Buscar agendamento por ID        | Professor, Secretaria, Aluno  | Aluno só tem acesso aos agendamentos vinculados a ele |
| `GET /api/agendamentos/arquivados`       | Listar agendamentos arquivados.  | Professor, Secretaria (ADMIN) |                                                        |
| `POST /api/agendamentos`                 | Criar agendamento.               | Professor, Secretaria (ADMIN) |                                                        |
| `PUT /api/agendamentos/{id}`             | Atualizar agendamento.           | Professor, Secretaria (ADMIN) |                                                        |
| `PATCH /api/agendamentos/{id}/arquivar`  | Arquivar agendamento.            | Professor, Secretaria (ADMIN) |                                                        |
| `PATCH /api/agendamentos/{id}/restaurar` | Restaurar agendamento arquivado. | Professor, Secretaria (ADMIN) |                                                        |

### DocumentoClinicoController

| Endpoint                                                   | Função                                   | Autorização              | Observação                                           |
| ---------------------------------------------------------- | ------------------------------------------ | -------------------------- | ------------------------------------------------------ |
| `GET /api/documentos-clinicos`                           | Listar documentos clínicos                | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/documentos-clinicos/{id}`                      | Buscar documento por ID                    | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/documentos-clinicos/por-paciente/{pacienteId}` | Listar documentos clínicos de um paciente | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `POST /api/documentos-clinicos`                          | Criar documento clínico                   | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PUT /api/documentos-clinicos/{id}`                      | Atualizar documento                        | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PATCH /api/documentos-clinicos/{id}/arquivar`           | Arquivar documento clínico.               | Professor                  |                                                        |
| `PATCH /api/documentos-clinicos/{id}/restaurar`          | Restaurar documento clínico arquivado.    | Professor                  |                                                        |
| `GET /api/documentos-clinicos/arquivados`                | Listar documentos clínicos arquivados.    | Professor                  |                                                        |

### FamiliarController

| Endpoint                                 | Função                      | Autorização                 | Observação                                           |
| ---------------------------------------- | ----------------------------- | ----------------------------- | ------------------------------------------------------ |
| `GET /api/familiares`                  | Listar familiares             | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/familiares/{id}`             | Buscar familiar por ID        | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `POST /api/familiares`                 | Cadastrar familiar            | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PUT /api/familiares/{id}`             | Atualizar dados do familiar   | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/familiares/arquivados`       | Listar familiares arquivados. | Professor, Secretaria (ADMIN) |                                                        |
| `PATCH /api/familiares/{id}/arquivar`  | Arquivar familiar.            | Professor                     |                                                        |
| `PATCH /api/familiares/{id}/restaurar` | Restaurar familiar arquivado. | Professor                     |                                                        |

### PacienteController

| Endpoint                                | Função                      | Autorização                 | Observação                                           |
| --------------------------------------- | ----------------------------- | ----------------------------- | ------------------------------------------------------ |
| `GET /api/pacientes`                  | Listar pacientes;             | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/pacientes/{id}`             | Buscar paciente por ID        | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PUT /api/pacientes/{id}`             | Atualizar dados do paciente.  | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `POST /api/pacientes`                 | Cadastrar paciente.           | Professor, Secretaria (ADMIN) |                                                        |
| `PATCH /api/pacientes/{id}/arquivar`  | Arquivar paciente.            | Professor                     |                                                        |
| `PATCH /api/pacientes/{id}/restaurar` | Restaurar paciente arquivado. | Professor                     |                                                        |
| `GET /api/pacientes/arquivados`       | Listar pacientes arquivados.  | Professor                     |                                                        |

### ProntuarioController

| Endpoint                                          | Função                                              | Autorização              | Observação                                           |
| ------------------------------------------------- | ----------------------------------------------------- | -------------------------- | ------------------------------------------------------ |
| `GET /api/prontuarios`                          | Listar prontuários                                   | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/prontuarios/{id}`                     | Buscar prontuário por ID                             | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `POST /api/prontuarios/por-plantao/{plantaoId}` | Criar prontuário a partir de um plantão autorizado. | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PUT /api/prontuarios/{id}`                     | Atualizar prontuário                                 | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PATCH /api/prontuarios/{id}/arquivar`          | Arquivar prontuário.                                 | Professor                  |                                                        |
| `PATCH /api/prontuarios/{id}/restaurar`         | Restaurar prontuário arquivado.                      | Professor                  |                                                        |
| `GET /api/prontuarios/arquivados`               | Listar prontuários arquivados.                       | Professor                  |                                                        |

### TratamentoAnteriorController

| Endpoint                                             | Função                                  | Autorização              | Observação                                           |
| ---------------------------------------------------- | ----------------------------------------- | -------------------------- | ------------------------------------------------------ |
| `GET /api/tratamentos-anteriores`                  | Listar tratamentos anteriores             | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/tratamentos-anteriores/{id}`             | Buscar tratamento anterior por ID.        | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `POST /api/tratamentos-anteriores`                 | Registrar tratamento anterior             | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PUT /api/tratamentos-anteriores/{id}`             | Atualizar tratamento anterior             | Professor, Aluno (CLINICO) | Aluno só tem acesso aos atendimentos vinculados a ele |
| `PATCH /api/tratamentos-anteriores/{id}/arquivar`  | Arquivar tratamento anterior.             | Professor                  |                                                        |
| `PATCH /api/tratamentos-anteriores/{id}/restaurar` | Restaurar tratamento anterior arquivado.  | Professor                  |                                                        |
| `GET /api/tratamentos-anteriores/arquivados`       | Listar tratamentos anteriores arquivados. | Professor                  |                                                        |

### VinculoPacientePsicologoController

| Endpoint                                                 | Função                                      | Autorização                 | Observação                                           |
| -------------------------------------------------------- | --------------------------------------------- | ----------------------------- | ------------------------------------------------------ |
| `GET /api/vinculos-paciente-psicologo`                 | Listar vínculos                              | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `GET /api/vinculos-paciente-psicologo/{id}`            | Buscar vínculo por ID                        | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele |
| `POST /api/vinculos-paciente-psicologo`                | Criar vínculo entre paciente e profissional. | Professor, Secretaria (ADMIN) |                                                        |
| `PUT /api/vinculos-paciente-psicologo/{id}`            | Atualizar dados permitidos do vínculo.       | Professor, Secretaria (ADMIN) |                                                        |
| `PATCH /api/vinculos-paciente-psicologo/{id}/encerrar` | Encerrar vínculo.                            | Professor, Secretaria (ADMIN) |                                                        |
| `PATCH /api/vinculos-paciente-psicologo/{id}/revogar`  | Revogar vínculo.                             | Professor, Secretaria (ADMIN) |                                                        |

### PlantaoController

| Endpoint                               | Função                      | Autorização                 | Observação                                                                                                                 |
| -------------------------------------- | ----------------------------- | ----------------------------- | ---------------------------------------------------------------------------------------------------------------------------- |
| `GET /api/plantoes`                  | Listar plantões              | Professor, Secretaria, Aluno  | Aluno só tem acesso aos atendimentos vinculados a ele                                                                       |
| `GET /api/plantoes/{id}`             | Buscar plantão por ID        | Professor, Secretaria, Aluno  | `sem expor o conteúdo do relatório clínico à Secretaria.` e `Aluno só tem acesso aos atendimentos vinculados a ele` |
| `PUT /api/plantoes/{id}`             | Atualizar dados do plantão   | Professor, Secretaria, Aluno  | `sem expor o conteúdo do relatório clínico à Secretaria.` e `Aluno só tem acesso aos atendimentos vinculados a ele` |
| `GET /api/plantoes/arquivados`       | Listar plantões arquivados.  | Professor, Secretaria (ADMIN) |                                                                                                                              |
| `POST /api/plantoes`                 | Criar plantão                | Professor, Secretaria (ADMIN) |                                                                                                                              |
| `PATCH /api/plantoes/{id}/arquivar`  | Arquivar plantão.            | Professor, Secretaria (ADMIN) |                                                                                                                              |
| `PATCH /api/plantoes/{id}/restaurar` | Restaurar plantão arquivado. | Professor, Secretaria (ADMIN) |                                                                                                                              |

### AuditoriaController (PROFESSOR)

| Endpoint                                        | Função                                                     |
| ----------------------------------------------- | ------------------------------------------------------------ |
| `GET /api/auditorias`                         | Listar registros de auditoria.                               |
| `GET /api/auditorias/{id}`                    | Buscar registro de auditoria por ID.                         |
| `GET /api/auditorias/por-usuario/{usuarioId}` | Consultar registros de auditoria relacionados a um usuário. |
| `GET /api/auditorias/por-entidade`            | Consultar registros de auditoria por entidade.               |


---

## 🛠️ Tecnologias

### Backend

* **C#**
* **.NET 9**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **ASP.NET Core Identity**
* **JWT Bearer Authentication**
* **MySQL**
* **AutoMapper**
* **FluentResults**
* **Swagger / OpenAPI**

### Frontend

* **React**
* **JavaScript**
* **React Router**
* **Axios**
* **Vite**

### Desenvolvimento

* **Git**
* **GitHub**
* **GitHub Actions**
* **Swagger**
* **Entity Framework Core Migrations**

---

## 🗂️ Estrutura do backend

```text
Connectamente.API/
│
├── Controllers/
│
├── DTOs/
│   ├── AtendimentoDto/
│   ├── AuthDto/
│   ├── DocumentoClinicoDto/
│   ├── FamiliarDto/
│   ├── PacienteDto/
│   ├── ProntuarioDto/
│   ├── PsicologoDto/
│   └── TratamentoAnteriorDto/
│
├── Data/
│   ├── Configurations/
│   ├── Seeds/
│   ├── AppDbContext.cs
│   └── AuditEntry.cs
│
├── Domain/
│   ├── Mapper/
│   ├── Services/
│   └── ...
│
├── Models/
│
├── Repositories/
│
├── Services/
│
├── Tests/
│
└── Program.cs
```

A organização busca manter responsabilidades separadas e facilitar a evolução do sistema.

---

## 🗃️ Banco de dados

A persistência é realizada utilizando **Entity Framework Core**.

As entidades possuem configurações próprias para definir:

* relacionamentos;
* chaves;
* índices;
* restrições;
* propriedades;
* comportamento das relações.

As alterações no modelo são controladas por meio de **EF Core Migrations**.

---

## 🧪 Testes

O projeto possui testes automatizados, incluindo testes relacionados ao processo de autenticação e geração de tokens JWT.

Entre os cenários testados estão:

* autenticação bem-sucedida;
* geração do token;
* claims;
* issuer;
* audience;
* assinatura;
* configuração da chave JWT;
* situações de configuração inválida.

Os testes fazem parte do processo de desenvolvimento e servem também como ferramenta de validação das decisões implementadas.

---

## 🔄 Frontend

A interface utiliza uma organização baseada em páginas e funcionalidades.

As rotas são estruturadas utilizando **Nested Routes**, permitindo que layouts específicos sejam reutilizados entre diferentes páginas.

Exemplo:

```text
Dashboard
│
├── Gestão de Pacientes
│   ├── Listagem
│   ├── Cadastro
│   ├── Edição
│   └── Visualização
│
├── Gestão de Psicólogos
│
└── ...
```

A comunicação com a API é realizada utilizando **Axios**, incluindo o envio do JWT nas requisições autenticadas.

---

## ⚙️ Configuração

### Pré-requisitos

* [.NET 9 SDK]
* [Node.js]
* MySQL
* Git

### Backend

Clone o repositório e entre na pasta da API:

```bash
cd Connectamente.API
```

Configure as variáveis de ambiente necessárias em um arquivo `.env`.

Exemplo:

```env
DB_CONNECTION_STRING=sua_string_de_conexao

JWT_KEY=sua_chave_secreta
JWT_EXPIRATION_MINUTES=60
```

Depois, restaure as dependências:

```bash
dotnet restore
```

Execute as migrations:

```bash
dotnet ef database update
```

Inicie a API:

```bash
dotnet watch run
```

A documentação da API pode ser acessada através do Swagger quando a aplicação estiver em execução.

---

### Frontend

Entre na pasta da interface:

```bash
cd Connectamente.Interface
```

Instale as dependências:

```bash
npm install
```

Execute o projeto:

```bash
npm run dev
```

---

## 🔒 Variáveis de ambiente

Informações sensíveis não devem ser versionadas no Git.

O projeto utiliza `.env` para configurações como:

```text
DB_CONNECTION_STRING
JWT_KEY
JWT_EXPIRATION_MINUTES
```

O arquivo `.env` deve permanecer fora do controle de versão.

---

## 📐 Objetivos técnicos

O projeto também foi utilizado para estudar e aplicar conceitos de:

* Programação Orientada a Objetos;
* SOLID;
* Clean Code;
* separação de responsabilidades;
* arquitetura em camadas;
* Repository Pattern;
* Dependency Injection;
* DTOs;
* autenticação e autorização;
* JWT;
* ASP.NET Core Identity;
* Entity Framework Core;
* migrations;
* auditoria de dados;
* testes automatizados;
* documentação de APIs;
* Git e integração contínua.

---

## 📖 Documentação e referências do domínio

O repositório contém documentos utilizados durante a análise e modelagem do domínio da clínica-escola, incluindo:

* modelos de documentos utilizados no atendimento;
* contratos;
* formulários;
* documentos de identificação;
* modelos de anamnese;
* documentação da modelagem;
* diagramas de relacionamento;
* diagramas de sequência;
* scripts relacionados ao banco de dados.

Esses materiais foram utilizados como referência para transformar processos e documentos do domínio em entidades e estruturas da aplicação.

---

## 🚧 Status

O projeto encontra-se em desenvolvimento.

Algumas funcionalidades e aspectos da arquitetura continuam sendo aprimorados, especialmente relacionados a:

* autenticação e autorização;
* integração completa entre frontend e backend;
* cobertura de testes;
* refinamento das regras de negócio;
* experiência de usuário.

---

## 👩‍💻 Desenvolvimento

Projeto desenvolvido como trabalho acadêmico e também como projeto de estudo em desenvolvimento de software, com foco principalmente em **backend, APIs REST, arquitetura e persistência de dados**.

O desenvolvimento envolve não apenas a implementação das funcionalidades, mas também o estudo das decisões técnicas utilizadas para construí-las.
