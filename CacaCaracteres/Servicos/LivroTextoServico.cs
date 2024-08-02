using CacaCaracteres.Dto;
using CacaCaracteres.Modelo;
using CacaCaracteres.Repositorio;

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
                        NumeroDePalavras = 5 }));

            //var listSaidaLivroTextoDdto = new List<SaidaLivroTextoDto> {
            //    new SaidaLivroTextoDto (){ CodigoLivro = 5, Texto = "a", NumeroDePalavras = 4 } };

            return listSaidaLivroTextoDdto;
        }

        public async Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigoTexto)
        {
            var livroTexto = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigoTexto);
            if (livroTexto == null) return new SaidaLivroTextoDto();
            var saidaLivroTextoDto = new SaidaLivroTextoDto()
            {
                CodigoLivro = codigoTexto,
                Texto = livroTexto.Texto,
                NumeroDePalavras = livroTexto.Texto.Split(' ').Count()
            };
            return saidaLivroTextoDto;
        }

        public async Task IncluirLivroAsync(EntradaLivroTextoDto entrada)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == entrada.CodigoTexto);
            if (livroTextoDb != null)
                // criar FluentValidation / ErrorsNotFoundException
                throw new Exception(String.Format("O codigo texto {0} já é cadastrado.", entrada.CodigoTexto));                    
            var livroTexto = new LivroTexto { CodigoTexto = entrada.CodigoTexto, Texto = entrada.Texto };
            _livroTextoRepositorio.Create(livroTexto);
            await Task.Yield();
        }

        public async Task ExcluirLivroAsync(int codigoTexto)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigoTexto);
            if (livroTextoDb == null)
                // criar FluentValidation / ErrorsNotFoundException
                throw new Exception(String.Format("O codigo texto {0} não encontrado.", codigoTexto));
            _livroTextoRepositorio.Delete(livroTextoDb);
            await Task.Yield();
        }

        public async Task AlterarLivroAsync(EntradaLivroTextoDto entrada)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == entrada.CodigoTexto);
            if (livroTextoDb == null)
                // criar FluentValidation / ErrorsNotFoundException
                throw new Exception(String.Format("O codigo texto {0} não encontrado.", entrada.CodigoTexto));

            livroTextoDb.Texto = entrada.Texto;
            _livroTextoRepositorio.Update(livroTextoDb);
            await Task.Yield();
        }
    }
}
