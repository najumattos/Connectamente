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
    public async Task<Result<PsicologoDto>> BuscarPsicologoPorId(AuthAcessoDto authAcessoDto, string idPsicologo)
    {
        if (string.IsNullOrWhiteSpace(idPsicologo))
        {
            return Result<PsicologoDto>.Failure("ID do psicologo é inválido ou não informado.");
        }
        var resposta = await repository.BuscarPsicologoPorId(idPsicologo);

        if (!resposta.IsSuccess)
        {
            return Result<PsicologoDto>.Failure(resposta.Error);
        }
        var psicologo = resposta.Value;
        var acesso = VerificarPermissao(authAcessoDto, psicologo.PsicologoId);
        if (acesso == false)
        {
            return Result<PsicologoDto>.Failure("O usuário não possui permissão para acessar os dados deste psicologo.");
        }
        return Result<PsicologoDto>.Success(psicologo);
    }

    /// <summary>
    /// Retorna TodosPsicologos se TipoPerfilEnum.Coordenador
    /// </summary>
    public async Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPsicologos(AuthAcessoDto authAcessoDto)
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
    /// Verifica permissão para acessar os dados de um psicologo
    /// </summary>
    private static bool VerificarPermissao(AuthAcessoDto auth, string psicologoId)
     => auth.TipoPerfil switch
     {
         TipoPerfilEnum.Coordenador => true,
         TipoPerfilEnum.Aluno => auth.IdPsicologo == psicologoId,
         _ => false
     };
}

