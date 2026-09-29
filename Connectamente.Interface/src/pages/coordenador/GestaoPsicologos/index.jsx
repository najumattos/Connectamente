import { useState, useEffect } from "react";
import PsicologoService from "../../../services/PsicologoService"
import { Link } from "react-router-dom";

function index() {
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

        carregarPsicologos(); 
    }, []);

    return (

            <section style={{ padding: '20px' }}>
                <h1>Lista de Psicólogos</h1>
                
                <div className="psicologos-container" style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
                    {psicologos.length > 0 ? (
                        psicologos.map((psicologo) => (
                           <Link 
        key={psicologo.psicologoResponsavelId} 
        to={`visualizar/${psicologo.psicologoResponsavelId}`}
        style={{ textDecoration: 'none', color: 'inherit' }} 
    >
        <div style={{ 
            border: '1px solid #ccc', 
            padding: '10px', 
            borderRadius: '8px',
            cursor: 'pointer',
            transition: 'background 0.2s'
        }}
        onMouseEnter={(e) => e.currentTarget.style.background = '#f9f9f9'}
        onMouseLeave={(e) => e.currentTarget.style.background = 'transparent'}
        >
            {/**TODO:1 ao inves dessas informações, dava pa fazer um componente pra receber FichaUsuarioDto (que eu disse no whatsapp) */}
           <h3>{psicologo.nomeCompleto}</h3>
           <p>{psicologo.psicologoResponsavelId}</p>
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

export default index;