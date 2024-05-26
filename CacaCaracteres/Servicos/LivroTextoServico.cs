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

        public Task<SaidaLivroTextoDto> LerLivrotexto(int codigoTexto)
        {
            var livroTexto = _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigoTexto);
            var saidaLivroTextoDto = new SaidaLivroTextoDto() { CodigoLivro = codigoTexto, Texto = livroTexto.Result.Texto };
            return Task.FromResult(saidaLivroTextoDto);
        }

        public Task IncluiLivro(EntradaLivroTextoDto entrada)
        {
            var livroTexto = new LivroTexto { CodigoTexto = entrada.CodigoTexto, Texto = entrada.Texto };
            _livroTextoRepositorio.Create(livroTexto);
            return Task.CompletedTask;
            //Task Create(entrada);
           // throw new NotImplementedException();
        }
    }
}
