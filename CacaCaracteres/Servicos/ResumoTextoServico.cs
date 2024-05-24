using CacaCaracteres.Dto;
using CacaCaracteres.ExtensoesCaracteres;
using CacaCaracteres.Interfaces;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

            var entradaNormalizada = entrada.Texto.ToLower().Normalize(NormalizationForm.FormD);

            var saida = new SaidaCacaPalavrasDto
            {
                Texto = entrada.Texto,
                NumeroDePalavras = entradaNormalizada.Split(' ').Length,
                NumeroDeLetras = entradaNormalizada.Count( x => x == x.RetornaLetra()),
                NumeroDeVogais = entradaNormalizada.Count( x => x == x.RetornaVogal()),
                NumeroDeConsonantes = entradaNormalizada.Count(x => x == x.RetornaConsoante()),
                NumeroDeMaisculas = entrada.Texto.Count(char.IsUpper),
                NumeroDeMinuscolas = entrada.Texto.Count( char.IsLower)
            };
            return saida;
        }
    }
}
