namespace Connectamente.API.Models;

public record Endereco(
    string Logradouro, 
    string Numero, 
    string Bairro, 
    string Cidade, 
    string Estado, 
    string CEP
);