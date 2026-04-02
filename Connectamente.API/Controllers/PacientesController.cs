using Microsoft.AspNetCore.Mvc;
using Connectamente.API.Services.PacienteService;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;

namespace Connectamente.API.Controllers;

public class PacientesController(IPacienteService service) : MainController
{

    /// <summary>
    /// Busca Todos Pacientes MOCK
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<FichaUsuarioDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<FichaUsuarioDto>>> GetPacientes()
    {
        Console.WriteLine("PACIENTES tao aqui sim, eu to vendo");

        var mockLista = new List<FichaUsuarioDto>
       {
           new() { UsuarioId = "1", NomeCompleto = "Ana Julia (Mock)" },
           new() { UsuarioId = "2", NomeCompleto = "Tainara Vitoria(Mock)"}
       };
        await Task.Delay(500); // Simula um delay de rede

        return Ok(mockLista);

    }

    /// <summary>
    /// Exibe Dados do Paciente MOCK
    /// </summary>     
    [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PacienteDto>> GetPaciente(string id)
    {
        Console.WriteLine($"Buscando detalhes do ID: {id}");
        var mockDetalhe = new PacienteDto
        {
            NomeCompleto = id == "1" ? "Ana Julia (Mock)" : "Tainara Vitoria(Mock)",
            ContatoEmergencia = "40028922",
            Historico = "Historico em se meter em encrenca",
        };

        await Task.Delay(500); // Simula o tempo de resposta do banco

        return Ok(mockDetalhe);
    }

}
