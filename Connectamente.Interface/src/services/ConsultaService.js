// user.service.js
import api from './api';

const ConsultaService = {

  //chama GetConsultas() e retorna uma lista de ConsultaDto 
  buscarTodos: async () => {
    const response = await api.get('/Consultas/Buscar');
    return response.data;
  },

  //chama Task<ActionResult<ConsultaDto>> GetConsulta(string id)
  buscarPorId: async (id) => {
    const response = await api.get(`/Consultas/${id}`);
    return response.data;
  },

  //chama Task<ActionResult> PutConsulta(string id, ConsultaDto consultaDto)
  atualizar: async (id, consultaDto) => {
    const response = await api.put(`/Consultas/${id}`, consultaDto);
    return response.data;
  },

  //chama Task<ActionResult> DeletarAgendamentoConsulta(string id) 
  deletar: async (id) => {
    const response = await api.delete(`/Consultas/${id}`);
    return response.data;
}
}

export default ConsultaService ;