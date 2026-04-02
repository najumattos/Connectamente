import { BrowserRouter, Routes, Route } from "react-router-dom"
import Login from "../pages/Login"
import Cadastro from "../pages/Cadastro"
import DashboardPaciente from "../pages/paciente/DashboardPaciente"
import DashboardPsicologo from "../pages/psicologo/DashboardPsicologo"
import PrivateRoute from "./PrivateRoute"
import Home from "../pages/Home"
import PerfilPaciente from "../pages/PerfilPaciente"
import PerfilPsicologo from "../pages/PerfilPsicologo"
import DetalhesPsicologo from "../pages/psicologo/DetalhesPsicologo"

function AppRoutes() {
  return (
    //TODO: isso aqui vai crescer bastante, eu acho melhor separar os arquivos como esta no services
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />
      
      {/*PsicologoRoute.jsx*/}
        <Route path="/detalhes-psicologo/:id" element={<DetalhesPsicologo />} />


        <Route
          path="/dashboard-paciente"
          element={
            <PrivateRoute tipoPermitido="paciente">
              <DashboardPaciente />
            </PrivateRoute>
          }
        />

        <Route
          path="/perfil-paciente"
          element={
            <PrivateRoute tipoPermitido="paciente">
              <PerfilPaciente />
            </PrivateRoute>
          }
        />

        <Route
          path="/dashboard-psicologo"
          element={
            <PrivateRoute tipoPermitido="psicologo">
              <DashboardPsicologo />
            </PrivateRoute>
          }
        />

        <Route
          path="/perfil-paciente"
          element={
            <PrivateRoute tipoPermitido="paciente">
              <PerfilPaciente />
            </PrivateRoute>
          }
        />

        <Route
          path="/perfil-psicologo"
          element={
            <PrivateRoute tipoPermitido="psicologo">
              <PerfilPsicologo />
            </PrivateRoute>
          }
        />

        

      </Routes>



    </BrowserRouter>
  )
}

export default AppRoutes
