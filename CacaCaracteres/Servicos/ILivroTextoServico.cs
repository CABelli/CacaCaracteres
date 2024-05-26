using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface ILivroTextoServico
{
    Task IncluiLivro(EntradaLivroTextoDto entrada);

    SaidaCacaPalavrasDto LerLivrotexto(int codigoTexto);
}
