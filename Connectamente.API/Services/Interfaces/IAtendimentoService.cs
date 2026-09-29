using Connectamente.API.DTOs.AtendimentoDto;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

public interface IAtendimentoService
{
    Task<Result> AdicionarAtendimentoAsync(AtendimentoAdicionarDto dto);

   Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarTodosAtendimentosDaSemanaAsync();
   Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarAtendimentosDaSemanaPorPsicologoAsync(string id);
   Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarTodosAtendimentosAsync();
   Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarAtendimentosPorPsicologoAsync(string id);
   Task<Result> AtualizarAtendimentoAsync(AtendimentoAtualizarDto dto);
   Task<Result<AtendimentoDetalhesDto>> BuscarAtendimentoPorIdAsync(int id);


    

}