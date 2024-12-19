using CacaCaracteres.Dto;
using CacaCaracteres.EnumClass;
using CacaCaracteres.Resources.Servicos;
using FluentValidation;

namespace CacaCaracteres.Validator;

public class AutorValidator : AbstractValidator<EntradaAutorDto>
{
    private int MinNumberOfCharacName = 4;
    private int MaxNumberOfCharacName = 12;

    public AutorValidator(EMethodAutorValidator method)
    {
        switch (method)
        {
            case EMethodAutorValidator.AddAutor: ValidatorAddAutor();
            return;
        }
    }

    public void ValidatorAddAutor()
    {
        ValidatorName();
    }

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
}
