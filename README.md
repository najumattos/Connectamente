
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

## 📚 Principais funcionalidades

### Pacientes

* cadastro;
* edição;
* consulta;
* visualização de informações;
* associação ao prontuário.

### Prontuários

* criação;
* edição;
* consulta;
* visualização de detalhes;
* arquivamento;
* associação com psicólogos.

### Atendimentos

* registro de atendimentos;
* atualização;
* consulta;
* acompanhamento do histórico.

### Documentos clínicos

* cadastro;
* consulta;
* associação ao prontuário.

### Tratamentos anteriores

* registro;
* consulta;
* associação ao paciente.

### Familiares

* cadastro;
* consulta;
* vínculo com pacientes.

### Psicólogos

* cadastro e consulta;
* gerenciamento de vínculos com prontuários.

### Autenticação

* login;
* validação de credenciais;
* geração de JWT;
* autenticação das requisições.

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
