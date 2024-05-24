using CacaCaracteres.Dto;
using CacaCaracteres.ExtensoesCaracteres;
using System.Text;

namespace CacaCaracteres.Servicos
{
    public class ResumoTextoServico : IResumoTextoServico
    {
        public SaidaCacaPalavrasDto GetResumoTexto(EntradaCacaPalavrasDto textoEntrada)
        {
            if (string.IsNullOrEmpty(textoEntrada.Texto))
            {
                var saidaVazia = new SaidaCacaPalavrasDto
                {
                    Texto = "Preencher o texto"
                };
                return saidaVazia;
            }

            var entradaNormalizada = textoEntrada.Texto.ToLower().Normalize(NormalizationForm.FormD);

            var saida = new SaidaCacaPalavrasDto
            {
                Texto = textoEntrada.Texto,
                NumeroDePalavras = entradaNormalizada.Split(' ').Length,
                NumeroDeLetras = entradaNormalizada.Count( x => x == x.RetornaLetra()),
                NumeroDeVogais = entradaNormalizada.Count( x => x == x.RetornaVogal()),
                NumeroDeConsonantes = entradaNormalizada.Count(x => x == x.RetornaConsoante()),
                NumeroDeMaisculas = textoEntrada.Texto.Count(char.IsUpper),
                NumeroDeMinuscolas = textoEntrada.Texto.Count( char.IsLower)
            };
            return saida;
        }
    }
}
