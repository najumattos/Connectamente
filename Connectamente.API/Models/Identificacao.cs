using Connectamente.API.Enums;

namespace Connectamente.API.Models;

public record Identificacao(

    string NomeCompleto,
    DateTime DataNascimento,
    string CPF,
    string? RG,
    string TelefonePrincipal,
    string? TelefoneRecado,
    EscolaridadeEnum? Escolaridade,
    GeneroEnum? Genero,
    string? Profissao,
    string? Email,
    EstadoCivilEnum? EstadoCivil,
    string? Naturalidade,
    string? EstadoNascimento,
    string? Religiao
);