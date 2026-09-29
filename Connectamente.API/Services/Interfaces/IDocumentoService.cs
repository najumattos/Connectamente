using Connectamente.API.DTOs.DocumentoClinicoDto;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

public interface IDocumentoService
{
        Task<Result<DocumentoDetalhesDto>> BuscarDocumentoPorIdAsync(int id);
     Task<Result> AddDocumentoClinicoAsync(DocumentoAdicionarDto dto, IFormFile arquivoUpload);

        Task<Result> ArquivarDocumentoAsync(int id);
        Task<Result> ExcluirDocumentoAsync(int id);
}