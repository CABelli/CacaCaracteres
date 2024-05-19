using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Controllers;

[ApiController]
[Route("[controller]")]
public class CacaPalavraController : ControllerBase
{
    [HttpGet(Name = "Get-Ok")]
    public Saida Get()
    {
        var saida = new Saida { Resultado = "Foi" };
        return saida;
    }
}
public class Saida
{
    public string? Resultado { get; set; }
}
