using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Define o contrato de persistência e acesso a dados para a entidade de Prontuários.
/// </summary>
public interface IProntuarioRepository
{
    /// <summary>
/// Obtém de forma assíncrona todos os prontuários ativos que não possuem nenhum vínculo ativo com um psicólogo.
/// </summary>
/// <param name="cancellationToken">Token de cancelamento para interromper a operação assíncrona, se necessário.</param>
/// <returns>
/// Uma tarefa que representa a operação assíncrona. O resultado da tarefa contém uma coleção 
/// de <see cref="ProntuarioModel"/> sem profissionais vinculados, incluindo os dados de seus respectivos pacientes.
/// </returns>
/// <remarks>
/// Esta consulta utiliza <c>AsNoTracking</c> para otimização de performance (read-only) e filtra 
/// os estados nulos da propriedade <c>Ativo</c> assumindo o valor padrão falso.
/// </remarks>
Task<IEnumerable<ProntuarioModel>> BuscarProntuariosSemPsicologoAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// Recupera todos os prontuários registrados no banco de dados 
    /// </summary>
    /// <returns>Uma coleção de <see cref="ProntuarioModel"/> </returns>
    Task<IEnumerable<ProntuarioModel>> BuscarTodosAsync();

    /// <summary>
    /// Obtém o grafo completo de um prontuário específico por seu ID, incluindo todas as suas 
    /// dependências e coleções agregadas relevantes (Atendimentos, Documentos, Tratamentos Anteriores e Vínculos).
    /// </summary>
    /// <remarks>
    /// <b>Nota de Performance:</b> Este método realiza múltiplos JOINs internos no banco de dados 
    /// e deve ser utilizado estritamente para visualizações detalhadas ou auditoria.
    /// </remarks>
    /// <param name="id">O identificador numérico interno do prontuário.</param>
    /// <returns>A instância populada de <see cref="ProntuarioModel"/> ou <see langword="null"/> se não for encontrado.</returns>
    Task<ProntuarioModel?> BuscarDetalhesAsync(int id);

    /// <summary>
    /// Busca os prontuários vinculados ativamente a um psicólogo responsável específico.
    /// </summary>
    /// <param name="psicologoId">O identificador único (GUID/string) do psicólogo no Identity.</param>
    /// <returns>Uma coleção de <see cref="ProntuarioModel"/> associados ao profissional informado.</returns>
    Task<IEnumerable<ProntuarioModel>> BuscarPorIdPsicologoAsync(string psicologoId);

    /// <summary>
    /// Persiste as modificações de estado realizadas em um prontuário existente.
    /// </summary>
    /// <param name="prontuario">A instância do prontuário modificada contendo os novos dados.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task EditarAsync(ProntuarioModel prontuario);

    /// <summary>
    /// Registra e persiste um novo prontuário no banco de dados.
    /// </summary>
    /// <param name="prontuario">A nova instância de prontuário a ser inserida.</param>
    /// <returns>O prontuário persistido com seu identificador auto-incremento preenchido.</returns>
    Task<ProntuarioModel> AdicionarAsync(ProntuarioModel prontuario);

    /// <summary>
    /// Verifica se já existe um prontuario cadastrado com o numeroProntuario informado.
    /// </summary>
    /// <param name="numeroProntuario">O numeroProntuario a ser validado.</param>
    /// <returns><see langword="true"/> se o numeroProntuario já estiver em uso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ExisteNumeroProntuarioAsync(string numeroProntuario);

    /// <summary>
    /// Verifica se já existe um prontuario cadastrado 
    /// </summary>
    /// <param name="id">O id a ser validado.</param>
    /// <returns><see langword="true"/> se existir; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ExisteProntuarioAsync(int id);

    /// <summary>
    /// Executa o arquivamento lógico de um prontuário, alterando sua situação de atividade sem remover o registro fisicamente.
    /// </summary>
    /// <remarks>
    /// Esta operação atualiza internamente a propriedade <c>SituacaoProntuario</c> para Inativo/Arquivado 
    /// e atualiza os metadados de modificação da entidade base.
    /// </remarks>
    /// <param name="id">O identificador numérico interno do prontuário a ser arquivado.</param>
    /// <returns><see langword="true"/> se o arquivamento foi bem-sucedido; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ArquivarAsync(int id);

    /// <summary>
    /// Remove fisicamente o registro do prontuário do banco de dados.
    /// </summary>
    /// <remarks>
    /// <b>Risco de Exclusão:</b> Esta operação falhará catastroficamente ou lançará uma exceção se existirem 
    /// dependências de chave estrangeira ativas em tabelas com comportamento de deleção restritiva (ex: Documentos ou Atendimentos).
    /// </remarks>
    /// <param name="id">O identificador numérico interno do prontuário a ser removido fisicamente.</param>
    /// <returns><see langword="true"/> se o registro foi removido com sucesso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ExcluirAsync(int id);

        /// <summary>
    /// Vincular Psicologo e Prontuario
    /// </summary>
     public Task<bool> VincularPsicologoProntuarioAsync(VinculoProntuarioPsicologoModel model);
}