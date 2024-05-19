using CacaCaracteres.Dto;
using CacaCaracteres.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Controllers;

[ApiController]
[Route("[controller]")]
public class CacaPalavraController : ControllerBase
{
    private readonly IResumoTextoServico _resumoTextoServico;

    public CacaPalavraController (IResumoTextoServico resumoTextoServico)
    {
        _resumoTextoServico = resumoTextoServico;
    }

    [HttpGet]
    public SaidaCacaPalavrasDto Get()
    {
        var saida = new SaidaCacaPalavrasDto { Texto = "Frase 01", NumeroDePalavras = 0 };
        return saida;
    }

    [HttpPost]
    public SaidaCacaPalavrasDto Post([FromBody] EntradaCacaPalavrasDto entrada)
    {
        var saida = _resumoTextoServico.GetResumoTexto(entrada);
        return saida; 
    }
}

