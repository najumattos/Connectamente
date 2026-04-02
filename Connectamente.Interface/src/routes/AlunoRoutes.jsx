import { Route } from "react-router-dom";
import DashboardAluno from "../pages/aluno/DashboardAluno";
import CriarPaciente from "../pages/aluno/MeusPacientes/Criar"
import EditarPaciente from "../pages/aluno/MeusPacientes/Editar"
import VisualizarPaciente from "../pages/aluno/MeusPacientes/Visualizar"
import CriarConsulta from "../pages/aluno/MinhasConsultas/Criar"
import EditarConsulta from "../pages/aluno/MinhasConsultas/Editar"
import VisualizarConsulta from "../pages/aluno/MinhasConsultas/Visualizar"
import CriarProntuario from "../pages/aluno/MeusProntuarios/Criar"
import EditarProntuario from "../pages/aluno/MeusProntuarios/Editar"
import VisualizarProntuario from "../pages/aluno/MeusProntuarios/Visualizar"
// Importando com apelidos para não dar conflito
import IndexPacientes from "../pages/aluno/MeusPacientes/index"
import IndexConsultas from "../pages/aluno/MinhasConsultas/index"
import IndexProntuarios from "../pages/aluno/MeusProntuarios/index"

export const AlunoRoutes = (
  <Route path="/aluno" element={<DashboardAluno />}>

    {/* Home do Dashboard */}
    <Route index element={<div>Home do Aluno</div>} />

    {/* Meus Pacientes */}
    <Route path="MeusPacientes">
        <Route index element={<IndexPacientes />} />
        <Route path="Visualizar/:id" element={<VisualizarPaciente />} />        
        <Route path="Criar" element={<CriarPaciente />} />
        <Route path="Editar/:id" element={<EditarPaciente />} />    
    </Route>

    {/* Minhas Consultas */}
    <Route path="MinhasConsultas">
      <Route index element={<IndexConsultas />} />
      <Route path="Visualizar/:id" element={<VisualizarConsulta />} />        
      <Route path="Criar" element={<CriarConsulta />} />
      <Route path="Editar/:id" element={<EditarConsulta />} />    
    </Route>

    {/* Meus Prontuarios */}
    <Route path="MeusProntuarios">
      <Route index element={<IndexProntuarios />} />
      <Route path="Visualizar/:id" element={<VisualizarProntuario />} />        
      <Route path="Criar" element={<CriarProntuario />} />
      <Route path="Editar/:id" element={<EditarProntuario />} />    
    </Route>  
  </Route>
);