import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import PsicologoService from "../../../services/PsicologoService"

function DetalhesPsicologo() {
  const { id } = useParams();
    const [psicologo, setPsicologo] = useState(null);
    const [carregando, setCarregando] = useState(true);

    useEffect(() => {
        const buscarDados = async () => {
            try {
                 // 2. Chama a função através do objeto PsicologoService
                              const data = await PsicologoService.buscarPorId(id);
                              setPsicologo(data);
            } catch (error) {
                console.error("Erro ao carregar detalhes do psicologo:", error);
            } finally {
                setCarregando(false);
            }
        };

        if (id) buscarDados();
    }, [id]);

    if (carregando) return <p>Carregando perfil do psicólogo...</p>;
    if (!psicologo) return <p>Ops! Perfil não encontrado.</p>;
   return ( 
    
    <section style={{ padding: '20px' }}>
            <h1>Perfil de {psicologo.nomeCompleto}</h1>
            <p><strong>ID do Usuário:</strong> {psicologo.id}</p>        
        </section>
    );
}
export default DetalhesPsicologo;
