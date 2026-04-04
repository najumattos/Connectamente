using Connectamente.API.Domain;
using Connectamente.API.DTOs;
using Connectamente.API.Enums;
using Connectamente.API.Models.ViewModel;
using Connectamente.API.Services.PacienteService;

namespace Connectamente.API.Services;

public class PsicologiaService(IPacienteService pacienteService) : IPsicologiaService
{

   

}


/*
 * SRP (Princípio de Responsabilidade Única) - O metodo só tem um motivo para mudar (adicionar um perfil novo)
 * Fail Fast (Falha Rápida) - A execução é interrompida assim que algo dá errado 
 * Result Pattern - O método retorna um objeto encapsulado com informações de erro ou sucesso.
 * OCP (Princípio de Aberto/Fechado) - O método é aberto para extensão (novos perfis) mas fechado para modificação (não precisa alterar o código existente).
 * Declarative Programming - O código expressa o que deve ser feito  em vez de como fazer
 */
