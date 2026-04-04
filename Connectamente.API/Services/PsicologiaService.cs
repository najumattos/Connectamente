namespace Connectamente.API.Services
{
    public class PsicologiaService : IPsicologiaService
    {
        public Task<UsuarioListaDto> BuscarPacientesPorPerfil(string authAcessoDto)
        {
            /*
                authAcessoDto.tipoPerfil.ClinicaParticular -> IClinicaParticularService.BuscarPacientes(authAcessoDto) -> CoordenadorService.BuscarPacientes(procura todos paciente por tipoModulo.ClinicaParticular && idPsicologoVinculado)
                authAcessoDto.tipoPerfil.Coordenador ->  ICoordenadorService.BuscarPacientes(authAcessoDto) -> CoordenadorService.BuscarPacientes(procura todos paciente por tipoModulo.Academico)
                authAcessoDto.tipoPerfil.Aluno ->  IAlunoService.BuscarPacientes(authAcessoDto) -> AlunoService.BuscarPacientes(procura todos paciente por tipoModulo.Academico && idPsicologoVinculado)

             */
            throw new NotImplementedException();
        }
    }
}
