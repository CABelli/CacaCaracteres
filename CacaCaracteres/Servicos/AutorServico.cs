using CacaCaracteres.Dto;
using CacaCaracteres.ExceptionBase;
using CacaCaracteres.Modelo;
using CacaCaracteres.Repositorio;
using CacaCaracteres.Validator;

namespace CacaCaracteres.Servicos;

public class AutorServico : IAutorServico
{
    private readonly IAutorRepositorio _autorRepositorio;

    public AutorServico(IAutorRepositorio autorRepositorio)
    {
        _autorRepositorio = autorRepositorio;
    }

    public async Task<List<SaidaAutorDto>> LerAllAutoresAsync()
    {
        var autores = await _autorRepositorio.GetAllAsync();
        var saidaAutorDtos = new List<SaidaAutorDto>();

        if (autores != null)
            autores
                .OrderBy(x => x.Codigo)
                .ToList()
                .ForEach(x => saidaAutorDtos
                                        .Add(new SaidaAutorDto()
                                        {
                                            Codigo = x.Codigo,
                                            Nome = x.Nome,
                                            AutorId = x.Id
                                        }));

        return saidaAutorDtos;
    }

    public async Task<List<SaidaAutorDto>> LerAutorAsync(int codigo)
    {
        var autores = await _autorRepositorio.WhereAllAsync(x => x.Codigo == codigo);

        var saidaAutorDtos = new List<SaidaAutorDto>();

        if (autores != null)
            autores
                .OrderBy(x => x.Codigo)
                .ToList()
                .ForEach(x => saidaAutorDtos
                                        .Add(new SaidaAutorDto()
                                        {
                                            Codigo = x.Codigo,
                                            Nome = x.Nome,
                                            AutorId = x.Id
                                        }));        

        return saidaAutorDtos;
    }

    public async Task<List<SaidaAutorDto>> LerAutorAsync(string nome)
    {
        var autores = await _autorRepositorio.WhereAllAsync(x => x.Nome == nome);

        var saidaAutoresDto = new List<SaidaAutorDto>();

        if (autores != null)
            autores
                .OrderBy(x => x.Nome)
                .ToList()
                .ForEach(x => saidaAutoresDto
                                .Add(new SaidaAutorDto()
                                {
                                    Nome = x.Nome,
                                    Codigo = x.Codigo,
                                    AutorId = x.Id
                                }));

        return saidaAutoresDto;
    }
    public async Task<List<SaidaAutorDto>> LerAutorAsync(Guid autorId)
    {
        var autores = await _autorRepositorio.WhereAllAsync(x => x.Id == autorId);

        var saidaAutoresDto = new List<SaidaAutorDto>();

        if (autores != null)
            autores
                .OrderBy(x => x.Nome)
                .ToList()
                .ForEach(x => saidaAutoresDto
                                .Add(new SaidaAutorDto()
                                {
                                    Nome = x.Nome,
                                    Codigo = x.Codigo,
                                    AutorId = x.Id
                                }));

        return saidaAutoresDto;
    }

    public async Task AddAutorAsync(EntradaAutorDto entrada)
    {
        int a = 0;
        int b = 0;
        int c = a / b;

        EntradaAutorAddValidator(entrada);

        var autores = await LerAutorAsync(entrada.Codigo);
        if (autores.Count > 0)        
            throw new ErrorsFoundException(new List<string>() 
            { String.Format("Codigo Autor: {0} ja cadastrado - Nome: {1}", autores[0].Codigo, autores[0].Nome) 
            });        

        autores = await LerAutorAsync(entrada.Nome);
        if (autores.Count > 0)
            throw new ErrorsFoundException(new List<string>()
            { String.Format("Nome Autor: {0} ja cadastrado - Codigo: {1}", autores[0].Nome, autores[0].Codigo)
            });

        var livro = new Autor() { Codigo = entrada.Codigo, Nome = entrada.Nome };
        _autorRepositorio.Create(livro);
        await Task.Yield();
    }

    private void EntradaAutorAddValidator(EntradaAutorDto entrada)
    {
        var validator = new AutorValidator(EnumClass.EMethodAutorValidator.AddAutor);
        var result = validator.Validate(entrada);
        if (!result.IsValid)
            throw new ErrosDeValidacaoException(result.Errors.Select(e => e.ErrorMessage).ToList());
            //throw new ErrorsNotFoundException(result.Errors.Select(e => e.ErrorMessage).ToList());
    }
}
