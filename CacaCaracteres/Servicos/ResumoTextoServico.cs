using CacaCaracteres.Dto;
using CacaCaracteres.ExtensoesCaracteres;
using CacaCaracteres.Interfaces;

namespace CacaCaracteres.Servicos
{
    public class ResumoTextoServico : IResumoTextoServico
    {
        public SaidaCacaPalavrasDto GetResumoTexto(EntradaCacaPalavrasDto entrada)
        {
            if (string.IsNullOrEmpty(entrada.Texto))
            {
                var saidaVazia = new SaidaCacaPalavrasDto
                {
                    Texto = "Preencher o texto"
                };
                return saidaVazia;
            }
            var saida = new SaidaCacaPalavrasDto
            {
                Texto = entrada.Texto,
                NumeroDePalavras = entrada.Texto.Split(' ').Length,
                NumeroDeLetras = entrada.Texto.Count( x => x == x.RetornaLetra()),
                NumeroDeVogais = entrada.Texto.Count( x => x == x.RetornaVogal())
            };
            return saida;
        }
    }
}
