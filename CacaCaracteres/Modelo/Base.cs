namespace CacaCaracteres.Modelo;

public abstract class Base
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
