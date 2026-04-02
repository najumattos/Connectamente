// user.service.js
import api from './api';

const PsicologoService = {

  //chama GetPsicologo() e retorna uma lista de FichaUsuarioDto  || Esse FichaUsuarioDto é um DTO generico para lista de psicologo, paciente e usuario
  buscarTodos: async () => {
    const response = await api.get('/Psicologos/Buscar');
    return response.data;
  },

  //chama Task<ActionResult<PsicologoDto>> GetPsicologo(string id)
  //tem que por referencia a lista de Prontuarios?
  buscarPorId: async (id) => {
    const response = await api.get(`/Psicologos/${id}`);
    return response.data;
  },

  //chama Task<ActionResult> PutPsicologo(string id, PsicologoDto psicologoDto)
  atualizar: async (id, psicologoDto) => {
    const response = await api.put(`/Psicologos/${id}`, psicologoDto);
    return response.data;
  },

  //chama Task<ActionResult> DesativarPerfilPsicologo(string id) 
  desativar: async (id) => {
    const response = await api.patch(`/Psicologos/${id}`);
    return response.data;
}
}

export default PsicologoService ;