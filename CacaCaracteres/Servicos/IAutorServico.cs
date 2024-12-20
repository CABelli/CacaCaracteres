using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface IAutorServico
{
    Task AddAutorAsync(EntradaAutorDto entrada);
    Task DeleteAutorAsync(int codigo);
    Task UpdateAutorAsync(EntradaAutorDto entrada);
    Task<List<SaidaAutorDto>> LerAutorAsync(int codigo);
    Task<List<SaidaAutorDto>> LerAutorAsync(string nome);
    Task<List<SaidaAutorDto>> LerAutorAsync(Guid autorId);
    Task<List<SaidaAutorDto>> LerAllAutoresAsync();
}
