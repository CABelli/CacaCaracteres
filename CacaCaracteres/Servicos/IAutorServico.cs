using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface IAutorServico
{
    Task AddAutorAsync(EntradaAutorDto entrada);
    Task<List<SaidaAutorDto>> LerAutorAsync(int codigo);
    Task<List<SaidaAutorDto>> LerAutorAsync(string nome);
}
