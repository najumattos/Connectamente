import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import PacienteService from "../../../services/PacienteService";

function Index() {
  const [pacientes, setPacientes] = useState([]);
  const [carregando, setCarregando] = useState(true);

  useEffect(() => {
    const carregarPacientes = async () => {
      try {
        const data = await PacienteService.buscarTodos();
        setPacientes(data);
      } catch (error) {
        console.error("Erro ao buscar pacientes:", error);
      } finally {
        setCarregando(false);
      }
    };

    carregarPacientes();
  }, []);

  return (
    <section style={estilos.container}>
      <header style={estilos.header}>
        <h1 style={estilos.titulo}>Lista de Pacientes</h1>
        <span style={estilos.contador}>Total: {pacientes.length}</span>
      </header>

      <div style={estilos.listaContainer}>
        {carregando ? (
          <p style={estilos.mensagemFeedBack}>Carregando pacientes...</p>
        ) : pacientes.length > 0 ? (
          pacientes.map((paciente) => (
            <Link
              key={paciente.id}
              to={`visualizar/${paciente.id}`}
              style={estilos.linkCard}
            >
              <div style={estilos.card}>
                <div style={estilos.cardMainInfo}>
                  <h3 style={estilos.pacienteNome}>{paciente.nomeCompleto}</h3>
                  <div style={estilos.metaDados}>
                    <span style={estilos.textoMeta}><strong>ID:</strong> {paciente.id}</span>
                    <span style={estilos.textoMeta}>•</span>
                    <span style={estilos.textoMeta}><strong>Idade:</strong> {paciente.idade} anos</span>
                    <span style={estilos.textoMeta}>•</span>
                    <span style={estilos.textoMeta}><strong>Telefone:</strong> {paciente.telefone}</span>
                  </div>
                </div>
                
                <div style={estilos.cardStatusInfo}>
                  <span style={paciente.ativo ? estilos.badgeAtivo : estilos.badgeInativo}>
                    {paciente.ativo ? "Ativo" : "Inativo"}
                  </span>
                  <small style={estilos.dicaClique}>Ver perfil completo →</small>
                </div>
              </div>
            </Link>
          ))
        ) : (
          <p style={estilos.mensagemFeedBack}>Nenhum paciente cadastrado.</p>
        )}
      </div>
    </section>
  );
}

// Objeto de Estilização Centralizado
const estilos = {
  container: {
    padding: "30px",
    fontFamily: "'Segoe UI', Roboto, Helvetica, Arial, sans-serif",
    backgroundColor: "#f8f9fa",
    minHeight: "100vh",
    maxWidth: "1000px",
    margin: "0 auto",
  },
  header: {
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    marginBottom: "25px",
    borderBottom: "2px solid #e9ecef",
    paddingBottom: "15px",
  },
  titulo: {
    fontSize: "26px",
    color: "#212529",
    margin: 0,
  },
  contador: {
    fontSize: "14px",
    backgroundColor: "#e9ecef",
    color: "#495057",
    padding: "6px 12px",
    borderRadius: "6px",
    fontWeight: "600",
  },
  listaContainer: {
    display: "flex",
    flexDirection: "column",
    gap: "12px",
  },
  linkCard: {
    textDecoration: "none",
    color: "inherit",
    display: "block",
  },
  card: {
    backgroundColor: "#ffffff",
    borderRadius: "8px",
    padding: "16px 20px",
    boxShadow: "0 1px 3px rgba(0,0,0,0.05)",
    border: "1px solid #dee2e6",
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    transition: "transform 0.15s ease-in-out, box-shadow 0.15s ease-in-out",
    cursor: "pointer",
    // Simulação do hover sem listeners inline invasivos (funciona nativamente como container interativo)
    ":hover": {
      transform: "translateY(-2px)",
      boxShadow: "0 4px 6px rgba(0,0,0,0.08)",
      borderColor: "#b6d4fe",
    }
  },
  cardMainInfo: {
    display: "flex",
    flexDirection: "column",
    gap: "6px",
  },
  pacienteNome: {
    margin: 0,
    fontSize: "18px",
    color: "#0056b3",
    fontWeight: "600",
  },
  metaDados: {
    display: "flex",
    alignItems: "center",
    gap: "10px",
    flexWrap: "wrap",
  },
  textoMeta: {
    fontSize: "14px",
    color: "#6c757d",
  },
  cardStatusInfo: {
    display: "flex",
    flexDirection: "column",
    alignItems: "flex-end",
    gap: "8px",
  },
  badgeAtivo: {
    backgroundColor: "#d4edda",
    color: "#155724",
    padding: "4px 10px",
    borderRadius: "12px",
    fontSize: "12px",
    fontWeight: "bold",
  },
  badgeInativo: {
    backgroundColor: "#f8d7da",
    color: "#721c24",
    padding: "4px 10px",
    borderRadius: "12px",
    fontSize: "12px",
    fontWeight: "bold",
  },
  dicaClique: {
    fontSize: "12px",
    color: "#999",
    fontStyle: "italic",
  },
  mensagemFeedBack: {
    textAlign: "center",
    padding: "40px",
    fontSize: "16px",
    color: "#6c757d",
  },
};

export default Index;