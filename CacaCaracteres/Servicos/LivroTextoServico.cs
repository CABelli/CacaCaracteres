using CacaCaracteres.Dto;
using CacaCaracteres.EnumClass;
using CacaCaracteres.ExceptionBase;
using CacaCaracteres.ExtensoesCaracteres;
using CacaCaracteres.Modelo;
using CacaCaracteres.Repositorio;
using CacaCaracteres.Resources.Servicos;
using CacaCaracteres.Validator;
using System.Text;

namespace CacaCaracteres.Servicos
{
    public class LivroTextoServico : ILivroTextoServico
    {
        private readonly ILivroTextoRepositorio _livroTextoRepositorio;
        private readonly IAutorServico _autorServico;

        public LivroTextoServico (ILivroTextoRepositorio livroTextoRepositorio, IAutorServico autorServico)
        {
            _livroTextoRepositorio = livroTextoRepositorio;
            _autorServico = autorServico;   
        }

        public async Task<List<SaidaLivroTextoDto>> LerListaLivroTextoAsync()
        {
            var listLivroTexto = await _livroTextoRepositorio.GetAllAsync();

            var listSaidaLivroTextoDdto = new List<SaidaLivroTextoDto>();

            if (listLivroTexto != null)
                listLivroTexto.OrderBy(x => x.CodigoTexto).ToList().ForEach(y => listSaidaLivroTextoDdto
                    .Add(new SaidaLivroTextoDto() {
                        NomeAutor = BuscaNomeAutor(y.AutorId).Result,
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

        public async Task<string> BuscaNomeAutor(Guid autorId)
        {
            var autores = await _autorServico.LerAutorAsync(autorId);
            return autores[0].Nome;
        }

        public async Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigo)
        {
            var livroTexto = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigo);
            if (livroTexto == null) return new SaidaLivroTextoDto();
            var saidaLivroTextoDto = new SaidaLivroTextoDto()
            {
                NomeAutor = BuscaNomeAutor(livroTexto.AutorId).Result,
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
                        NomeAutor = BuscaNomeAutor(y.AutorId).Result,
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
            ValidatorAddLivroTexto(entrada);

            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == entrada.CodigoTexto);
            if (livroTextoDb != null)
                throw new ErrorsFoundException(new List<string>() 
                { 
                    String.Format(Resource.TextCodeIsAlreadyRegistered, entrada.CodigoTexto) 
                });

            var autores = _autorServico.LerAutorAsync(entrada.CodigoAutor);
            if (autores.Result.Count == 0)
                throw new ErrorsNotFoundException(new List<string>() 
                { 
                    String.Format(Resource.AuthorCodeNotRegistered,entrada.CodigoAutor) 
                });

            var livroTexto = new LivroTexto { 
                CodigoTexto = entrada.CodigoTexto, 
                Texto = entrada.Texto,
                AutorId = autores.Result[0].AutorId
            };
            _livroTextoRepositorio.Create(livroTexto);
            await Task.Yield();
        }

        public async Task ExcluirLivroAsync(int codigo)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigo);
            if (livroTextoDb == null)
                // criar FluentValidation / ErrorsNotFoundException
                throw new ErrorsNotFoundException(new List<string>() 
                { 
                    String.Format(Resource.TextCodeNotRegistered, codigo) 
                });
            
            _livroTextoRepositorio.Delete(livroTextoDb);
            await Task.Yield();
        }

        public async Task AlterarLivroAsync(EntradaLivroTextoDto entrada)
        {
            ValidatorAlteraLivroTexto(entrada);

            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == entrada.CodigoTexto);
            if (livroTextoDb == null)
                // criar FluentValidation / ErrorsNotFoundException
                throw new ErrorsNotFoundException(new List<string>() 
                { 
                    String.Format(Resource.TextCodeNotRegistered, entrada.CodigoTexto) 
                });

            var autores = _autorServico.LerAutorAsync(entrada.CodigoAutor);
            if (autores.Result.Count == 0)
                throw new ErrorsNotFoundException(new List<string>()                
                { 
                    String.Format(Resource.AuthorCodeNotRegistered, entrada.CodigoAutor) }
                );

            livroTextoDb.Texto = entrada.Texto;
            livroTextoDb.AutorId = autores.Result[0].AutorId;
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

        private void ValidatorAddLivroTexto(EntradaLivroTextoDto entrada)
        {
            var validator = new LivroTextoValidator(EMethodLivroTextoValidator.AddLivroTexto);
            var result = validator.Validate(entrada);
            if (!result.IsValid)
                throw new ErrosDeValidacaoException(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        private void ValidatorAlteraLivroTexto(EntradaLivroTextoDto entrada)
        {
            var validator = new LivroTextoValidator(EMethodLivroTextoValidator.AlteraLivroTexto);
            var result = validator.Validate(entrada);
            if (!result.IsValid)
                throw new ErrosDeValidacaoException(result.Errors.Select(x => x.ErrorMessage).ToList());             
        }
    }
}
