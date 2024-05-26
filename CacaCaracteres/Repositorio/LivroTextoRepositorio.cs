using CacaCaracteres.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CacaCaracteres.Repositorio;

public class LivroTextoRepositorio : GenericoRepositorio<LivroTexto>, ILivroTextoRepositorio
{
    public LivroTextoRepositorio(DbContext context) : base (context) 
    {
    }
}
