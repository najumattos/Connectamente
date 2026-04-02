import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5256/api',
  paramsSerializer: {
    indexes: null 
  }
});
// Exemplo de interceptor para injetar o token
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default api;
