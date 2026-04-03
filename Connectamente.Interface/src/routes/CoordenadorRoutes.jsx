import { Route } from "react-router-dom";
import DashboardCoordenador from "../pages/coordenador/DashboardCoordenador";
import CriarPaciente from "../pages/coordenador/GestaoPacientes/Criar"
import EditarPaciente from "../pages/coordenador/GestaoPacientes/Editar"
import VisualizarPaciente from "../pages/coordenador/GestaoPacientes/Visualizar"
import PacientesArquivados from "../pages/coordenador/GestaoPacientes/Arquivados"
import CriarPsicologo from "../pages/coordenador/GestaoPsicologos/Criar"
import EditarPsicologo from "../pages/coordenador/GestaoPsicologos/Editar"
import VisualizarPsicologo from "../pages/coordenador/GestaoPsicologos/Visualizar"
import PsicologosDesativados from "../pages/coordenador/GestaoPsicologos/Desativados"
import CriarConsulta from "../pages/coordenador/GestaoConsultas/Criar"
import EditarConsulta from "../pages/coordenador/GestaoConsultas/Editar"
import VisualizarConsulta from "../pages/coordenador/GestaoConsultas/Visualizar"
import ConsultasArquivadas from "../pages/coordenador/GestaoConsultas/Arquivados"
import CriarProntuario from "../pages/coordenador/GestaoProntuarios/Criar"
import EditarProntuario from "../pages/coordenador/GestaoProntuarios/Editar"
import VisualizarProntuario from "../pages/coordenador/GestaoProntuarios/Visualizar"
import ProntuariosArquivados from "../pages/coordenador/GestaoProntuarios/Arquivados"
// Importando com apelidos para não dar conflito
import IndexPacientes from "../pages/coordenador/GestaoPacientes/index"
import IndexPsicologos from "../pages/coordenador/GestaoPsicologos/index"
import IndexConsultas from "../pages/coordenador/GestaoConsultas/index"
import IndexProntuarios from "../pages/coordenador/GestaoProntuarios/index"

export const CoordenadorRoutes = (
  <Route path="" element={<DashboardCoordenador />}>

    {/* Home do Dashboard */}
    <Route index element={<div>Home do Coordenador</div>} />

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