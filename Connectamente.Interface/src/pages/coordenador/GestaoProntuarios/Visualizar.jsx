import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import ProntuarioService from "../../../services/ProntuarioService";

function Visualizar() {
  const { id } = useParams();
  const [prontuario, setProntuario] = useState(null);
  const [carregando, setCarregando] = useState(true);

  useEffect(() => {
    const buscarDados = async () => {
      try {
        const data = await ProntuarioService.buscarPorId(id);
        setProntuario(data);
      } catch (error) {
        console.error("Erro ao carregar detalhes do prontuario:", error);
      } finally {
        setCarregando(false);
      }
    };

    if (id) buscarDados();
  }, [id]);

  const obterEstiloStatus = (situacao) => {
    const status = situacao?.toLowerCase() || "";
    if (status === "ativo" || status === "aberto") return estilos.badgeAtivo;
    if (status === "arquivado" || status === "inativo") return estilos.badgeInativo;
    return estilos.badgePendente;
  };

  if (carregando) return <p style={estilos.mensagem}>Carregando dados do prontuário...</p>;
  if (!prontuario) return <p style={estilos.mensagem}>Ops! Prontuário não encontrado.</p>;

  return (
    <section style={estilos.container}>    
      <header style={estilos.header}>
        <h1 style={estilos.titulo}>Nº do Prontuário: {prontuario.numeroProntuario}</h1>
        <span style={obterEstiloStatus(prontuario.situacaoProntuario)}>
          {prontuario.situacaoProntuario || "Não Informado"}
        </span>
      </header>

      <div style={estilos.grid}>
        {/* Bloco 1: Informações Gerais */}
        <div style={{ ...estilos.card, ...estilos.cardDestaque }}>
          <h2 style={estilos.subtitulo}>Dados Gerais</h2>
          <div style={estilos.infoGroup}>
            <p style={estilos.texto}><strong>Paciente:</strong> {prontuario.pacienteNomeCompleto}</p>
            <p style={estilos.texto}><strong>Psicólogo Responsável:</strong> {prontuario.nomePsicologoResponsavel}</p>
            <p style={estilos.texto}><strong>Primeira Consulta:</strong> {prontuario.dataPrimeiraConsulta || "Não informada"}</p>
            <p style={estilos.texto}><strong>Observações Gerais:</strong> {prontuario.observacoesGerais || "Nenhuma observação registrada."}</p>
          </div>
        </div>

        {/* Bloco 2: Tratamentos Anteriores */}
        <div style={estilos.card}>
          <h2 style={estilos.subtitulo}>Tratamentos Anteriores</h2>
          <div style={estilos.infoGroup}>
            {/* Mapeamento futuro do array virá aqui */}
            <p style={estilos.textoInformativo}><strong>Observações Gerais:</strong> {prontuario.tratamentosAnteriores.id || "Nenhum histórico de tratamento anterior registrado."}</p>
          </div>
        </div>

        {/* Bloco 3: Atendimentos */}
        <div style={estilos.card}>
          <h2 style={estilos.subtitulo}>Atendimentos (Sessões)</h2>
          <div style={estilos.infoGroup}>
            {/* Mapeamento futuro do array virá aqui */}
            <p style={estilos.textoInformativo}>Nenhuma sessão de atendimento registrada até o momento.</p>
          </div>
        </div>

        {/* Bloco 4: Documentos Clínicos */}
        <div style={estilos.card}>
          <h2 style={estilos.subtitulo}>Documentos Clínicos</h2>
          <div style={estilos.infoGroup}>
            {/* Mapeamento futuro do array virá aqui */}
            <p style={estilos.textoInformativo}>Nenhum documento ou laudo anexado a este prontuário.</p>
          </div>
        </div>
      </div>
    </section>
  );
}

// Objeto de Estilização Centralizado e Corrigido
const estilos = {
  container: {
    padding: "30px",
    fontFamily: "'Segoe UI', Roboto, Helvetica, Arial, sans-serif",
    backgroundColor: "#f8f9fa",
    minHeight: "100vh",
    maxWidth: "1200px",
    margin: "0 auto",
  },
  header: {
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
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
    padding: "6px 14px",
    borderRadius: "20px",
    fontSize: "14px",
    fontWeight: "bold",
    textTransform: "capitalize",
  },
  badgeInativo: {
    backgroundColor: "#f8d7da",
    color: "#721c24",
    padding: "6px 14px",
    borderRadius: "20px",
    fontSize: "14px",
    fontWeight: "bold",
    textTransform: "capitalize",
  },
  badgePendente: {
    backgroundColor: "#fff3cd",
    color: "#856404",
    padding: "6px 14px",
    borderRadius: "20px",
    fontSize: "14px",
    fontWeight: "bold",
    textTransform: "capitalize",
  },
  grid: {
    display: "grid",
    gridTemplateColumns: "repeat(auto-fit, minmax(350px, 1fr))",
    gap: "24px",
  },
  card: {
    backgroundColor: "#ffffff",
    borderRadius: "8px",
    padding: "24px",
    boxShadow: "0 2px 4px rgba(0,0,0,0.05)",
    border: "1px solid #dee2e6",
  },
  cardDestaque: {
    borderLeft: "5px solid #007bff",
  },
  subtitulo: {
    fontSize: "18px",
    color: "#495057",
    marginTop: 0,
    marginBottom: "20px",
    borderBottom: "1px solid #f1f3f5",
    paddingBottom: "8px",
    fontWeight: "600",
  },
  infoGroup: {
    display: "flex",
    flexDirection: "column",
    gap: "12px",
  },
  texto: {
    margin: 0,
    fontSize: "15px",
    color: "#495057",
    lineHeight: "1.5",
  },
  textoInformativo: {
    margin: 0,
    fontSize: "14px",
    color: "#868e96",
    fontStyle: "italic",
  },
  mensagem: {
    textAlign: "center",
    padding: "50px",
    fontSize: "18px",
    color: "#6c757d",
  }
};

export default Visualizar;