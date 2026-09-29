using Connectamente.API.DTOs.ProntuarioDto;
using Connectamente.API.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;
public class ProntuarioController(IProntuarioService service) : MainController
{
    /// <summary>
    /// Busca todos os prontuários de forma geral.
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<ProntuarioListaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("Buscar")] // GET api/prontuarios
    public async Task<IActionResult> GetProntuarios()
    {
        Result<IEnumerable<ProntuarioListaDto>> resposta = await service.BuscarTodosProntuariosAsync();

        if (resposta.IsFailed)
        {
            return TratarFalhas(resposta.ToResult());
        }

        return Ok(resposta.Value);
    }

    /// <summary>
    /// Busca todos os prontuários associados a um psicólogo específico.
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<ProntuarioListaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("psicologo/{id}")] // 🛠️ CORREÇÃO: Removido o ':string' inválido. GET api/prontuarios/psicologo/guid-id
    public async Task<IActionResult> GetProntuariosPorPsicologo([FromRoute] string id)
    {
        Result<IEnumerable<ProntuarioListaDto>> resposta = await service.BuscarProntuariosPorIdPsicologoAsync(id);

        if (resposta.IsFailed)
        {
            return TratarFalhas(resposta.ToResult());
        }

        return Ok(resposta.Value);
    }

    /// <summary>
    /// Busca o prontuário detalhado de um paciente pelo ID do prontuário.
    /// </summary>     
    [ProducesResponseType(typeof(ProntuarioDetalhesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:int}")] // GET api/prontuarios/5
    public async Task<IActionResult> GetProntuarioPorId([FromRoute] int id)
    {
        Result<ProntuarioDetalhesDto> resposta = await service.BuscarProntuarioPorIdAsync(id);

        if (resposta.IsFailed)
        {
            return TratarFalhas(resposta.ToResult());
        }

        return Ok(resposta.Value);
    }

    /// <summary>
    /// Arquiva logicamente um prontuário no sistema.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPatch("{id:int}/arquivar")] // PATCH api/prontuarios/5/arquivar
    public async Task<IActionResult> ArquivarProntuario([FromRoute] int id)
    {
        Result resposta = await service.ArquivarProntuarioAsync(id);

        if (resposta.IsFailed)
        {
            return TratarFalhas(resposta);
        }

        return NoContent();
    }

  }