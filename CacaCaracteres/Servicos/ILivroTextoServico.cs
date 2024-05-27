using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface ILivroTextoServico
{
    Task IncluiLivro(EntradaLivroTextoDto entrada);

    Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigoTexto);
}
