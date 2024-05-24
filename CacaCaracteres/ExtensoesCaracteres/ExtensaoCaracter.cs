namespace CacaCaracteres.ExtensoesCaracteres
{
    public static class ExtensaoCaracter
    {
        public static char? RetornaLetra(this char caracter)
        {
            if (caracter >= 'a' && caracter <= 'z') return caracter;
            return null;            
        }

        public static char? RetornaVogal(this char caracter)
        {
            if ("aeiou".Contains(caracter)) return caracter;
            return null;
        }

        public static char? RetornaConsoante(this char caracter)
        {
            if ( RetornaLetra(caracter) == caracter && 
                RetornaVogal(caracter) == null ) return caracter;
            return null;
        }
    }
}
