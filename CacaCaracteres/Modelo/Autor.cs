namespace CacaCaracteres.Modelo;

public class Autor : Base
{
    public int Codigo { get; set; }
    public required string Nome { get; set; }
    public ICollection<LivroTexto>? LivroTexto { get; set; }
}
