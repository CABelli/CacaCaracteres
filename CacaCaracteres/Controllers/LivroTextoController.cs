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
    public async Task<ActionResult<SaidaLivroTextoDto>> LeituraLivroTexto(int codigoTexto)
    {
        var saidaLivroTextoDto = await _livroTextoServico.LerLivrotextoAsync(codigoTexto);
        return Ok(saidaLivroTextoDto);
    }

    [HttpPost]
    public SaidaLivroTextoDto InclusaoLivroTexto([FromBody] EntradaLivroTextoDto entrada)
    {
        _livroTextoServico.IncluiLivro(entrada);
        return new SaidaLivroTextoDto();
    }
}
