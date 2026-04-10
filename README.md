repositório do TCC
# 📌 Resumo de Estrutura Front-end: Projeto Connectamente

Este documento resume a arquitetura definida para o sistema, focando em escalabilidade, segurança (RBAC) e organização de rotas aninhadas no React.

**1. Organização de Pastas (Pattern de Páginas)**

A estrutura foi organizada por Papel (Role) e Funcionalidade. Cada grande funcionalidade é uma pasta contendo seus componentes de CRUD.

**Padrão de Nomenclatura:**
- Pastas: PascalCase (ex: GestaoPacientes);
- Arquivo de entrada: index.jsx (sempre minúsculo);
- Componentes de Tela: PascalCase (ex: Criar.jsx, Editar.jsx).

***Exemplo da estrutura de pastas***

```bash
   src/pages/
├── coordenador/
│   ├── DashboardCoordenador.jsx  (Contém o Layout + Outlet)
│   ├── GestaoPacientes/
│   │   ├── index.jsx            (Listagem Geral)
│   │   ├── Criar.jsx
│   │   ├── Editar.jsx
│   │   └── Visualizar.jsx
│   └── GestaoPsicologos/ ...
├── aluno/
│   ├── DashboardAluno.jsx
│   ├── MeusPacientes/ ...
│   └── MinhasConsultas/ ...
├── auth
|   ├── Login.jsx
|   ├── Cadastro.jsx
|   ├── Perfil
|
```


**2. Arquitetura de Rotas (React Router v6+)**

As rotas foram separadas em módulos para evitar um arquivo App.js gigante. Utilizamos Nested Routes (Rotas Aninhadas).

- Rotas Pai: Definem o Layout e a Proteção (PrivateRoute).

- Rotas Filhas: São renderizadas dentro do componente <Outlet /> do Layout, mantendo o menu lateral fixo enquanto o conteúdo central muda.

