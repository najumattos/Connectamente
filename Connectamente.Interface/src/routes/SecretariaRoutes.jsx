import { Route } from "react-router-dom";
import DashboardSecretaria from "../pages/Secretaria/SecretariaDashboard";
import PacientesPage from "../features/pacientes/pages/PacientesPage";

export function SecretariaRoutes() {
  return (
    <Route
      path="/secretaria"
      element={<DashboardSecretaria />}
    >
      {/* Home do dashboard */}
      <Route
        index
        element={<div>Home da Secretaria</div>}
      />

      {/* Gestão de pacientes */}
      <Route
        path="gestao-pacientes"
        element={<PacientesPage />}
      />
    </Route>
  )
}