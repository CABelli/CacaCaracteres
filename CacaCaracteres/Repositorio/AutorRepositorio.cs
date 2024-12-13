using CacaCaracteres.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CacaCaracteres.Repositorio;

public class AutorRepositorio : GenericoRepositorio<Autor>, IAutorRepositorio
{
    public AutorRepositorio(DbContext context) : base(context)
    {
    }
}
