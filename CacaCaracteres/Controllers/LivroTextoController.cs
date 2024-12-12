using CacaCaracteres.Dto;
using CacaCaracteres.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Controllers;

[ApiController]
[Route("[controller]")]
public class LivroTextoController : Controller
{
    private readonly ILivroTextoServico _livroTextoServico;

    public LivroTextoController(ILivroTextoServico livroTextoServico)
    {
        _livroTextoServico = livroTextoServico;
    }

    [HttpGet]
    [Route("Lista")]
    public async Task<ActionResult<List<SaidaCacaPalavrasDto>>> Get() => Ok(await _livroTextoServico.LerListaLivroTextoAsync());

    [HttpGet]
    [Route("ListaFiltro")]    
    public async Task<ActionResult<List<SaidaLivroTextoDto>>> Get(int codigoFiltro) 
        => Ok(await _livroTextoServico.LerListaFiltroLivroTextoAsync(codigoFiltro));

    [HttpGet]
    [Route("Filtro")]
    public async Task<ActionResult<SaidaLivroTextoDto>> LeituraLivroTexto(int codigo)
    {
        var saidaLivroTextoDto = await _livroTextoServico.LerLivrotextoAsync(codigo);
        return Ok(saidaLivroTextoDto);
    }

    [HttpPost]
    [Route("Inclusão")]
    public async Task InclusaoLivroTexto([FromBody] EntradaLivroTextoDto entrada) => await _livroTextoServico.IncluirLivroAsync(entrada);

    [HttpDelete]
    [Route("Exclusão")]
    public async Task ExclusaoLivroTexto(int codigo) => await _livroTextoServico.ExcluirLivroAsync(codigo);

    [HttpPut]
    [Route("Alteração")]
    public async Task AlteracaoLivroTexto([FromBody] EntradaLivroTextoDto entrada) => await _livroTextoServico.AlterarLivroAsync(entrada);
}
