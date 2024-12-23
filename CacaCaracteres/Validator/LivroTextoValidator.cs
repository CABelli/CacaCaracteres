using CacaCaracteres.Dto;
using CacaCaracteres.EnumClass;
using CacaCaracteres.Resources.Servicos;
using FluentValidation;

namespace CacaCaracteres.Validator;

public class LivroTextoValidator : AbstractValidator<EntradaLivroTextoDto>
{
    private int MinNumberOfCharacTexto = 3;
    private int MaxNumberOfCharacTexto = 30;
    private int MinNumberOfCharacCodTexto = 1;
    private int MaxNumberOfCharacCodTexto = 10;

    public LivroTextoValidator (EMethodLivroTextoValidator method)
    {
        switch (method) 
        {
            case EMethodLivroTextoValidator.AddLivroTexto:
                ValidatorAddLivroTexto();
            return;

            case EMethodLivroTextoValidator.AlteraLivroTexto:
                ValidatorAlteraLivroTexto();
            return;
        }
    }

    public void ValidatorAddLivroTexto()
    {
        ValidatorCodigoTexto();
        ValidatorTexto();
    }

    private void ValidatorAlteraLivroTexto()
    {
        ValidatorCodigoTexto();
        ValidatorTexto();
    }

    private void ValidatorCodigoTexto()
    {
        RuleFor(x => x.CodigoTexto)
            .InclusiveBetween(MinNumberOfCharacCodTexto, MaxNumberOfCharacCodTexto)
            .WithMessage(x => String.Format(Resource.AutorValidator_Error_CharacCodTexto,
                                            x.CodigoTexto,
                                            MinNumberOfCharacCodTexto,
                                            MaxNumberOfCharacCodTexto));
    }

    private void ValidatorTexto()
    {
        RuleFor(x => x.Texto)
            .Length(MinNumberOfCharacTexto, MaxNumberOfCharacTexto)
            .WithMessage(x => String.Format(Resource.AutorValidator_Error_CharacTexto,
                                                x.Texto,
                                                MinNumberOfCharacTexto,
                                                MaxNumberOfCharacTexto));                                                        
    }
}
