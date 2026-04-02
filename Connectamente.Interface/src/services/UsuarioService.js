// user.service.js
import api from './api';

const UsuarioService = {

  //chama GetUsuario(string id) e recebe UserDto
  buscarPorId: async (id) => {
    const response = await api.get(`/Usuarios/${id}`);
    return response.data;
  },

  //chama PutUsuario(string id, IFormFile foto, [FromForm] UserUpdateDto usuarioUpdateDto) e recebe true/false (atualizado/naoAtualizado)
  //img pode ser nulo
  atualizar: async (id, img, usuarioUpdateDto) => {
    const response = await api.put(`/Usuarios/${id}`, img, usuarioUpdateDto);
    return response.data;
  },

  //chama DesativarUsuario(string id) e recebe true/false (perfil desativado/nao Desativado)
  desativar: async (id) => {
    const response = await api.patch(`/Usuarios/${id}`);
    return response.data;
}
}

export default UsuarioService;