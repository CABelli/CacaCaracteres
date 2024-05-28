using CacaCaracteres.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Servicos;

public interface ILivroTextoServico
{
    Task IncluirLivroAsync(EntradaLivroTextoDto entrada);

    Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigoTexto);
}
