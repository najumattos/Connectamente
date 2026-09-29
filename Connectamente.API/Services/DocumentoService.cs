using AutoMapper;
using Connectamente.API.Data;
using Connectamente.API.DTOs.DocumentoClinicoDto;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;

namespace Connectamente.API.Services;

public class DocumentoService(IDocumentoClinicoRepository repository,
IFileService fileService, 
IAtendimentoService atendimentoService,
IMapper mapper,
    ILogger<DocumentoService> logger) : IDocumentoService
{
    public async Task<Result> AddDocumentoClinicoAsync(DocumentoAdicionarDto dto, IFormFile arquivoUpload)
    {
          if (dto == null) return Result.Fail("Documento clínico inválido ou não informado.");
        string? caminhoFotoSalva = null;
        try
        {
            if (arquivoUpload != null && arquivoUpload.Length > 0)
            {
                caminhoFotoSalva = await fileService.SaveFileAsync(arquivoUpload, "docsClinicosAnexados");
                dto.CaminhoArquivo = caminhoFotoSalva;                
            }
            var atendimentoResponse = await atendimentoService.BuscarAtendimentoPorIdAsync(dto.AtendimentoId);
            var atendimento = atendimentoResponse.Value;
           
             dto.AtendimentoId = atendimento.Id; 
             dto.ProntuarioId = atendimento.Prontuario.Id;
             dto.NumeroProntuario = atendimento.NumeroProntuario;
             dto.UsuarioResponsavelId = IdentityConstants.Admin.Id;//alterar para o id do usuario logado
             
            var response = await repository.AddDocumentoClinicoAsync(mapper.Map<DocumentoClinicoModel>(dto));
            return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao tentar adicionar documento no banco de dados.");

            if (!string.IsNullOrEmpty(caminhoFotoSalva))
            {
                await fileService.DeleteFileAsync(caminhoFotoSalva);
            }

            return Result.Fail("Não foi possível cadastrar o documento no momento.");
        }
    }

    public async Task<Result> ArquivarDocumentoAsync(int id)
    {
          await repository.ArquivarAsync(id);
            return Result.Ok();
    }


    public async Task<Result<DocumentoDetalhesDto>> BuscarDocumentoPorIdAsync(int id)
    {
        var documentoEntidade = await repository.BuscarDetalhesAsync(id);
       if (documentoEntidade == null)
        {
           return Result.Fail<DocumentoDetalhesDto>("Documento clínico não encontrado.");
        }
        
        var documentoDto = mapper.Map<DocumentoDetalhesDto>(documentoEntidade);   
        return Result.Ok(documentoDto);
    }

    public async Task<Result> ExcluirDocumentoAsync(int id)
    {
         await repository.ExcluirAsync(id);
            return Result.Ok();
    }
}