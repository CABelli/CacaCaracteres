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

            var entradaNormalizada = textoEntrada.Texto.ToLower().Normalize(NormalizationForm.FormD);

            var soLetras = string.Empty;
            foreach (char c in entradaNormalizada)
            {
                if (c.RetornaLetra() is not null || c.Equals(' ')) soLetras += c;
            }
            //var soLetras = entradaNormalizada.Contains(entradaNormalizada.Where( x => x == x.RetornaLetra() ) );
            Console.WriteLine(soLetras);
            Console.WriteLine(soLetras.Split(' ').Length);
            Console.WriteLine(soLetras.Replace("  "," ").Split(' ').Length);

            var soLetras2 = entradaNormalizada;
            var soLetras3 = string.Empty;
            //soLetras.ToList().ForEach(c => += c );
            //soLetras2.Concat(x => x == x.RetConsoanteEspaco() , soLetras3);//.Replace("  ", " ").Split(' ').Length;
            foreach (char c in entradaNormalizada)
            {
                soLetras3 += c.RetConsoanteEspaco();
            }
            Console.WriteLine(soLetras3);
            Console.WriteLine(soLetras3.Replace("  ", " ").Split(' ').Length);

            var soLetras4 = entradaNormalizada;
            var soLetras5 = string.Empty;
            soLetras4.ToList().ForEach(c => { soLetras5 += c.RetConsoanteEspaco(); } );
            Console.WriteLine("soLetras5 - " + soLetras5.Replace("  ", " ").Split(' ').Length);

            var soLetras7 = string.Empty;
            entradaNormalizada.ToList().ForEach(c => { soLetras7 += c.RetConsoanteEspaco(); });
            Console.WriteLine("soLetras7 - " + soLetras7.Replace("  ", " ").Split(' ').Length);

            var saida = new SaidaCacaPalavrasDto
            {
                Texto = textoEntrada.Texto,
                //NumeroDePalavras = entradaNormalizada.Split(' ').Length,
                NumeroDePalavras = soLetras7.Replace("  ", " ").Split(' ').Length,
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
