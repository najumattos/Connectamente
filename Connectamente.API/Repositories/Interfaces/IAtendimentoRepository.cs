using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Interface para gerenciamento e persistência de sessões de Atendimentos/Agendamentos.
/// </summary>
public interface IAtendimentoRepository
{
    /// <summary>
    /// Obtém a listagem completa de todos os atendimentos cadastrados na clínica.
    /// </summary>
    Task<IEnumerable<AtendimentoModel>> BuscarTodosAsync();

    /// <summary>
    /// Filtra as sessões de atendimento vinculadas a prontuários que pertencem a um psicólogo específico.
    /// </summary>
    /// <param name="psicologoId">O ID do psicólogo logado ou responsável.</param>
    Task<IEnumerable<AtendimentoModel>> BuscarPorIdPsicologoAsync(string psicologoId);

    /// <summary>
    /// Retorna os detalhes de um atendimento com os dados do Prontuário, Paciente e Documentos Clínicos gerados.
    /// </summary>
    /// <param name="id">O ID do atendimento.</param>
    Task<AtendimentoModel?> BuscarDetalhesAsync(int id);

    /// <summary>
    /// Modifica o estado ou informações de um atendimento (ex: alterar status para Realizado ou Cancelado).
    /// </summary>
    /// <param name="atendimento">O objeto modificado.</param>
    Task<bool> EditarAsync(AtendimentoModel atendimento);

    /// <summary>
    /// Reserva ou agenda um novo atendimento no sistema.
    /// </summary>
    /// <param name="atendimento">Os dados do novo agendamento.</param>
    Task<AtendimentoModel> AdicionarAsync(AtendimentoModel atendimento);

    /// <summary>
    /// Executa o cancelamento ou arquivamento do atendimento mudando seu estado interno.
    /// </summary>
    /// <param name="id">O ID do atendimento.</param>
    Task<bool> ArquivarAsync(int id);

    /// <summary>
    /// Remove permanentemente o registro da sessão de atendimento do banco de dados.
    /// </summary>
    /// <param name="id">O ID do atendimento.</param>
    Task<bool> ExcluirAsync(int id);

    Task<IEnumerable<AtendimentoModel>> BuscarTodosAtendimentosDaSemanaAsync();
   Task<IEnumerable<AtendimentoModel>> BuscarAtendimentosDaSemanaPorPsicologoAsync(string id);
}