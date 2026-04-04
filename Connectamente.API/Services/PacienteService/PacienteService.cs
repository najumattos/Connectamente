using Connectamente.API.Data;
using Connectamente.API.Domain;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Services.PacienteService;

public class PacienteService() : IPacienteService
{  

    public async Task<Result<UsuarioListaDto>> BuscarPacientes(AuthAcessoDto authAcessoDto)
    {
        var acesso = authAcessoDto.TipoPerfil switch
        {
            TipoPerfilEnum.Coordenador => await BuscarPacientesParaCoordenador(),
            TipoPerfilEnum.Aluno => await BuscarPacientesParaAluno(),
            _ => Result<UsuarioListaDto>.Failure("Perfil não identificado ou sem permissão.")
        };

        if (!acesso.IsSuccess)
        {
            return acesso;//Result<UsuarioListaDto>.Failure("Perfil não identificado ou sem permissão.")
        }

        return acesso; //Result<UsuarioListaDto>.IsSucess(acesso.Value)

    }

    private Task<Result<UsuarioListaDto>> BuscarPacientesParaCoordenador()
    {
        throw new NotImplementedException();
      
           
    }
    private Task<Result<UsuarioListaDto>> BuscarPacientesParaAluno()
    {
        throw new NotImplementedException();


    }

    public Task<Result<UsuarioListaDto>> BuscarPacientePorId(AuthAcessoDto authAcessoDto, string idPaciente)
    {
        throw new NotImplementedException();
    }
}
