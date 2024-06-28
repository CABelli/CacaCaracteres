using System.Diagnostics;

namespace CacaCaracteres.ServicosCPF
{
    public class ValidationCPF : IValidationCPF
    {
        public bool ValidationGC(int versionCalculate)
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);
            Func<string, bool> sut;
            if (versionCalculate == 0)
                sut = CalculateCPF.PreperCPF;
            else
                sut = CalculateCPF02.PreperCPF;

            sw.Start();
            for (int i = 0; i < 30000000; i++)
            {
                sut("771.189.500-33");
                sut("771.189.500-34");
            }
            sw.Stop();

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"GC Gen #2 : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1 : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - before0}");

            //var result = CalculateCPF.PreperCPF(sourceCPF);
            return true;
        }
    }
}
