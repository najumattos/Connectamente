using Microsoft.AspNetCore.Mvc;
using Connectamente.API.Services.PacienteService;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;
using System;
using Connectamente.API.Enums;

namespace Connectamente.API.Controllers;

public class PacientesController(IPacienteService service) : MainController
{

    /// <summary>
    /// Busca Todos Pacientes
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<FichaUsuarioDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    //[autorizado: TipoModuloEnum.Psicologia]
    public async Task<ActionResult<IEnumerable<FichaUsuarioDto>>> GetPacientes(authAcessoDto(tipoPerfilEnum tipoPerfil))
    {
        /* #1
         IPsicologiaService.BuscarPacientes(authAcessoDto(tipoPerfil.ClinicaParticular || tipoPerfi.Coordenador || tipoPerfil.Aluno))
         */


        /*   #2
            PsicologiaService.BuscarPacientes(authAcessoDto(tipoPerfil)){
        
        se authAcessoDto.tipoPerfil.ClinicaParticular -> IClinicaParticularService.BuscarPacientes(authAcessoDto(idPsicologo)) -> CoordenadorService.BuscarPacientes(procura todos paciente por tipoModulo.ClinicaParticular && idPsicologoVinculado)
        se authAcessoDto.tipoPerfil.Coordenador -> ICoordenadorService.BuscarPacientes(authAcessoDto(idPsicologo)) -> CoordenadorService.BuscarPacientes(procura todos paciente por tipoModulo.Academico)
        se authAcessoDto.tipoPerfil.Aluno -> IAlunoService.BuscarPacientes(authAcessoDto(idPsicologo)) -> AlunoService.BuscarPacientes(procura todos paciente vinculados a idPsicologoVinculado)
        }
         
         */



    }

    /// <summary>
    /// Busca Todos Pacientes por Psicologo
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<FichaUsuarioDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<FichaUsuarioDto>>> GetPacientesPorPsicologo()
    {
        // acesso 
        // rota coordenador 
        //rota aluno        

    }

    /// <summary>
    /// Exibe Dados do Paciente
    /// </summary>     
    [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PacienteDto>> GetPaciente(string id)
    {
      
    }

}
