using System.Runtime.Serialization;

namespace CacaCaracteres.ExceptionBase;

public class ErrorsFoundException : LivroTextoException
{
    public List<string> MensagensDeErro { get; set; }

    public ErrorsFoundException(List<string> mensagensDeErro) : base(string.Empty)
    {
        MensagensDeErro = mensagensDeErro;
    }

    protected ErrorsFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}

