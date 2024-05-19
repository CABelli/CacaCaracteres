using CacaCaracteres.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Controllers;

[ApiController]
[Route("[controller]")]
public class CacaPalavraController : ControllerBase
{
    private bool success;

    [HttpGet]
    public SaidaCacaPalavrasDto Get()
    {
        var saida = new SaidaCacaPalavrasDto { Texto = "Frase 01", Resultado = "Processar retorno" };
        return saida;
    }

    [HttpPost]
    public SaidaCacaPalavrasDto Post([FromBody] EntradaCacaPalavrasDto entrada)
    {
        var saida = new SaidaCacaPalavrasDto { Texto = entrada.Texto };
        saida.Resultado = "Resultado Processado";
        return saida; 
    }
}

