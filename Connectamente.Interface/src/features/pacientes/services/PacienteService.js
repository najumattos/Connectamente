
import api from "../../../services/api"

const PacienteService = {
  listar: async () => {
    const response = await api.get('/api/pacientes');
    return response.data;
  },
}

export default PacienteService
