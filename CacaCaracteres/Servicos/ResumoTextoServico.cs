using CacaCaracteres.Dto;
using CacaCaracteres.Interfaces;

namespace CacaCaracteres.Servicos
{
    public class ResumoTextoServico : IResumoTextoServico
    {
        public SaidaCacaPalavrasDto GetResumoTexto(EntradaCacaPalavrasDto entrada)
        {
            var saida = new SaidaCacaPalavrasDto
            {
                Texto = entrada.Texto,
                NumeroDePalavras = entrada.Texto.Split(' ').Length
            };
            return saida;
        }
    }
}
