using System.Runtime.Serialization;

namespace CacaCaracteres.ExceptionBase;

[Serializable]
public class ErrosDeValidacaoException : LivroTextoException
{
    public List<string> MensagensDeErro {  get; set; }                        

    public ErrosDeValidacaoException(List<string> mensagensDeErro) : base(string.Empty)
    {
        MensagensDeErro = mensagensDeErro;
    }

    protected ErrosDeValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context) 
    { 
    }
}
