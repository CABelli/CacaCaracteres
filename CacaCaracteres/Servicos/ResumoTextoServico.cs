using CacaCaracteres.Dto;
using CacaCaracteres.ExtensoesCaracteres;
using System.Linq;
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

            var entradaNormalizada = textoEntrada.Texto.ToLower().Normalize(NormalizationForm.FormD).Replace("  ", " ");
            Console.WriteLine("A - " + entradaNormalizada.Split(' ').Length);

            var soLetras = string.Empty;
            entradaNormalizada.ToList().ForEach(c => { soLetras += c.RetornaConsoanteEspaco(); });
            Console.WriteLine("B - " + soLetras.Replace("  ", " ").Split(' ').Length);

            var saida = new SaidaCacaPalavrasDto
            {
                Texto = textoEntrada.Texto,
                //NumeroDePalavras = entradaNormalizada.Split(' ').Length,
                NumeroDePalavras = soLetras.Replace("  ", " ").Split(' ').Length,
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
