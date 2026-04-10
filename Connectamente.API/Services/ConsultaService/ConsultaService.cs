using Connectamente.API.Data.Repositories.ConsultaRepository;
using Connectamente.API.Domain;
using Connectamente.API.Enums;
using Connectamente.API.Models.ViewModel;
using NuGet.Protocol.Core.Types;

namespace Connectamente.API.Services.ConsultaService;

public class ConsultaService(IConsultaRepository repository) : IConsultaService
{
    /// <summary>                                                 
    /// 
    /// </summary>
    public Task<Result<bool>> AlterarStatusConsulta(AuthAcessoDto authAcessoDto, string id)
    {
        //dto de entrada
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca Consulta com base na autorização
    /// </summary>
    public async Task<Result<ConsultaDto>> BuscarConsultaPorId(AuthAcessoDto authAcessoDto, string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return Result<ConsultaDto>.Failure("ID da consulta é inválido ou não informado.");
        }
        var resposta = await repository.BuscarConsultaPorId(id);

        if (!resposta.IsSuccess)
        {
            return Result<ConsultaDto>.Failure(resposta.Error);
        }
        var consulta = resposta.Value;

        var acesso = VerificarPermissao(authAcessoDto, consulta.PsicologoResponsavelId);
        if (acesso == false)
        {
            return Result<ConsultaDto>.Failure("O usuário não possui permissão para acessar os dados desta consulta.");
        }
        return Result<ConsultaDto>.Success(consulta);
    }

    /// <summary>
    /// Busca Consultas com base na autorização
    /// </summary>
    public async Task<Result<IEnumerable<ConsultaDto>>> BuscarConsultas(AuthAcessoDto authAcessoDto)
    {
        var resposta = authAcessoDto.TipoPerfil switch
        {
            TipoPerfilEnum.Coordenador => await repository.BuscarTodasConsultas(),
            TipoPerfilEnum.Aluno => await repository.FiltrarConsultasPorPsicologo(authAcessoDto.IdPsicologo),
            _ => Result<IEnumerable<ConsultaDto>>.Failure("Perfil não identificado ou sem permissão.")
        };

        if (!resposta.IsSuccess)
        {
            return Result<IEnumerable<ConsultaDto>>.Failure(resposta.Error);
        }

        return Result<IEnumerable<ConsultaDto>>.Success(resposta.Value);
    }

    #region Metodos Privados    
    /// <summary>
    /// Verifica permissão do usuario
    /// </summary>
    private static bool VerificarPermissao(AuthAcessoDto auth, string psicologoResponsavelId)
     => auth.TipoPerfil switch
     {
         TipoPerfilEnum.Coordenador => true,
         TipoPerfilEnum.Aluno => auth.IdPsicologo == psicologoResponsavelId,
         _ => false
     };

    #endregion
}