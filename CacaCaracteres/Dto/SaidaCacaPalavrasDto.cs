namespace CacaCaracteres.Dto;

public class SaidaCacaPalavrasDto
{
    public string? Texto {  get; set; }
    public int NumeroDePalavras { get; set; } = 0;
    public int NumeroDeCaracteres { get; set; } = 0;
    public int NumeroDeVogais { get; set; } = 0;
    public int NumeroDeConsonantes { get; set; } = 0;
    public int NumeroDeMaisculas { get; set; } = 0;
    public int NumeroDeMinuscolas { get; set; } = 0;
}
