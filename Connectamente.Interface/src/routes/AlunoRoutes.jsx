import { Route } from "react-router-dom";
import DashboardAluno from "../pages/Aluno/AlunoDashboard";
import PacientesPage from "../features/pacientes/pages/PacientesPage";

export function AlunoRoutes() {
  return (
    <Route
      path="/aluno"
      element={<DashboardAluno />}
    >
      {/* Home do dashboard */}
      <Route
        index
        element={<div>Home do Aluno</div>}
      />

      {/* Gestão de pacientes */}
      <Route
        path="gestao-pacientes"
        element={<PacientesPage />}
      />
    </Route>
  )
}