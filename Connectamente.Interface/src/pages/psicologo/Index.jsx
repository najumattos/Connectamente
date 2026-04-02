import { useState, useEffect } from "react";
import PsicologoService from "../../services/PsicologoService"
import { Link } from "react-router-dom";

function Index() {
    // Estado para armazenar a lista que vem da API
   const [psicologos, setPsicologos] = useState([]);
                                        

    // configuraracao chamada de API
   useEffect(() => {
        const carregarPsicologos = async () => {
            try {
                // 2. Chama a função através do objeto PsicologoService
                const data = await PsicologoService.buscarTodos();
                setPsicologos(data);
            } catch (error) {
                console.error("Erro ao buscar psicólogos:", error);
            }
        };

        carregarPsicologos(); // TODO: acredito que daqui pra cima voce nao precisa mexer, só no retorno mesmo. 
        // TODO: e apaga esses comentarios depois pfv 
    }, []);

    return (

            <section style={{ padding: '20px' }}>
                <h1>Lista de Psicólogos</h1>
                
                <div className="psicologos-container" style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
                    {psicologos.length > 0 ? (
                        /* TODO: aqui vao os dados do FichaUsuarioDto(eu faria um componente reutilizavel que recebe o idUsuario ja que a lista contem os mesmos dados pra a index paciente tbm mas voce que manda trufinha, isso aqui eu fiz de qualquer jeito com IA só pra configurar a chamada) */
                        psicologos.map((psicologo) => (
                           <Link 
        key={psicologo.usuarioId} 
        to={`/detalhes-psicologo/${psicologo.usuarioId}`}
        style={{ textDecoration: 'none', color: 'inherit' }} // Remove o estilo padrão de link (azul/sublinhado)
    >
        <div style={{ 
            border: '1px solid #ccc', 
            padding: '10px', 
            borderRadius: '8px',
            cursor: 'pointer', // Indica que é clicável
            transition: 'background 0.2s'
        }}
        onMouseEnter={(e) => e.currentTarget.style.background = '#f9f9f9'}
        onMouseLeave={(e) => e.currentTarget.style.background = 'transparent'}
        >
           <h3>{psicologo.nomeCompleto}</h3>
           <small>Clique para ver perfil completo</small>
        </div>
    </Link>
                        ))
                    ) : (
                        <p>Carregando psicólogos...</p>
                    )}
                </div>
            </section>
    );
}

export default Index;