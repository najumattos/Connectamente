import { useContext } from "react"
import { AuthContext } from "../../context/AuthContext"
import DashboardLayout from "../../layouts/DashboardLayout";
import { Outlet } from "react-router-dom";
function DashboardCoordenador() {

  const { usuario } = useContext(AuthContext)

 const menuItems = [
    { id: "home", label: "Home", path: "/coordenador" },
    { id: "prontuarios", label: "Prontuários", path: "/coordenador/gestao-prontuarios" },
    { id: "pacientes", label: "Pacientes", path: "/coordenador/gestao-pacientes" },
    { id: "consultas", label: "Consultas", path: "/coordenador/gestao-consultas" },
    { id: "psicologos", label: "Psicólogos", path: "/coordenador/gestao-psicologos" }
  ];

  return (
  <DashboardLayout 
      menuItems={menuItems} 
      titulo={`Painel Coordenador - ${usuario?.nome}`}
    >
      {/* 1. Transforme em função recebendo o activeItem */}
      {(activeItem) => (
        <div className="dashboard-content">
          {/* 2. O Outlet renderiza as rotas filhas (Pacientes, Consultas, etc) */}
          <Outlet /> 
        </div>
      )}
    </DashboardLayout>
  )
}

export default DashboardCoordenador
