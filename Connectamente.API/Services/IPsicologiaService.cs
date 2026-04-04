namespace Connectamente.API.Services
{
    public interface IPsicologiaService
    {
        public Task<UsuarioListaDto>BuscarPacientesPorPerfil(string authAcessoDto);
    }
}
