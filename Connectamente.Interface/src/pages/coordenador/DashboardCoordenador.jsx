import { useContext } from "react"
import { AuthContext } from "../../context/AuthContext"
import DashboardLayout from "../../layouts/DashboardLayout";
import { Outlet } from "react-router-dom";
function DashboardCoordenador() {

  const { usuario } = useContext(AuthContext)

 const menuItems = [
    { id: "home", label: "Home", path: "/coordenador" },
    { id: "prontuarios", label: "Prontuários", path: "/coordenador/Gestaoprontuarios" },
    { id: "pacientes", label: "Pacientes", path: "/coordenador/Gestaopacientes" },
    { id: "consultas", label: "Consultas", path: "/coordenador/Gestaoconsultas" },
    { id: "psicologos", label: "Psicólogos", path: "/coordenador/Gestaopsicologos" }
  ];

  return (
    <DashboardLayout 
      menuItems={menuItems} 
      titulo={`Painel de Controle Coordenador - ${usuario?.nome}`}
    >
      {/* O Outlet é onde o React Router vai renderizar a página filha baseada na URL */}
      <div className="dashboard-content">
        <Outlet /> 
      </div>
    </DashboardLayout>
  )
}

export default DashboardCoordenador
