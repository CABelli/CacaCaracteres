using CacaCaracteres.Dto;

namespace CacaCaracteres.Servicos;

public interface IResumoTextoServico
{
    SaidaCacaPalavrasDto GetResumoTexto(EntradaCacaPalavrasDto textoEntrada);
}
