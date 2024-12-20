using CacaCaracteres.Dto;
using CacaCaracteres.EnumClass;
using CacaCaracteres.Resources.Servicos;
using FluentValidation;

namespace CacaCaracteres.Validator;

public class AutorValidator : AbstractValidator<EntradaAutorDto>
{
    private int MinNumberOfCharacName = 4;
    private int MaxNumberOfCharacName = 12;
    private int MinNumberOfCharacCodAutor = 1;
    private int MaxNumberOfCharacCodAutor = 10;

    public AutorValidator(EMethodAutorValidator method)
    {
        switch (method)
        {
            case EMethodAutorValidator.AddAutor: 
                ValidatorAddAutor();
                return;

            case EMethodAutorValidator.DeleteAutor:
                ValidatorDeleteAutor();
                return;
        }
    }

    public void ValidatorAddAutor()
    {
        ValidatorName();
        ValidatorCodigoAutor();
    }
    public void ValidatorDeleteAutor()
    { }

    private void ValidatorName()
    {
        RuleFor(Rec => Rec.Nome)
            .Length(MinNumberOfCharacName, MaxNumberOfCharacName)
            .WithMessage(Rec => string.Format(Resource.AutorValidator_Error_CharacName,
                                                  Rec.Nome.Length,
                                                  MinNumberOfCharacName,
                                                  MaxNumberOfCharacName
                                                  ));
    }

    private void ValidatorCodigoAutor()
    {
        RuleFor(Rec => Rec.Codigo).InclusiveBetween(MinNumberOfCharacCodAutor, MaxNumberOfCharacCodAutor)
            .WithMessage(Rec => string.Format(Resource.AutorValidator_Error_CharacCodigo,
                                                    MinNumberOfCharacCodAutor,
                                                    MaxNumberOfCharacCodAutor));
    }
}
