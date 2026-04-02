// user.service.js
import api from './api';

const AuthService = {

  //chama Task<ActionResult<AuthResponseDto>> Register([FromForm] RegisterDto registerDto)
  cadastrar: async (registerData) => {
    const response = await api.post('/Auth/Register', registerData);
    return response.data;
  },

  //chama Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginDto)
  login: async (loginDto) => {
    const response = await api.post(`/Auth/Login`, loginDto);
    return response.data;
  },

  //chama Task<ActionResult<UserDto>> GetCurrentUser()
  // aqui eu to pensando em crir um DTO com todos os dados usuario+psicologo
  perfil: async () => {
    const response = await api.get(`/Auth/Me`);
    return response.data;
  },

  //chama ActionResult ValidateToken()
  validarToken: async () => {
    const response = await api.get(`/Auth/Validate`);
    return response.data;
}
}

export default AuthService ;