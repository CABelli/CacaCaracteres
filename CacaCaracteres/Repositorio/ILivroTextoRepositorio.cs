using CacaCaracteres.Modelo;

namespace CacaCaracteres.Repositorio;

public interface ILivroTextoRepositorio
{
    Task Inclusao(LivroTexto livroTexto);
}
