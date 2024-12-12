namespace CacaCaracteres.Modelo;

public sealed class LivroTexto : Base
{
    public int CodigoTexto { get; set; }
    public required string Texto { get; set; }
    public Guid? AutorId { get; set; }

    public Autor? Autor { get; set; }

}
