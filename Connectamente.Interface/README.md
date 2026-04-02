# Website pra gerenciar prontuários dos pacientes da clínica-escola da Gran-Tietê

O que sabemos?
- Os alunos de psicologia do último ano prestam atendimentos clínicos sob supervisão;
- Os alunos não podem ter acesso a esse site sem supervisão;
- Existem no minimo DOIS prontuario.tipoProntuario (prontuario.Infantil e prontuario.Adulto);
- Existem DOIS usuario.tipoUsuario (usuario.estudantePsicologia, usuario.coordenador)

## 🛠️ Funcionalidades

A tab Home de ambos pode ser uma lista com todos os agendamentos do dia

1. **O que os estudantes podem fazer?** *tudo Supervisionado*

    **tab Prontuários**
   ```bash
        // VISUALIZAR LISTA de seus prontuários
   GET: BuscarTodosProntuariosEstudante(string idEstudante); 
   
        // VER DETALHES de um prontuario.Adulto
   GET: VisualizarProntuarioAdulto(string idProntuarioAdulto)
   
        // VER DETALHES de um prontuario.Infantil
   GET: VisualizarProntuarioInfantil(string idProntuarioInfantil)
   
        //ATUALIZAR um prontuario.Adulto
   PUT: AtualizarProntuarioAdulto(ProntuarioAdultoUpdateDto, string idprontuarioAdulto, string idUsuarioQueAtualizou)

        //ATUALIZAR um prontuario.Infantil
   PUT: AtualizarProntuarioInfantil(ProntuarioInfantilUpdateDto, string idprontuarioInfantil, string idUsuarioQueAtualizou)

        //CRIAR um prontuario.Adulto
   POST: CriarProntuarioAdulto(ProntuarioAdultoDto, string idUsuarioQueAtualizou)
    
         //CRIAR um prontuario.Infantil
   POST: CriarProntuarioInfantil(ProntuarioInfantilDto, string idUsuarioQueAtualizou)

   //estudante nao pode arquivar nada e tudo que ele editar/criar tem registrado "usuarioQueAtualizou", "dataHoraAtualizacao"
    ```

    **tab Pacientes**
   ```bash
        // VISUALIZAR LISTA de SEUS pacientes
   GET: BuscarTodosPacientes(string idEstudante);
    
        // VISUALIZAR DETALHES do paciente
   GET: VisualizarDadosPaciente(string idEstudanteResponsavel, string idPaciente);

        //EDITAR DETALHES do paciente
   PUT: AtualizarInformacoesPaciente(PacienteUpdateDto, idPaciente, string idQuemTaEditando)

        //ADICIONAR novo paciente
   POST: RegistrarPaciente(RegistroPacienteDto, idPaciente, idEstudanteResponsavel, string idQuemTaRegistrando)

   //estudante nao pode arquivar nada
   ```

     **tab Perfil**
     Tabela Usuarios e Tabela EstudantePsicologia
   ```bash
        //VISUALIZAR DETALHES do perfil Usuario + dadosDeEstudante
   GET: VisualizarPerfil(string idUsuario);

        //EDITAR DETALHES do perfil
   PUT: AtualizarInformacoesUsuario(UsuarioUpdateDto, string idUsuario, string idQuemTaEditando)
   PUT: AtualizarInformacoesEstudante(EstudanteUpdateDto, string idEstudantePsicologia, string idQuemTaEditando)

   //estudante nao pode se registrar
   ```

2. **O que os coordenadores podem fazer além disso?** *(Renata)*
   
   **tab Prontuários**
   ```bash
   //VISUALIZAR LISTA de todos os prontuarios de todos estudantes de psicologia
   GET: BuscarTodosProntuariosEstudantes(int usuario.coordenador); 

   //ARQUIVAR todos prontuarios
   PATCH:ArquivarProntuario(int tipoProntuario, string idProntuario); 
   ````
     **tab Pacientes**
   ```bash
        // VISUALIZAR LISTA de TODOS pacientes de psicologia
   GET: BuscarTodosPacientes();          
   ```
   **tab Alunos**
   ```bash
        // VISUALIZAR LISTA de TODOS estudantes de psicologia
   GET: BuscarTodosEstudantesPsicologia();  

        // ADICIONAR novo estudante de psicologia
   POST: AdicionarEstudantesPsicologia();       

         // ARQUIVAR novo estudante de psicologia
   PATCH: ArquivarEstudantePsicologia(string idEstudantePsicologia);       
   ```
      **tab Perfil**      Tabela Usuarios e (N EXISTE AINDA Tabela CoordenadorPsicologia)
    ```bash
        //VISUALIZAR DETALHES do perfil Usuario + dadosDeCoordenador
   GET: VisualizarPerfil(string idUsuario);

        //EDITAR DETALHES do perfil
   PUT: AtualizarInformacoesUsuario(UsuarioUpdateDto, string idUsuario, string idQuemTaEditando)
   PUT: AtualizarInformacoesCoordenador(CoordenadorUpdateDto, string idCoordenadorPsicologia)

        //Arquivar Perfil
   PATCH: ArquivarPerfil(string idCoordenadorPsicologia)

        //ADICIONAR NOVO COORDENADOR
   PUT: AdicionarCoordenador(RegistroCoordenadorDto, string idQuemTaAdicionando)
   ```

   Ainda tem a parte das consultas mas vamos com calma

