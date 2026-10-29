import { Route } from "react-router-dom";
import DashboardProfessor from "../pages/Professor/DashboardProfessor";
import PacientesPage from "../features/pacientes/pages/PacientesPage";

export function ProfessorRoutes() {
  return (
    <Route
      path="/professor"
      element={<DashboardProfessor />}
    >
      {/* Home do dashboard */}
      <Route
        index
        element={<div>Home do Professor</div>}
      />

      {/* Gestão de pacientes */}
      <Route
        path="gestao-pacientes"
        element={<PacientesPage />}
      />
    </Route>
  )
}