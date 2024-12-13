namespace CacaCaracteres.Dto
{
    public class SaidaAutorDto
    {
        public int Codigo { get; set; }
        public required string Nome { get; set; }
        public Guid AutorId { get; set;}
    }
}
