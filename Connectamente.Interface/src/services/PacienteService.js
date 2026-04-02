// user.service.js
import api from './api';

const PacienteService = {

  //chama GetPacientes() e retorna uma lista de FichaUsuarioDto  || Esse FichaUsuarioDto é um DTO generico para lista de psicologo, paciente e usuario
  buscarTodos: async () => {
    const response = await api.get('/Pacientes/Buscar');
    return response.data;
  },

  //chama Task<ActionResult<PacienteDto>> GetPaciente(string id)
  buscarPorId: async (id) => {
    const response = await api.get(`/Pacientes/${id}`);
    return response.data;
  },

  //chama Task<ActionResult> PutPaciente(string id, PacienteDto pacienteDto)
  atualizar: async (id, pacienteDto) => {
    const response = await api.put(`/Pacientes/${id}`, pacienteDto);
    return response.data;
  },

  //chama Task<ActionResult> ArquivarPaciente(string id) 
  arquivar: async (id) => {
    const response = await api.patch(`/Pacientes/${id}`);
    return response.data;
}
}

export default PacienteService ;