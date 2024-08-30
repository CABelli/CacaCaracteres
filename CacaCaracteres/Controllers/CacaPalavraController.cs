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

    [HttpGet]
    public SaidaCacaPalavrasDto Get([FromQuery] EntradaCacaPalavrasDto entrada)
    {
        var saida = _resumoTextoServico.GetResumoTexto(entrada);
        return saida;
    }

    [HttpGet]
    [Route("CPF")]
    public bool Get(int versionCalculate)
    {
        var saida = _validationCPF.ValidationGC(versionCalculate);
        
        return saida;
    }

    [HttpGet]
    [Route("Pessoa")]
    public bool GetPessoa(int versionCalculate)
    {
        var saida = _validationCPF.Validation02GC(versionCalculate);
        return saida;
    }
}

