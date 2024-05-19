namespace CacaCaracteres.ExtensoesCaracteres
{
    public static class ExtensaoCaracter
    {
        public static char? RetornaLetra(this char caracter)
        {
            if ((caracter >= 'a' && caracter <= 'z') || 
                (caracter >= 'A' && caracter <= 'Z')) return caracter;
            return null;            
        }

        public static char? RetornaVogal(this char caracter)
        {
            if ( "aeiouAEIOU".Contains(caracter)) return caracter;
            return null;
        }
    }
}
