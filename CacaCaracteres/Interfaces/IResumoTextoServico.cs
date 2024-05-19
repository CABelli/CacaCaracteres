using CacaCaracteres.Dto;

namespace CacaCaracteres.Interfaces
{
    public interface IResumoTextoServico
    {
        SaidaCacaPalavrasDto GetResumoTexto(EntradaCacaPalavrasDto entrada);
    }
}
