using CacaCaracteres.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CacaCaracteres.ContextoDB;

public class AppDataBaseContext : DbContext
{
    public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options) { }

    public DbSet<LivroTexto> LivroTexto { get; set; }

}
