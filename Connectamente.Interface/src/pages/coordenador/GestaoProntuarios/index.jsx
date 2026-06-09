import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import ProntuarioService from "../../../services/ProntuarioService";

function Index() {
  const [prontuarios, setProntuarios] = useState([]);
  const [carregando, setCarregando] = useState(true);

  useEffect(() => {
    const carregarProntuarios = async () => {
      try {
        const data = await ProntuarioService.buscarTodos();
        setProntuarios(data);
      } catch (error) {
        console.error("Erro ao buscar prontuarios:", error);
      } finally {
        setCarregando(false);
      }
    };

    carregarProntuarios();
  }, []);

  // Função auxiliar para definir a cor do badge com base na situação do prontuário
  const obterEstiloStatus = (situacao) => {
    const status = situacao?.toLowerCase() || "";
    if (status === "ativo" || status === "aberto") return estilos.badgeAtivo;
    if (status === "arquivado" || status === "inativo") return estilos.badgeInativo;
    return estilos.badgePendente; // Caso exista outro status (ex: Em Andamento)
  };

  return (
    <section style={estilos.container}>
      <header style={estilos.header}>
        <h1 style={estilos.titulo}>Lista de Prontuários</h1>
        <span style={estilos.contador}>Total: {prontuarios.length}</span>
      </header>

      <div style={estilos.listaContainer}>
        {carregando ? (
          <p style={estilos.mensagemFeedBack}>Carregando prontuários...</p>
        ) : prontuarios.length > 0 ? (
          prontuarios.map((prontuario) => (
            <Link
              key={prontuario.id}
              to={`visualizar/${prontuario.id}`}
              style={estilos.linkCard}
            >
              <div style={estilos.card}> 
                {/* Lado Esquerdo: Informações Principais */}
                <div style={estilos.cardMainInfo}>
                  <h3 style={estilos.pacienteNome}>
                     <strong>Nº Prontuário:</strong> {prontuario.numeroProntuario}
                  </h3>
                  <div style={estilos.metaDados}>
                    <span style={estilos.textoMeta}>
                      <strong>Paciente:</strong> {prontuario.nomeCompletoPaciente}
                    </span>
                    <span style={estilos.divisor}>•</span>
                    <span style={estilos.textoMeta}>
                      <strong>Psicólogo:</strong> {prontuario.nomePsicologoResponsavel}
                    </span>
                  </div>
                </div>

                {/* Lado Direito: Status e Ação */}
                <div style={estilos.cardStatusInfo}>
                  <span style={obterEstiloStatus(prontuario.situacaoProntuario)}>
                    {prontuario.situacaoProntuario || "Não Informado"}
                  </span>
                  <small style={estilos.dicaClique}>Ver detalhes →</small>
                </div>
              </div>            
            </Link>
          ))
        ) : (
          <p style={estilos.mensagemFeedBack}>Nenhum prontuário cadastrado.</p>
        )}
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
    fontSize: "24px",
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
    transition: "transform 0.15s ease-in-out, box-shadow 0.15s ease-in-out, border-color 0.15s",
    cursor: "pointer",
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
    gap: "8px",
    flexWrap: "wrap",
  },
  textoMeta: {
    fontSize: "14px",
    color: "#495057",
  },
  divisor: {
    color: "#ced4da",
    userSelect: "none",
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
    padding: "4px 12px",
    borderRadius: "12px",
    fontSize: "12px",
    fontWeight: "bold",
    textTransform: "capitalize",
  },
  badgeInativo: {
    backgroundColor: "#f8d7da",
    color: "#721c24",
    padding: "4px 12px",
    borderRadius: "12px",
    fontSize: "12px",
    fontWeight: "bold",
    textTransform: "capitalize",
  },
  badgePendente: {
    backgroundColor: "#fff3cd",
    color: "#856404",
    padding: "4px 12px",
    borderRadius: "12px",
    fontSize: "12px",
    fontWeight: "bold",
    textTransform: "capitalize",
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