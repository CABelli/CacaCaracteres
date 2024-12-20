using CacaCaracteres.Dto;
using CacaCaracteres.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace CacaCaracteres.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorController : Controller
{
    private readonly IAutorServico _autorService;

    public AutorController (IAutorServico autorService)
    {
        _autorService = autorService;
    }

    [HttpGet]
    [Route("Lista")]
    public async Task<ActionResult<List<SaidaAutorDto>>> Get() => Ok(await _autorService.LerAllAutoresAsync());

    [HttpGet]
    [Route("LerPorCodigo")]
    public async Task<ActionResult<List<SaidaAutorDto>>> Get(int codigo) => Ok(await _autorService.LerAutorAsync(codigo));

    [HttpGet]
    [Route("LerPorNome")]
    public async Task<ActionResult<List<SaidaAutorDto>>> Get(string nome) => Ok(await _autorService.LerAutorAsync(nome));

    [HttpPost]
    [Route ("Inclusão")]
    public async Task InclusaoAutor([FromBody] EntradaAutorDto entrada) => await _autorService.AddAutorAsync(entrada);

    [HttpDelete]
    [Route("Exclusão")]
    public async Task ExclusaoAutor(int codigo)
    {
        await _autorService.DeleteAutorAsync(codigo);
    }
}
