using Connectamente.API.Models;

namespace Connectamente.API.Repositories.Interfaces;

/// <summary>
/// Interface para o controle e persistência de metadados dos Documentos Clínicos emitidos.
/// </summary>
public interface IDocumentoClinicoRepository
{
    /// <summary>
    /// Filtra documentos criados por ou destinados a pacientes sob a tutela de um psicólogo.
    /// </summary>
    /// <param name="psicologoId">O ID do psicólogo emitente ou responsável.</param>
    Task<IEnumerable<DocumentoClinicoModel>> BuscarPorIdPsicologoAsync(string psicologoId);

/// <summary>
    /// Busca documentos de um prontuario
    /// </summary>
    /// <param name="prontuarioId">O ID do prontuario ao quao o documento pertence</param>
    Task<IEnumerable<DocumentoClinicoModel>> BuscarPorprontuarioIdAsync(int prontuarioId);

    /// <summary>
    /// Altera dados referenciais de um documento clínico.
    /// </summary>
    /// <param name="documentoClinico">A instância modificada.</param>
    Task EditarAsync(DocumentoClinicoModel documentoClinico);

    /// <summary>
    /// Salva os metadados de um novo documento gerado na API.
    /// </summary>
    /// <param name="documentoClinico">Os dados do documento.</param>
    Task<bool> AddDocumentoClinicoAsync(DocumentoClinicoModel documentoClinico);
   

    /// <summary>
    /// Exclui o registro do documento do banco de dados (não remove o arquivo do disco/storage automaticamente).
    /// </summary>
    /// <param name="id">O ID do documento.</param>
    Task<bool> ExcluirAsync(int id);

        /// <summary>
    /// Arquiva o registro do documento do banco de dados (remove o arquivo do disco/storage automaticamente).
    /// </summary>
    /// <param name="id">O ID do documento.</param>
    Task<bool> ArquivarAsync(int id);

        /// <summary>
    /// Retorna os detalhes de um documento clinico com os dados do Prontuário, Paciente e Documentos Clínicos gerados.
    /// </summary>
    /// <param name="id">O ID do documento clinico.</param>
    Task<DocumentoClinicoModel?> BuscarDetalhesAsync(int id);
}