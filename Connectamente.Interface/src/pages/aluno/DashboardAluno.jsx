import { useContext } from "react"
import { AuthContext } from "../../context/AuthContext"
import DashboardLayout from "../../layouts/DashboardLayout";
import { Outlet } from "react-router-dom";
function DashboardAluno() {

  const { usuario } = useContext(AuthContext)

 const menuItems = [
    { id: "home", label: "Home", path: "/aluno" },
    { id: "prontuarios", label: "Prontuários", path: "/aluno/meus-prontuarios" },    
    { id: "pacientes", label: "Pacientes", path: "/aluno/meus-pacientes" },   
    { id: "consultas", label: "Consultas", path: "/aluno/minhas-consultas" }
  ];

  return (
    <DashboardLayout 
      menuItems={menuItems} 
      titulo={`Painel de Controle Aluno - ${usuario?.nome}`}
    >
      {/* O Outlet é onde o React Router vai renderizar a página filha baseada na URL */}
      <div className="dashboard-content">
        <Outlet /> 
      </div>
    </DashboardLayout>
  )
}

export default DashboardAluno
