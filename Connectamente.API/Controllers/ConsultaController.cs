using Connectamente.API.Models.ViewModel;
using Connectamente.API.Services.ConsultaService;
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
        public async Task<ActionResult<IEnumerable<ConsultaDto>>> GetConsultas([FromQuery] AuthAcessoDto auth)
        {
            var resposta = await service.BuscarConsultas(auth);

            return resposta.IsSuccess switch
            {
                true => Ok(resposta.Value),
                false when resposta.Error.Contains("permissão")
                      => StatusCode(StatusCodes.Status403Forbidden, resposta),
                _ => NotFound(resposta)
            };
        }

        /// <summary>
        /// Busca Dados da consulta
        /// </summary>     
        [ProducesResponseType(typeof(ConsultaDto), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaDto>> GetConsulta([FromQuery] AuthAcessoDto auth, string id)
        {
            var resposta = await service.BuscarConsultaPorId(auth, id);

            return resposta.IsSuccess switch
            {
                true => Ok(resposta.Value),
                false when resposta.Error.Contains("permissão")
                      => StatusCode(StatusCodes.Status403Forbidden, resposta),
                _ => NotFound(resposta)
            };
        }

        /// <summary>
        /// Alterar Status Consulta
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPatch("Arquivar")]
        public async Task<ActionResult> AlterarStatusConsulta([FromQuery] AuthAcessoDto auth, string id)
        {
            var resposta = await service.AlterarStatusConsulta(auth, id);
            return resposta switch
            {
                null => NotFound(resposta.Error),
                _ => NoContent()
            };
        }

    }
}
