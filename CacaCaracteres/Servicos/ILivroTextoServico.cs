using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface ILivroTextoServico
{
    Task IncluirLivroAsync(EntradaLivroTextoDto entrada);

    Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigo);

    Task<List<SaidaLivroTextoDto>> LerListaLivroTextoAsync();

    Task<List<SaidaLivroTextoDto>> LerListaFiltroLivroTextoAsync(int codigoFiltro);

    Task ExcluirLivroAsync(int codigo);

    Task AlterarLivroAsync(EntradaLivroTextoDto entrada);
}
