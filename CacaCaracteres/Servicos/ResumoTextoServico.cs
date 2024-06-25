﻿using CacaCaracteres.Dto;
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

            //var entradaNormalizada = textoEntrada.Texto.ToLower().Normalize(NormalizationForm.FormD).Replace("  ", " ");
            var entradaNormalizada = textoEntrada.Texto.ToLower().Normalize(NormalizationForm.FormD);
            //var soLetras = string.Empty;
            //entradaNormalizada.ToList().ForEach(c => { soLetras += c.RetornaConsoanteEspaco(); });

            var soLetras = string.Empty;
            entradaNormalizada.ToList().ForEach(c => { 
                soLetras += c.RetornaConsoanteEspaco(); 
                soLetras = soLetras.Replace("  ", " "); 
            });
            Console.WriteLine(soLetras.Trim().Split().Length);

            var saida = new SaidaCacaPalavrasDto
            {
                Texto = textoEntrada.Texto,
                //NumeroDePalavras = soLetras.Replace("  ", " ").TrimEnd(' ').Split(' ').Length,
                //NumeroDePalavras = soLetras.Trim().Replace("  ", " ").Split(' ').Length,
                NumeroDePalavras = soLetras.Trim().Split(' ').Length,
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
