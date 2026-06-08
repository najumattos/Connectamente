using Microsoft.AspNetCore.Mvc;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.PacienteDto;
using Connectamente.API.Services.Interfaces;
using FluentResults;

namespace Connectamente.API.Controllers;

public class PacientesController(IPacienteService service) : MainController
{
    /// <summary>
    /// Busca todos os pacientes de forma paginada e filtrada.
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<PacienteListaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("Buscar")]
    public async Task<IActionResult> GetPacientes([FromQuery] AuthAcessoDto auth)
    {
        Result<IEnumerable<PacienteListaDto>> resposta = await service.BuscarTodosPacientesAsync();

        if (resposta.IsFailed)
        {
            return TratarFalhas(resposta.ToResult());
        }

        return Ok(resposta.Value);
    }

    /// <summary>
    /// Busca a ficha detalhada de um paciente por ID.
    /// </summary>     
    [ProducesResponseType(typeof(PacienteDetalhesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPaciente([FromRoute] int id)
    {
        Result<PacienteDetalhesDto> resposta = await service.BuscarPacientePorIdAsync(id);

        if (resposta.IsFailed)
        {
            return TratarFalhas(resposta.ToResult());
        }

        return Ok(resposta.Value);
    }

    /// <summary>
    /// Arquiva logicamente um paciente no sistema.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch("{id:int}/arquivar")]
    public async Task<IActionResult> ArquivarPaciente([FromRoute] int id)
    {
        Result resposta = await service.ArquivarPacienteAsync(id);

        if (resposta.IsFailed)
        {
            return TratarFalhas(resposta);
        }

        return NoContent();
    }

    /// <summary>
    /// Centralizador privado para tradução de falhas do FluentResults para o ecossistema HTTP.
    /// </summary>
    private IActionResult TratarFalhas(Result resultado)
    {
        // Verifica se alguma mensagem de erro contém o gatilho de falta de permissão
        if (resultado.HasError(err => err.Message.Contains("permissao", StringComparison.OrdinalIgnoreCase)))
        {
            return StatusCode(StatusCodes.Status403Forbidden, resultado.Errors.Select(e => e.Message));
        }

        // Caso padrão para entidades não encontradas ou falhas genéricas de negócio
        return NotFound(resultado.Errors.Select(e => e.Message));
    }
}