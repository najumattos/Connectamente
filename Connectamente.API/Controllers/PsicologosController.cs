using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Services.PsicologoService;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;

namespace Connectamente.API.Controllers;

public class PsicologosController() : MainController
{

    /// <summary>
    /// Busca Todos Psicologos MOCK
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<FichaUsuarioDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<FichaUsuarioDto>>> GetPsicologos()
    {       
        Console.WriteLine("PSICOLOGOS tao aqui sim, eu to vendo");
      
        var mockLista = new List<FichaUsuarioDto>
       {
           new() { Id = "1", NomeCompleto = "Ana Julia (Mock)" },
           new() { Id = "2", NomeCompleto = "Tainara Vitoria(Mock)"}
       };        
        await Task.Delay(500); // Simula um delay de rede

        return Ok(mockLista);
    }

    /// <summary>
    /// Exibe Dados do Psicologo MOCK
    /// </summary>     
    [ProducesResponseType(typeof(PsicologoDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PsicologoDto>> GetPsicologo(string id)
    {      
        Console.WriteLine($"Buscando detalhes do ID: {id}");
        var mockDetalhe = new PsicologoDto
        {            
            NomeCompleto = id == "1" ? "Ana Julia (Mock)" : "Tainara Vitoria(Mock)",
            CRP = id == "1" ? "1" : "2",
        };

        await Task.Delay(500); // Simula o tempo de resposta do banco

        return Ok(mockDetalhe);
    }
}
