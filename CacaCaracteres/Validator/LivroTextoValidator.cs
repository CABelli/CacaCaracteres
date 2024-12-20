using CacaCaracteres.Dto;
using CacaCaracteres.EnumClass;
using FluentValidation;

namespace CacaCaracteres.Validator;

public class LivroTextoValidator : AbstractValidator<EntradaLivroTextoDto>
{
    private int MinNumberOfCharacTexto = 3;
    private int MaxNumberOfCharacTexto = 30;
    private int MinNumberOfCharacCodTexto = 1;
    private int MaxNumberOfCharacCodTexto = 30;

    public LivroTextoValidator (EMethodLivroTextoValidator method)
    {
        switch (method) 
        {
            case EMethodLivroTextoValidator.AddLivroTexto:
                ValidatorAddLivroTexto();

            return;
        }
    }

    public void ValidatorAddLivroTexto()
    {
        //throw new NotImplementedException();
    }
}
