using CacaCaracteres.Dto;
using CacaCaracteres.Servicos;
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

    [HttpPost]
    public SaidaCacaPalavrasDto Post([FromBody] EntradaCacaPalavrasDto entrada)
    {
        var saida = _resumoTextoServico.GetResumoTexto(entrada);
        return saida; 
    }
}

