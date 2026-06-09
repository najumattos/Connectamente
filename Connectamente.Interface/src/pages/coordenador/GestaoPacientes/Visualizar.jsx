import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import PacienteService from "../../../services/PacienteService";

function Visualizar() {
  const { id } = useParams();
  const [paciente, setPaciente] = useState(null);
  const [carregando, setCarregando] = useState(true);

  useEffect(() => {
    const buscarDados = async () => {
      try {
        const data = await PacienteService.buscarPorId(id);
        setPaciente(data);
      } catch (error) {
        console.error("Erro ao carregar detalhes do paciente:", error);
      } finally {
        setCarregando(false);
      }
    };

    if (id) buscarDados();
  }, [id]);

  if (carregando) return <p style={estilos.mensagem}>Carregando perfil do paciente...</p>;
  if (!paciente) return <p style={estilos.mensagem}>Ops! Perfil não encontrado.</p>;

  return (
    <section style={estilos.container}>
      <header style={estilos.header}>
        <h1 style={estilos.titulo}>Perfil de {paciente.nomeCompleto}</h1>
        <span style={paciente.ativo ? estilos.badgeAtivo : estilos.badgeInativo}>
          {paciente.ativo ? "Ativo" : "Inativo"}
        </span>
      </header>

      <div style={estilos.grid}>
        {/* Bloco 1: Informações Pessoais */}
        <div style={estilos.card}>
          <h2 style={estilos.subtitulo}>Dados Pessoais</h2>
          <div style={estilos.infoGroup}>
            <p style={estilos.texto}><strong>ID:</strong> {paciente.id}</p>
            <p style={estilos.texto}><strong>CPF:</strong> {paciente.cpf}</p>
            <p style={estilos.texto}><strong>RG:</strong> {paciente.rg}</p>
            <p style={estilos.texto}><strong>Idade:</strong> {paciente.idade} anos</p>
            <p style={estilos.texto}><strong>Data de Nascimento:</strong> {paciente.dataNascimento}</p>
            <p style={estilos.texto}><strong>Sexo:</strong> {paciente.sexo}</p>
            <p style={estilos.texto}><strong>Estado Civil:</strong> {paciente.estadoCivil}</p>
            <p style={estilos.texto}><strong>Profissão:</strong> {paciente.profissao}</p>
            <p style={estilos.texto}><strong>Naturalidade:</strong> {paciente.naturalidade} - {paciente.estadoNascimento}</p>
            <p style={estilos.texto}><strong>Responsável Legal:</strong> {paciente.responsavelLegal || "Não informado"}</p>
          </div>
        </div>

        {/* Bloco 2: Contato e Sistema */}
        <div style={estilos.card}>
          <h2 style={estilos.subtitulo}>Contato e Registro</h2>
          <div style={estilos.infoGroup}>
            <p style={estilos.texto}><strong>Telefone:</strong> {paciente.telefone}</p>
            <p style={estilos.texto}><strong>Telefone de Recado:</strong> {paciente.telefoneRecado || "Não informado"}</p>
            <p style={estilos.texto}><strong>Data de Criação:</strong> {paciente.dataCriacao}</p>
            <p style={estilos.texto}><strong>Última Atualização:</strong> {paciente.dataAtualizacao}</p>
          </div>
        </div>

        {/* Bloco 3: Prontuário Clínico */}
        <div style={{ ...estilos.card, ...estilos.cardDestaque }}>
          <h2 style={estilos.subtitulo}>Informações Clínicas</h2>
          <div style={estilos.infoGroup}>
            <p style={estilos.texto}><strong>Nº do Prontuário:</strong> {paciente.numeroProntuario}</p>
            <p style={estilos.texto}><strong>Psicólogo Responsável:</strong> {paciente.psicologoResponsavel}</p>
          </div>
          <button 
            style={estilos.botaoProntuario}
            onClick={() => console.log("Abrir prontuário do paciente:", paciente.id)}
          >
            Acessar Prontuário
          </button>
        </div>
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
  },
  header: {
    display: "flex",
    alignItems: "center",
    gap: "15px",
    marginBottom: "25px",
    borderBottom: "2px solid #e9ecef",
    paddingBottom: "15px",
  },
  titulo: {
    fontSize: "24px",
    color: "#212529",
    margin: 0,
  },
  badgeAtivo: {
    backgroundColor: "#d4edda",
    color: "#155724",
    padding: "5px 12px",
    borderRadius: "20px",
    fontSize: "14px",
    fontWeight: "bold",
  },
  badgeInativo: {
    backgroundColor: "#f8d7da",
    color: "#721c24",
    padding: "5px 12px",
    borderRadius: "20px",
    fontSize: "14px",
    fontWeight: "bold",
  },
  grid: {
    display: "grid",
    gridTemplateColumns: "repeat(auto-fit, minmax(300px, 1fr))",
    gap: "20px",
  },
  card: {
    backgroundColor: "#ffffff",
    borderRadius: "8px",
    padding: "20px",
    boxShadow: "0 2px 4px rgba(0,0,0,0.05)",
    border: "1px solid #dee2e6",
  },
  cardDestaque: {
    borderLeft: "5px solid #007bff",
    display: "flex",
    flexDirection: "column",
    justifyContent: "space-between",
  },
  subtitulo: {
    fontSize: "18px",
    color: "#495057",
    marginTop: 0,
    marginBottom: "15px",
    borderBottom: "1px solid #f1f3f5",
    paddingBottom: "8px",
  },
  infoGroup: {
    display: "flex",
    flexDirection: "column",
    gap: "10px",
  },
  texto: {
    margin: 0,
    fontSize: "14px",
    color: "#495057",
  },
  botaoProntuario: {
    marginTop: "20px",
    backgroundColor: "#007bff",
    color: "#ffffff",
    border: "none",
    padding: "10px 15px",
    borderRadius: "5px",
    cursor: "pointer",
    fontWeight: "600",
    fontSize: "14px",
    transition: "background-color 0.2s",
  },
  mensagem: {
    textAlign: "center",
    padding: "50px",
    fontSize: "18px",
    color: "#6c757d",
  }
};

export default Visualizar;