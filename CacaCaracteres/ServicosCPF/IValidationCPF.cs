namespace CacaCaracteres.ServicosCPF
{
    public interface IValidationCPF
    {
        bool ValidationGC(int versionCalculate);

        bool Validation02GC(int versionCalculate);
    }
}
