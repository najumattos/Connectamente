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
  <Route path="/coordenador" element={<DashboardCoordenador />}>

    {/* Home do Dashboard */}
    <Route index element={<div>Home do Coordenador</div>} />

    {/* Gestão de Pacientes */}
    <Route path="GestaoPacientes">
        <Route index element={<IndexPacientes />} />
        <Route path="Visualizar/:id" element={<VisualizarPaciente />} />        
        <Route path="Criar" element={<CriarPaciente />} />
        <Route path="Editar/:id" element={<EditarPaciente />} />    
        <Route path="Arquivados" element={<PacientesArquivados />} />
    </Route>

    {/* Gestão de Consultas */}
    <Route path="GestaoConsultas">
      <Route index element={<IndexConsultas />} />
      <Route path="Visualizar/:id" element={<VisualizarConsulta />} />        
      <Route path="Criar" element={<CriarConsulta />} />
      <Route path="Editar/:id" element={<EditarConsulta />} />    
      <Route path="Arquivados/" element={< ConsultasArquivadas />} />
    </Route>

    {/* Gestão de Prontuarios */}
    <Route path="GestaoProntuarios">
      <Route index element={<IndexProntuarios />} />
      <Route path="Visualizar/:id" element={<VisualizarProntuario />} />        
      <Route path="Criar" element={<CriarProntuario />} />
      <Route path="Editar/:id" element={<EditarProntuario />} />    
      <Route path="Arquivados" element={< ProntuariosArquivados />} />
    </Route>


    {/* Gestão de Psicologos */}
    <Route path="GestaoPsicologos">
      <Route index element={<IndexPsicologos />} />
      <Route path="Visualizar/:id" element={<VisualizarPsicologo />} />        
      <Route path="Criar" element={<CriarPsicologo />} />
      <Route path="Editar/:id" element={<EditarPsicologo />} />    
      <Route path="Desativados" element={< PsicologosDesativados />} />
    </Route>
  </Route>
);