using Connectamente.API.Data;
using Connectamente.API.Data.Repositories.PacienteRepository;
using Connectamente.API.Domain;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Models.ViewModel;
using Connectamente.API.Usuario;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Services.PacienteService;

public class PacienteService(IPacienteRepository repository) : IPacienteService
{
    /// <summary>
    /// Retorna TodosPacientes com base no tipoPerfilEnum
    /// </summary>
    public async Task<Result<IEnumerable<UsuarioListaDto>>> BuscarPacientes(AuthAcessoDto authAcessoDto)
    {

        var resposta = authAcessoDto.TipoPerfil switch
        {
            TipoPerfilEnum.Coordenador => await repository.BuscarTodosPacientes(),
            TipoPerfilEnum.Aluno => await repository.BuscarPacientesPorPsicologo(authAcessoDto.IdPsicologo),
            _ => Result<IEnumerable<UsuarioListaDto>>.Failure("Perfil não identificado ou sem permissão.")
        };

        if (!resposta.IsSuccess)
        {
            return Result<IEnumerable<UsuarioListaDto>>.Failure(resposta.Error);
        }

        return Result<IEnumerable<UsuarioListaDto>>.Success(resposta.Value); 

    }

    /// <summary>
    /// Retorna Paciente com base no tipoPerfilEnum
    /// </summary>
    public async Task<Result<PacienteDto>> BuscarPacientePorId(AuthAcessoDto authAcessoDto, string idPaciente)
    {
        if (string.IsNullOrWhiteSpace(idPaciente))
        {
            return Result<PacienteDto>.Failure("ID do paciente é inválido ou não informado.");
        }
        var resposta = await repository.BuscarPacientePorId(idPaciente);

        if (!resposta.IsSuccess)
        {
            return Result<PacienteDto>.Failure(resposta.Error);
        }
        var paciente = resposta.Value;

        var acesso = VerificarPermissao(authAcessoDto, paciente.PsicologoResponsavelId);
        if (acesso == false)
        {
            return Result<PacienteDto>.Failure("O usuário não possui permissão para acessar os dados deste paciente.");
        }
        return Result<PacienteDto>.Success(paciente);
    }

    /// <summary>
    /// Verifica permissão para acessar os dados de um paciente
    /// </summary>
    private static bool VerificarPermissao(AuthAcessoDto auth, string psicologoResponsavelId)
     => auth.TipoPerfil switch
        {
            TipoPerfilEnum.Coordenador => true,
            TipoPerfilEnum.Aluno => auth.IdPsicologo == psicologoResponsavelId,
            _ => false
        };
    
 
}

/*
 * VerificarPermissaoAcademica() protege o sistema contra um ataque comum chamado IDOR (Insecure Direct Object Reference).
 * Sem essa validação, bastaria um Aluno trocar o ID na URL para ver dados de pacientes de outros colegas.
 * Isso é essencial para conformidade com leis de proteção de dados (como a LGPD no Brasil)
 * 
 */