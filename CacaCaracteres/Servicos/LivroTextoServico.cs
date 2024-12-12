using CacaCaracteres.Dto;
using CacaCaracteres.ExceptionBase;
using CacaCaracteres.ExtensoesCaracteres;
using CacaCaracteres.Modelo;
using CacaCaracteres.Repositorio;
using System.Text;

namespace CacaCaracteres.Servicos
{
    public class LivroTextoServico : ILivroTextoServico
    {
        private readonly ILivroTextoRepositorio _livroTextoRepositorio;

        public LivroTextoServico (ILivroTextoRepositorio livroTextoRepositorio)
        {
            _livroTextoRepositorio = livroTextoRepositorio;
        }

        public async Task<List<SaidaLivroTextoDto>> LerListaLivroTextoAsync()
        {
            var listLivroTexto = await _livroTextoRepositorio.GetAllAsync();

            var listSaidaLivroTextoDdto = new List<SaidaLivroTextoDto>();

            if (listLivroTexto != null)
                listLivroTexto.OrderBy(x => x.CodigoTexto).ToList().ForEach(y => listSaidaLivroTextoDdto
                    .Add(new SaidaLivroTextoDto() {
                        CodigoLivro = y.CodigoTexto,
                        Texto = y.Texto,
                        NumeroDePalavras = NumeroDePalavrasCalc(y.Texto),
                        NumeroDeLetras = EntradaNormalizada(y.Texto).Count(x => x == x.RetornaLetra()),
                        NumeroDeVogais = EntradaNormalizada(y.Texto).Count(x => x == x.RetornaVogal()),
                        NumeroDeConsonantes = EntradaNormalizada(y.Texto).Count(x => x == x.RetornaConsoante()),
                        NumeroDeMaisculas = y.Texto.Count(char.IsUpper),
                        NumeroDeMinuscolas = y.Texto.Count(char.IsLower)
                    }));

            return listSaidaLivroTextoDdto;
        }

        public async Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigo)
        {
            var livroTexto = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigo);
            if (livroTexto == null) return new SaidaLivroTextoDto();
            var saidaLivroTextoDto = new SaidaLivroTextoDto()
            {
                CodigoLivro = codigo,
                Texto = livroTexto.Texto,
                NumeroDePalavras = NumeroDePalavrasCalc(livroTexto.Texto),
                NumeroDeLetras = EntradaNormalizada(livroTexto.Texto).Count(x => x == x.RetornaLetra()),
                NumeroDeVogais = EntradaNormalizada(livroTexto.Texto).Count(x => x == x.RetornaVogal()),
                NumeroDeConsonantes = EntradaNormalizada(livroTexto.Texto).Count(x => x == x.RetornaConsoante()),
                NumeroDeMaisculas = livroTexto.Texto.Count(char.IsUpper),
                NumeroDeMinuscolas = livroTexto.Texto.Count(char.IsLower)
            };
            return saidaLivroTextoDto;
        }

        public async Task<List<SaidaLivroTextoDto>> LerListaFiltroLivroTextoAsync(int codigoFiltro)
        {
            var listLivroTexto = await _livroTextoRepositorio.WhereAllAsync(x => x.CodigoTexto == codigoFiltro);

            var listSaidaLivroTextoDdto = new List<SaidaLivroTextoDto>();

            if (listLivroTexto != null)
                listLivroTexto.OrderBy(x => x.CodigoTexto).ToList().ForEach(y => listSaidaLivroTextoDdto
                    .Add(new SaidaLivroTextoDto()
                    {
                        CodigoLivro = y.CodigoTexto,
                        Texto = y.Texto,
                        NumeroDePalavras = NumeroDePalavrasCalc(y.Texto),
                        NumeroDeLetras = EntradaNormalizada(y.Texto).Count(x => x == x.RetornaLetra()),
                        NumeroDeVogais = EntradaNormalizada(y.Texto).Count(x => x == x.RetornaVogal()),
                        NumeroDeConsonantes = EntradaNormalizada(y.Texto).Count(x => x == x.RetornaConsoante()),
                        NumeroDeMaisculas = y.Texto.Count(char.IsUpper),
                        NumeroDeMinuscolas = y.Texto.Count(char.IsLower)
                    }));

            return listSaidaLivroTextoDdto;
        }

        public async Task IncluirLivroAsync(EntradaLivroTextoDto entrada)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == entrada.CodigoTexto);
            if (livroTextoDb != null)
                // criar FluentValidation / ErrorsNotFoundException
                //throw new Exception(String.Format("Codigo texto {0} já esta cadastrado.", entrada.CodigoTexto));
                throw new ErrorsFoundException(new List<string>() { String.Format("Codigo texto {0} ja esta cadastrado.", entrada.CodigoTexto) });
            
            var livroTexto = new LivroTexto { CodigoTexto = entrada.CodigoTexto, Texto = entrada.Texto };
            _livroTextoRepositorio.Create(livroTexto);
            await Task.Yield();
        }

        public async Task ExcluirLivroAsync(int codigo)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigo);
            if (livroTextoDb == null)
                // criar FluentValidation / ErrorsNotFoundException
                //throw new Exception(String.Format("O codigo texto {0} não encontrado.", codigo));
                throw new ErrorsNotFoundException(new List<string>() { String.Format("O codigo texto {0} nao foi encontrado.", codigo) });
            
            _livroTextoRepositorio.Delete(livroTextoDb);
            await Task.Yield();
        }

        public async Task AlterarLivroAsync(EntradaLivroTextoDto entrada)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == entrada.CodigoTexto);
            if (livroTextoDb == null)
                // criar FluentValidation / ErrorsNotFoundException
                //throw new Exception(String.Format("O codigo texto {0} não encontrado.", entrada.CodigoTexto));
                throw new ErrorsNotFoundException(new List<string>() { String.Format("O codigo texto {0} nao foi encontrado.", entrada.CodigoTexto) });

            livroTextoDb.Texto = entrada.Texto;
            _livroTextoRepositorio.Update(livroTextoDb);
            await Task.Yield();
        }

        public string EntradaNormalizada(string textoEntrada)
        {
            return textoEntrada.ToLower().Normalize(NormalizationForm.FormD);
        }

        public int NumeroDePalavrasCalc(string textoEntrada)
        {
            var soLetras = string.Empty;
            EntradaNormalizada(textoEntrada).ToList().ForEach(c => {
                soLetras += c.RetornaConsoanteEspaco();
                soLetras = soLetras.Replace("  ", " ");
            });

            return soLetras.Trim().Split(' ').Length;
        }
    }
}
