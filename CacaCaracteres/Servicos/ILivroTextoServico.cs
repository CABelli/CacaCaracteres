using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface ILivroTextoServico
{
    Task IncluirLivroAsync(EntradaLivroTextoDto entrada);

    Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigoTexto);

    Task<List<SaidaLivroTextoDto>> LerListaLivroTextoAsync();

    Task<List<SaidaLivroTextoDto>> LerListaFiltroLivroTextoAsync(int codigoTexto);

    Task ExcluirLivroAsync(int codigoTexto);

    Task AlterarLivroAsync(EntradaLivroTextoDto entrada);
}
