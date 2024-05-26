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

        public async Task<SaidaLivroTextoDto> LerLivrotexto(int codigoTexto)
        {
            var livroTexto = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto = codigoTexto);

            var saidaLivroTextoDto = new SaidaLivroTextoDto() {  CodigoLivro = livroTexto., Texto = }

            return saidaLivroTextoDto;
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
