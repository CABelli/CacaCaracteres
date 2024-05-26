namespace CacaCaracteres.Modelo;

public sealed class LivroTexto : Base
{
    public int CodigoTexto { get; set; }
    public required string Texto { get; set; }
}
