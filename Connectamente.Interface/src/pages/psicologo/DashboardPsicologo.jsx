import { useContext } from "react"
import { AuthContext } from "../../context/AuthContext"
import DashboardLayout from "../../layouts/DashboardLayout";
import Index from "./Index"
function DashboardPsicologo() {

  const { usuario } = useContext(AuthContext)

  const menuItems = [
    { id: "home", label: "Home" },
    { id: "pacientes", label: "Pacientes" },
    { id: "agenda", label: "Agenda" },
    { id: "relatorios", label: "Relatórios" },
    { id: "perfil", label: "Meu Perfil" }
  ]

  return (
    <DashboardLayout
      menuItems={menuItems}
      titulo="Dashboard do Psicólogo"
    >
      {(activeItem) => (

        <div className="dashboard-content">

          {activeItem === "home" && (
            <div className="card">
              <h2>Bem-vindo, {usuario?.nome}</h2>
              <p>virá de ConsultasModel</p>
             
            </div>
          )}

          {activeItem === "pacientes" && (
            <div className="card">
              <h2>Lista de Pacientes</h2>
              <p>Aqui aparecerão seus pacientes cadastrados.</p>
            </div>
          )}

          {activeItem === "agenda" && (
            <div className="card">
              <h2>Agenda</h2>
              <p>psicolgoos</p>
               <Index></Index> 
            </div>
          )}

          {activeItem === "relatorios" && (
            <div className="card">
              <h2>Relatórios</h2>
              <p>Relatórios clínicos e evolução.</p>
            </div>
          )}

          {activeItem === "perfil" && (
            <div className="card">
              <h2>Meu Perfil</h2>
              <p>Gerencie suas informações profissionais.</p>
            </div>
          )}

        </div>
      )}
    </DashboardLayout>
  )
}

export default DashboardPsicologo
