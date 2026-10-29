import { useContext } from "react"
import { AuthContext } from "../../context/AuthContext"
import DashboardLayout from "../../layouts/DashboardLayout";
import { Outlet } from "react-router-dom";
function DashboardProfessor() {

  const { usuario } = useContext(AuthContext)

 const menuItems = [
    { id: "home", label: "Home", path: "/Professor" },
    { id: "prontuarios", label: "Prontuários", path: "/Professor/gestao-prontuarios" },
    { id: "pacientes", label: "Pacientes", path: "/Professor/gestao-pacientes" },
    { id: "consultas", label: "Consultas", path: "/Professor/gestao-consultas" },
    { id: "psicologos", label: "Psicólogos", path: "/Professor/gestao-psicologos" }
  ];

  return (
  <DashboardLayout 
      menuItems={menuItems} 
      titulo={`Painel Professor - ${usuario?.nome}`}
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

export default DashboardProfessor
