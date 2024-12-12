using CacaCaracteres.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CacaCaracteres.ContextoDB;

public class AppDataBaseContext : DbContext
{
    public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options) { }

    public DbSet<LivroTexto> LivroTexto { get; set; }

    public DbSet<Autor> Autors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDataBaseContext).Assembly);
    }

}
