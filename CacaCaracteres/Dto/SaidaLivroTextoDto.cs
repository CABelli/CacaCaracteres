namespace CacaCaracteres.Dto;

public class SaidaLivroTextoDto
{
    public string? NomeAutor { get; set; }
    public int CodigoLivro {  get; set; }
    public string Texto { get; set; }
    public int NumeroDePalavras { get; set; } = 0;
    public int NumeroDeLetras { get; set; } = 0;
    public int NumeroDeVogais { get; set; } = 0;
    public int NumeroDeConsonantes { get; set; } = 0;
    public int NumeroDeMaisculas { get; set; } = 0;
    public int NumeroDeMinuscolas { get; set; } = 0;
}
