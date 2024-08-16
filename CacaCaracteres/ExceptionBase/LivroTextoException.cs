using System.Runtime.Serialization;

namespace CacaCaracteres.ExceptionBase;

[Serializable]
public class LivroTextoException : SystemException
{
    public LivroTextoException(string mensagem) : base(mensagem) 
    { }

    protected LivroTextoException(SerializationInfo info, StreamingContext context) : base (info, context) 
    { }
}
