using Connectamente.API.DTOs;
using Connectamente.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers
{
    public class ConsultaController(IConsultaService service)  : MainController
    {
        /// <summary>
        /// Busca Todas Consultas
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<ConsultaDto>), StatusCodes.Status200OK)]
        [HttpGet("Buscar")]
        public async Task<ActionResult<IEnumerable<ConsultaDto>>> GetConsultas()
        {
            var resposta = await service.BuscarTodasConsultas();

            return resposta.IsSuccess switch
            {
                true => Ok(resposta.Value),
                
                     
                _ => NotFound(resposta)
            };
        }

        /// <summary>
        /// Busca Dados da consulta
        /// </summary>     
        [ProducesResponseType(typeof(ConsultaDto), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaDto>> GetConsulta(string id)
        {
            var resposta = await service.BuscarConsultaPorId(id);

            return resposta.IsSuccess switch
            {
                true => Ok(resposta.Value),
               
                _ => NotFound(resposta)
            };
        }

        /// <summary>
        /// Alterar Status Consulta
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPatch("Arquivar")]
        public async Task<ActionResult> AlterarStatusConsulta(string id)
        {
            var resposta = await service.AlterarStatusConsulta(id);
            return resposta switch
            {
              
                _ => NoContent()
            };
        }

    }
}
