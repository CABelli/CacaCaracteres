using System.Runtime.Serialization;

namespace CacaCaracteres.ExceptionBase;

[Serializable]
public class ErrorsNotFoundException : LivroTextoException
{
    public List<string> MensagensDeErro {  get; set; }

    public ErrorsNotFoundException(List<string> mensagensDeErro) : base (string.Empty) 
    {
        MensagensDeErro = mensagensDeErro;
    }

    protected ErrorsNotFoundException(SerializationInfo info, StreamingContext context) : base (info, context) 
    { }
}
