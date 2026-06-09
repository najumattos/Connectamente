// user.service.js
import api from './api';

const ProntuarioService = {

  //chama GetProntuarios() e retorna uma lista de ProntuarioListaDto  
  buscarTodos: async () => {
    const response = await api.get('/Prontuarios/Buscar');
    return response.data;
  },

  //chama Task<ActionResult<ProntuarioDto>> GetProntuario(string id)
  //tem que por referencia ao psicologo e ao paciente?
  buscarPorId: async (id) => {
    const response = await api.get(`/Prontuarios/${id}`);
    return response.data;
  },

  //chama Task<ActionResult> PutProntuario(string id, ProntuarioDto prontuarioDto)
  atualizar: async (id, prontuarioDto) => {
    const response = await api.put(`/Prontuarios/${id}`, prontuarioDto);
    return response.data;
  },

  //chama Task<ActionResult> ArquivarProntuario(string id) 
  arquivar: async (id) => {
    const response = await api.patch(`/Prontuarios/${id}`);
    return response.data;
}
}

export default ProntuarioService ;