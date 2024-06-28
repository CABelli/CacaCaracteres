using CacaCaracteres.Dto;
using CacaCaracteres.Servicos;
using CacaCaracteres.ServicosCPF;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Controllers;

[ApiController]
[Route("[controller]")]
public class CacaPalavraController : ControllerBase
{
    private readonly IResumoTextoServico _resumoTextoServico;
    private readonly IValidationCPF _validationCPF;

    public CacaPalavraController(IResumoTextoServico resumoTextoServico, IValidationCPF validationCPF)
    {
        _resumoTextoServico = resumoTextoServico;
        _validationCPF = validationCPF;
    }

    [HttpPost]
    public SaidaCacaPalavrasDto Post([FromBody] EntradaCacaPalavrasDto entrada)
    {
        var saida = _resumoTextoServico.GetResumoTexto(entrada);
        return saida;
    }

    [HttpPost]
    [Route("CPF")]
    public bool Post(int versionCalculate)
    {
        var saida = _validationCPF.ValidationGC(versionCalculate);
        
        return saida;
    }
}

