using AutoMapper;
using AutoMapper.QueryableExtensions;
using Connectamente.API.DTOs.ProntuarioDto;
using Connectamente.API.Enums;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Services;

public class ProntuarioService(
    IProntuarioRepository repository, 
    IMapper mapper) : IProntuarioService
{
    public async Task<Result<IEnumerable<ProntuarioListaDto>>> BuscarTodosProntuariosAsync()
    {
        // 🧠 Uso de ProjectTo: O AutoMapper monta o SELECT apenas com os campos necessários do DTO,
        // e o AsNoTracking desativa o cache de memória do EF, maximizando a performance.
        var prontuarios = await repository.ObterQueryable()
            .AsNoTracking()
            .ProjectTo<ProntuarioListaDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return Result.Ok<IEnumerable<ProntuarioListaDto>>(prontuarios);
    }

    public async Task<Result<IEnumerable<ProntuarioListaDto>>> BuscarTodosProntuariosDeUmPsicologoAsync(string idPsicologo)
    {
        if (string.IsNullOrWhiteSpace(idPsicologo))
        {
            return Result.Fail("O identificador do psicólogo é inválido ou não foi informado.");
        }

        // O filtro Where é aplicado diretamente no banco de dados antes da materialização
        var prontuarios = await repository.ObterQueryable()
            .AsNoTracking()
            .Where(p => p.PsicologoResponsavelId == idPsicologo)
            .ProjectTo<ProntuarioListaDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return Result.Ok<IEnumerable<ProntuarioListaDto>>(prontuarios);
    }

    public async Task<Result<ProntuarioDetalhesDto>> BuscarProntuarioPorIdAsync(int id)
    {
        if (id <= 0)
        {
            return Result.Fail("O identificador do prontuário informado é inválido.");
        }

        // Projeta diretamente para o DTO de detalhes puxando os dados do paciente e psicólogo de forma otimizada
        var prontuarioDto = await repository.ObterQueryable()
            .AsNoTracking()
            .Where(p => p.Id == id)
            .ProjectTo<ProntuarioDetalhesDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        if (prontuarioDto is null)
        {
            return Result.Fail($"Prontuário com o ID {id} não foi encontrado.");
        }

        return Result.Ok(prontuarioDto);
    }

    public async Task<Result> ArquivarProntuarioAsync(int id)
    {
        if (id <= 0)
        {
            return Result.Fail("O identificador do prontuário informado é inválido.");
        }

        // Busca a entidade rastreável para que possamos modificar o seu estado interno
        var prontuario = await repository.ObterPorIdAsync(id);

        if (prontuario is null)
        {
            return Result.Fail($"Não foi possível arquivar. Prontuário com o ID {id} não existe.");
        }

        if (prontuario.SituacaoProntuario == SituacaoProntuarioEnum.Arquivado)
        {
            return Result.Fail("Este prontuário já se encontra arquivado/inativo no sistema.");
        }

        // Aplica a regra de negócio de arquivamento (Deleção Lógica)
        prontuario.SituacaoProntuario = SituacaoProntuarioEnum.Arquivado;
        repository.Atualizar(prontuario);

        var persistidoComSucesso = await repository.CommitAsync();

        if (!persistidoComSucesso)
        {
            return Result.Fail("Falha operacional ao tentar persistir o arquivamento do prontuário no banco de dados.");
        }

        return Result.Ok();
    }
}