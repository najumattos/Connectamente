using Connectamente.API.DTOs.UsersDTOs;
using Connectamente.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Connectamente.API.Services.ProntuarioService;

namespace Connectamente.API.Controllers;

public class ProntuariosController(IProntuarioService service) : MainController
{

    /// <summary>
    /// Busca Todos Prontuarios MOCK
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<ProntuarioBasicoDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<FichaUsuarioDto>>> GetProntuarios()
    {
        Console.WriteLine("PRONTUARIOS tao aqui sim, eu to vendo");

        var mockLista = new List<ProntuarioBasicoDto>
       {
           new() { ProntuarioId = "1", NomePsicologo = "Ana Julia (Mock)", TipoProntuario= Enums.TipoProntuarioEnum.Adulto },
           new() { ProntuarioId = "2", NomePsicologo = "Tainara Vitoria(Mock)", TipoProntuario= Enums.TipoProntuarioEnum.Infantil }
       };
        await Task.Delay(500); // Simula um delay de rede

        return Ok(mockLista);

    }

    /// <summary>
    /// Exibe Dados do Prontuario MOCK
    /// </summary>     
    [ProducesResponseType(typeof(ProntuarioDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProntuarioDto>> GetProntuario(string id)
    {
        Console.WriteLine($"Buscando detalhes do ID: {id}");
        var mockDetalhe = new ProntuarioDto
        {
            NomePsicologo = id == "1" ? "Ana Julia (Mock)" : "Tainara Vitoria(Mock)",
            NomePaciente = "40028922",
            UltimaAtualizacao = new DateTime(2002, 4, 1),
            DataCriacao = new DateTime(2002, 1, 4),
        };

        await Task.Delay(500); // Simula o tempo de resposta do banco

        return Ok(mockDetalhe);
    }
}
