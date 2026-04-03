import { useState, useEffect } from "react";
import PacienteService from "../../../services/PacienteService"
import { Link } from "react-router-dom";

function index() {
    // Estado para armazenar a lista que vem da API
   const [pacientes, setPacientes] = useState([]);
                                        

    // configuraracao chamada de API
   useEffect(() => {
        const carregarPacientes = async () => {
            try {
                // 2. Chama a função através do objeto PacienteService
                const data = await PacienteService.buscarTodos();
                setPacientes(data);
            } catch (error) {
                console.error("Erro ao buscar pacientes:", error);
            }
        };

        carregarPacientes(); 
    }, []);

    return (

            <section style={{ padding: '20px' }}>
                <h1>Lista de Pacientes</h1>
                
                <div className="psicologos-container" style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
                    {pacientes.length > 0 ? (
                        pacientes.map((paciente) => (
                           <Link 
        key={paciente.id} 
        to={`visualizar/${paciente.id}`}
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
            {/**TODO:3 ao inves dessas informações, dava pa fazer um componente pra receber FichaUsuarioDto (que eu disse no whatsapp) */}
           <h3>{paciente.nomeCompleto}</h3>
           <p>{paciente.id}</p>
           <small>Clique para ver perfil completo</small>
        </div>
    </Link>
                        ))
                    ) : (
                        <p>Carregando pacientes...</p>
                    )}
                </div>
            </section>
    );
}

export default index;