import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import PacienteService from "../../../services/PacienteService"

function Visualizar() {
  const { id } = useParams();
    const [paciente, setPaciente] = useState(null);
    const [carregando, setCarregando] = useState(true);

    useEffect(() => {
        const buscarDados = async () => {
            try {
                 // 2. Chama a função através do objeto PacienteService
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

    if (carregando) return <p>Carregando perfil do paciente...</p>;
    if (!paciente) return <p>Ops! Perfil não encontrado.</p>;
   return ( 
    
    <section style={{ padding: '20px' }}>
        {/**tanto aqui quanto na parte de visualizar dados  */}
            <h1>Perfil de {paciente.nomeCompleto}</h1>
            <p><strong>ID do Usuário:</strong> {paciente.id}</p>        
        </section>
    );
}
export default Visualizar;
