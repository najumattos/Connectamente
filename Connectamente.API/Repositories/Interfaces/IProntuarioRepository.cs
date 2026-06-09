using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Contrato de persistência e consulta para a entidade <see cref="ProntuarioModel"/>.
/// </summary>
public interface IProntuarioRepository
{
    /// <summary>
    /// Fornece uma consulta avaliável (<see cref="IQueryable{ProntuarioModel}"/>) sobre a tabela de prontuários.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Este método não executa a consulta no banco de dados imediatamente. Ele expõe a árvore de expressões 
    /// do Entity Framework, permitindo que camadas superiores (como a camada de aplicação/serviço) adicionem 
    /// filtros (<c>.Where</c>), ordenações (<c>.OrderBy</c>) ou realizem projeções diretas para DTOs 
    /// utilizando o <c>.ProjectTo</c> do AutoMapper.
    /// </para>
    /// <para>
    /// <b>Nota de Performance:</b> A consulta só será convertida em SQL e executada no banco de dados quando 
    /// for materializada (ex: chamando <c>ToListAsync()</c>, <c>FirstOrDefaultAsync()</c> ou iterando sobre os dados).
    /// </para>
    /// </remarks>
    /// <returns>Uma estrutura <see cref="IQueryable{ProntuarioModel}"/> apontando para o fluxo de dados de prontuários.</returns>
    IQueryable<ProntuarioModel> ObterQueryable();

    /// <summary>
    /// Busca um prontuário pelo seu identificador primário de forma assíncrona.
    /// </summary>
    /// <param name="id">Identificador único do prontuário herdado de <see cref="EntityBase"/>.</param>
    /// <returns>A entidade do prontuário se encontrado; caso contrário, <see langword="null"/>.</returns>
    Task<ProntuarioModel?> ObterPorIdAsync(int id);

    /// <summary>
    /// Busca um prontuário carregando explicitamente seus relacionamentos pesados (Tratamentos, Atendimentos, Documentos).
    /// Ideal para visualização completa na tela de detalhes sem múltiplas requisições.
    /// </summary>
    /// <param name="id">Identificador único do prontuário.</param>
    /// <returns>A entidade completa do prontuário com suas coleções populadas se encontrado; caso contrário, <see langword="null"/>.</returns>
    Task<ProntuarioModel?> ObterComDetalhesPorIdAsync(int id);

    /// <summary>
    /// Adiciona um novo prontuário ao contexto de dados.
    /// </summary>
    /// <param name="prontuario">A entidade do prontuário a ser inserida.</param>
    Task AdicionarAsync(ProntuarioModel prontuario);

    /// <summary>
    /// Atualiza os dados de um prontuário existente que já está sendo rastreado pelo contexto.
    /// </summary>
    /// <param name="prontuario">A entidade do prontuário com os dados modificados.</param>
    void Atualizar(ProntuarioModel prontuario);

    /// <summary>
    /// Remove logicamente ou fisicamente o registro de prontuário do contexto.
    /// </summary>
    /// <param name="prontuario">A entidade do prontuário a ser removida.</param>
    void Remover(ProntuarioModel prontuario);

    /// <summary>
    /// Persiste todas as alterações pendentes no contexto de dados de forma assíncrona.
    /// </summary>
    /// <returns><see langword="true"/> se as alterações foram gravadas com sucesso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> CommitAsync();
}