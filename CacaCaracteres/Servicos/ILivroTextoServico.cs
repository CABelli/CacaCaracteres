using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface ILivroTextoServico
{
    Task IncluirLivroAsync(EntradaLivroTextoDto entrada);

    Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigoTexto);

    Task<List<SaidaLivroTextoDto>> LerListaLivroTextoAsync();

    Task ExcluirLivroAsync(int codigoTexto);

    Task AlterarLivroAsync(EntradaLivroTextoDto entrada);
}
