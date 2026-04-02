import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import PsicologoService from "../../../services/PsicologoService"
//TODO: Ajeitar pra apareccer o mesmo layout de dashboard psicologo, a barra lateral
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
                console.error("Erro ao carregar detalhes:", error);
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
            <p><strong>ID do Usuário:</strong> {psicologo.usuarioId}</p>
            <p><strong>CRP:</strong> {psicologo.crp}</p>
            <div style={{ marginTop: '15px' }}>
                <h3>Sobre</h3>
                <p>{psicologo.descricao}</p>
            </div>
        </section>
    );
}
export default DetalhesPsicologo;
