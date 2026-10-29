
import { useEffect, useState } from "react"
import PacienteService from "../services/PacienteService"
import PacientesTable from "../components/PacientesTable"

function PacientesPage() {
  const [pacientes, setPacientes] = useState([])
  const [carregando, setCarregando] = useState(true)
  const [erro, setErro] = useState("")

  useEffect(() => {
    async function carregarPacientes() {
      try {
        setCarregando(true)
        setErro("")

        const dados = await PacienteService.listar()
        setPacientes(dados)
      } catch (error) {
        setErro("Não foi possível carregar os pacientes.")
      } finally {
        setCarregando(false)
      }
    }

    carregarPacientes()
  }, [])

  if (carregando) {
    return <p>Carregando pacientes...</p>
  }

  if (erro) {
    return <p role="alert">{erro}</p>
  }

  return (
    <main>
      <h1>Pacientes</h1>
      <p>Consulte os pacientes disponíveis para seu perfil.</p>

      <PacientesTable pacientes={pacientes} />
    </main>
  )
}

export default PacientesPage
