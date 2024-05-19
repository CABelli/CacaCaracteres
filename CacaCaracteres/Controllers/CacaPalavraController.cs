using CacaCaracteres.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Controllers;

[ApiController]
[Route("[controller]")]
public class CacaPalavraController : ControllerBase
{

    [HttpGet]
    public SaidaCacaPalavrasDto Get()
    {
        var saida = new SaidaCacaPalavrasDto { Texto = "Frase 01", NumeroDePalavras = 0 };
        return saida;
    }

    [HttpPost]
    public SaidaCacaPalavrasDto Post([FromBody] EntradaCacaPalavrasDto entrada)
    {
        var saida = new SaidaCacaPalavrasDto { Texto = entrada.Texto };
        saida.NumeroDePalavras = entrada.Texto.Split(' ').Length;
        return saida; 
    }
}

