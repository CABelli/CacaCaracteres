using System.ComponentModel;

namespace CacaCaracteres.EnumClass;

public enum EMethodAutorValidator
{
    [Description("AddAutor")]
    AddAutor = 1,
    [Description("DeleteAutor")]
    DeleteAutor = 2,
    [Description("ModifyAutor")]
    ModifyAutor = 3
}
