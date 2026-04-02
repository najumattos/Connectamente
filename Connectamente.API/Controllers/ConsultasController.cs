using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;
using Connectamente.API.Services.ConsultaService;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

public class ConsultasController(IConsultaService service) : MainController
{
    /// <summary>
    /// Busca Todas Consultas MOCK
    /// </summary>
   [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<ConsultaDto>>> GetConsultas()
    {
        Console.WriteLine("CONSULTAS tao aqui sim, eu to vendo");

        var mockLista = new List<ConsultaDto>
       {
           new() { ConsultaId = "1", NomePsicologo = "Ana Julia (Mock)", NomePaciente="Tainara Vitoria"},
           new() { ConsultaId = "2", NomePsicologo = "Tainara Vitoria(Mock)", NomePaciente="Ana Julia "}
       };
        await Task.Delay(500); // Simula um delay de rede

        return Ok(mockLista);

    }

    /// <summary>
    /// Exibe Dados da Consulta MOCK
    /// </summary>     
    [ProducesResponseType(typeof(ConsultaDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ConsultaDto>> GetConsulta(string id)
    {
        Console.WriteLine($"Buscando detalhes do ID: {id}");
        var mockDetalhe = new ConsultaDto
        {
            NomePsicologo = id == "1" ? "Ana Julia (Mock)" : "Tainara Vitoria(Mock)",
            AnotacoesConsulta = "anoracoes da consultadadadadaaaaa adadadada daaddadadewegehggh fgfgfgfgfgf gfgfgfgf gf gf gf gf gf gf gfmgefekj ",

        };

        await Task.Delay(500); // Simula o tempo de resposta do banco

        return Ok(mockDetalhe);
    }
}
