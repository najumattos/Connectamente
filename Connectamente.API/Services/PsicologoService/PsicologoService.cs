using Connectamente.API.Data.Repositories.PsicologoRepository;
using Connectamente.API.Domain;
using Connectamente.API.Enums;
using Connectamente.API.Models.ViewModel;
using NuGet.Protocol.Core.Types;

namespace Connectamente.API.Services.PsicologoService;

public class PsicologoService(IPsicologoRepository repository) : IPsicologoService
{
    /// <summary>
    /// Retorna Psicologo se autorizado
    /// </summary>
    public async Task<Result<PsicologoDto>> BuscarPsicologoPorId(AuthAcessoDto authAcessoDto, string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return Result<PsicologoDto>.Failure("ID do psicologo é inválido ou não informado.");
        }
        var resposta = await repository.BuscarPsicologoPorId(id);

        if (!resposta.IsSuccess)
        {
            return Result<PsicologoDto>.Failure(resposta.Error);
        }
        var psicologo = resposta.Value;
        var acesso = VerificarPermissao(authAcessoDto, psicologo.Id);
        if (acesso == false)
        {
            return Result<PsicologoDto>.Failure("O usuário não possui permissão para acessar os dados deste psicologo.");
        }
        return Result<PsicologoDto>.Success(psicologo);
    }

    /// <summary>
    /// Retorna TodosPsicologos se TipoPerfilEnum.Coordenador
    /// </summary>
    public async Task<Result<IEnumerable<UsuarioListaDto>>> BuscarPsicologos(AuthAcessoDto authAcessoDto)
    {
        var resposta = authAcessoDto.TipoPerfil switch
        {
            TipoPerfilEnum.Coordenador => await repository.BuscarTodosPsicologos(),
            _ => Result<IEnumerable<UsuarioListaDto>>.Failure("Apenas Coordenadores podem acessar a lista de psicologos")
        };
        if (!resposta.IsSuccess)
        {
            return Result<IEnumerable<UsuarioListaDto>>.Failure(resposta.Error);
        }

        return Result<IEnumerable<UsuarioListaDto>>.Success(resposta.Value);

    }

    /// <summary>
    /// Coordenador desativa Psicologo
    /// </summary>
    public async Task<Result<bool>> DesativarPsicologo(AuthAcessoDto authAcessoDto, string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return Result<bool>.Failure("ID do psicologo é inválido ou não informado.");
        }

        if(authAcessoDto.TipoPerfil != TipoPerfilEnum.Coordenador){
            return Result<bool>.Failure("Somente coordenadores podem desativar um psicologo");
        }
        var resposta = await repository.DesativarPsicologo(id);
        

        if (!resposta.IsSuccess)
        {
            return Result<bool>.Failure(resposta.Error);
        }

        return Result<bool>.Success(true);
    }

    #region Metodos Privados
    /// <summary>
    /// Verifica permissão para acessar os dados de um psicologo
    /// </summary>
    private static bool VerificarPermissao(AuthAcessoDto auth, string psicologoId)
     => auth.TipoPerfil switch
     {
         TipoPerfilEnum.Coordenador => true,
         TipoPerfilEnum.Aluno => auth.IdPsicologo == psicologoId,
         _ => false
     };
    #endregion
}

