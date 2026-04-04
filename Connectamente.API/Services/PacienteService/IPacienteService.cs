using Connectamente.API.Domain;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Services.PacienteService;

public interface IPacienteService
{
    public Task<Result<UsuarioListaDto>> BuscarPacientes(AuthAcessoDto authAcessoDto);
    public Task<Result<UsuarioListaDto>> BuscarPacientePorId(AuthAcessoDto authAcessoDto, string idPaciente);
}
