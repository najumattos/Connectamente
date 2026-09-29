
using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Interface de persistência e consultas para a entidade de Pacientes.
/// </summary>
public interface IPacienteRepository
{
/// <summary>
    /// Recupera todos os pacientes gravados no banco de dados sem paginação.
    /// </summary>
    /// <returns>Uma lista contendo todos os registros de <see cref="PacienteModel"/>.</returns>
    Task<IEnumerable<PacienteModel>> BuscarTodosAsync();

Task<IEnumerable<PacienteModel>> BuscarPorIdPsicologoAsync(string psicologoId);

    /// <summary>
    /// Obtém um paciente carregando avidamente seus objetos de valor internos (Identificacao, Endereco) e relacionamentos.
    /// </summary>
    /// <param name="id">O identificador numérico do paciente.</param>
    /// <returns>A instância de <see cref="PacienteModel"/> preenchida ou <see langword="null"/> caso não exista.</returns>
    Task<PacienteModel?> BuscarDetalhesAsync(int id);

    /// <summary>
    /// Atualiza o registro e as informações cadastrais de um paciente existente.
    /// </summary>
    /// <param name="paciente">A instância com as modificações aplicadas.</param>
    Task EditarAsync(PacienteModel paciente);

    /// <summary>
    /// Insere um novo registro de paciente no banco de dados.
    /// </summary>
    /// <param name="paciente">A nova entidade a ser inserida.</param>
    /// <returns>A entidade persistida com seu ID gerado.</returns>
    Task<PacienteModel> AdicionarAsync(PacienteModel paciente);

    /// <summary>
    /// Executa o arquivamento lógico de um paciente no sistema.
    /// </summary>
    /// <param name="id">O ID do paciente a ser modificado.</param>
    /// <returns><see langword="true"/> se a alteração foi persistida com sucesso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ArquivarAsync(int id);

    /// <summary>
    /// Remove fisicamente o registro do paciente do banco de dados.
    /// </summary>
    /// <param name="id">O ID do paciente a ser removido.</param>
    /// <returns><see langword="true"/> se a exclusão foi concluída; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ExcluirAsync(int id);

    /// <summary>
    /// Verifica se já existe um paciente cadastrado com o CPF informado.
    /// </summary>
    /// <param name="cpf">O CPF a ser validado.</param>
    /// <returns><see langword="true"/> se o CPF já estiver em uso; caso contrário, <see langword="false"/>.</returns>
    Task<bool> ExisteCpfAsync(string cpf);

}