using CacaCaracteres.Dto;
using CacaCaracteres.Modelo;
using CacaCaracteres.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Servicos
{
    public class LivroTextoServico : ILivroTextoServico
    {
        private readonly ILivroTextoRepositorio _livroTextoRepositorio;

        public LivroTextoServico (ILivroTextoRepositorio livroTextoRepositorio)
        {
            _livroTextoRepositorio = livroTextoRepositorio;
        }

        public async Task<SaidaLivroTextoDto> LerLivrotextoAsync(int codigoTexto)
        {
            var livroTexto = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == codigoTexto);
            if (livroTexto == null) return new SaidaLivroTextoDto();
            var saidaLivroTextoDto = new SaidaLivroTextoDto() { CodigoLivro = codigoTexto, Texto = livroTexto.Texto };
            return saidaLivroTextoDto;
        }

        public async Task IncluirLivroAsync(EntradaLivroTextoDto entrada)
        {
            var livroTextoDb = await _livroTextoRepositorio.WhereFirstAsync(x => x.CodigoTexto == entrada.CodigoTexto);
            if (livroTextoDb != null) // return Task.FromException();
               throw new NotImplementedException("Ja existe");
            var livroTexto = new LivroTexto { CodigoTexto = entrada.CodigoTexto, Texto = entrada.Texto };
            _livroTextoRepositorio.Create(livroTexto);
            await Task.Yield();
        }
    }
}
