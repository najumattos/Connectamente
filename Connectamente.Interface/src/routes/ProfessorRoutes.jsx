import { Route } from "react-router-dom";
import DashboardProfessor from "../pages/Professor/DashboardProfessor";
import CriarPaciente from "../pages/Professor/GestaoPacientes/Criar"
import EditarPaciente from "../pages/Professor/GestaoPacientes/Editar"
import VisualizarPaciente from "../pages/Professor/GestaoPacientes/Visualizar"
import PacientesArquivados from "../pages/Professor/GestaoPacientes/Arquivados"
import CriarPsicologo from "../pages/Professor/GestaoPsicologos/Criar"
import EditarPsicologo from "../pages/Professor/GestaoPsicologos/Editar"
import VisualizarPsicologo from "../pages/Professor/GestaoPsicologos/Visualizar"
import PsicologosDesativados from "../pages/Professor/GestaoPsicologos/Desativados"
import CriarConsulta from "../pages/Professor/GestaoConsultas/Criar"
import EditarConsulta from "../pages/Professor/GestaoConsultas/Editar"
import VisualizarConsulta from "../pages/Professor/GestaoConsultas/Visualizar"
import ConsultasArquivadas from "../pages/Professor/GestaoConsultas/Arquivados"
import CriarProntuario from "../pages/Professor/GestaoProntuarios/Criar"
import EditarProntuario from "../pages/Professor/GestaoProntuarios/Editar"
import VisualizarProntuario from "../pages/Professor/GestaoProntuarios/Visualizar"
import ProntuariosArquivados from "../pages/Professor/GestaoProntuarios/Arquivados"
// Importando com apelidos para não dar conflito
import IndexPacientes from "../pages/Professor/GestaoPacientes/index"
import IndexPsicologos from "../pages/Professor/GestaoPsicologos/index"
import IndexConsultas from "../pages/Professor/GestaoConsultas/index"
import IndexProntuarios from "../pages/Professor/GestaoProntuarios/index"

export const ProfessorRoutes = (
  <Route path="" element={<DashboardProfessor />}>

    {/* Home do Dashboard */}
    <Route index element={<div>Home do Professor</div>} />

    {/* Gestão de Pacientes */}
    <Route path="gestao-pacientes">
        <Route index element={<IndexPacientes />} />
        <Route path="visualizar/:id" element={<VisualizarPaciente />} />        
        <Route path="criar" element={<CriarPaciente />} />
        <Route path="editar/:id" element={<EditarPaciente />} />    
        <Route path="arquivados" element={<PacientesArquivados />} />
    </Route>

    {/* Gestão de Consultas */}
    <Route path="gestao-consultas">
      <Route index element={<IndexConsultas />} />
      <Route path="visualizar/:id" element={<VisualizarConsulta />} />        
      <Route path="criar" element={<CriarConsulta />} />
      <Route path="editar/:id" element={<EditarConsulta />} />    
      <Route path="arquivados/" element={< ConsultasArquivadas />} />
    </Route>

    {/* Gestão de Prontuarios */}
    <Route path="gestao-prontuarios">
      <Route index element={<IndexProntuarios />} />
      <Route path="visualizar/:id" element={<VisualizarProntuario />} />        
      <Route path="criar" element={<CriarProntuario />} />
      <Route path="editar/:id" element={<EditarProntuario />} />    
      <Route path="arquivados" element={< ProntuariosArquivados />} />
    </Route>


    {/* Gestão de Psicologos */}
    <Route path="gestao-psicologos">
      <Route index element={<IndexPsicologos />} />
      <Route path="visualizar/:id" element={<VisualizarPsicologo />} />        
      <Route path="criar" element={<CriarPsicologo />} />
      <Route path="editar/:id" element={<EditarPsicologo />} />    
      <Route path="desativados" element={< PsicologosDesativados />} />
    </Route>
  </Route>
);