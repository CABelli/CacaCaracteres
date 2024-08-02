using System.Diagnostics;
using System.Text;

namespace CacaCaracteres.ServicosCPF;

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
        for (int i = 0; i < 100000000; i++)
        {
            sut("771.189.500-33");
            sut("771.189.500-34");
            if (versionCalculate > 0)
            {
                var pessoa = new Pessoa(i, "Ce");
                //var pessoa1 = new Pessoa(i, "Ce");
                //var pessoa2 = new Pessoa(i, "Ce");
                //var pessoa3 = new Pessoa(i, "Ce");
                //var pessoa4 = new Pessoa(i, "Ce");
                //var pessoa5 = new Pessoa(i, "Ce");
            }
        }
        sw.Stop();
        Console.WriteLine($" tipo: {versionCalculate}");
        Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"GC Gen #2 : {GC.CollectionCount(2) - before2}");
        Console.WriteLine($"GC Gen #1 : {GC.CollectionCount(1) - before1}");
        Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - before0}");
        Console.WriteLine(" ");
        //var result = CalculateCPF.PreperCPF(sourceCPF);
        return true;
    }

    public bool Validation02GC(int versionCalculate)
    {
        var sw = new Stopwatch();
        var before12 = GC.CollectionCount(2);
        var before11 = GC.CollectionCount(1);
        var before10 = GC.CollectionCount(0);
        Func<string, bool> sut;
        sut = CalculateCPF.PreperCPF;
                         ///100000000
        sw.Start();
        for (int i = 0; i < 50000000; i++)
        {
            sut("771.189.500-33");
            sut("771.189.500-34");
            if (versionCalculate == 0) cratePessoa(i);
            else c02(i);// crateMemoryStream(i);
        }
        sw.Stop();

        //string fileToWriteTo = "test.txt";
        //byte[] test = Encoding.ASCII.GetBytes("C# Stream to File Example");

        //using (MemoryStream memoryStream = new MemoryStream(test))
        //{
        //    using Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create);

        //    memoryStream.Position = 0;
        //}

        Console.WriteLine($" tipo: {versionCalculate}");
        Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"GC Gen #12 : {GC.CollectionCount(2) - before12}");
        Console.WriteLine($"GC Gen #11 : {GC.CollectionCount(1) - before11}");
        Console.WriteLine($"GC Gen #10 : {GC.CollectionCount(0) - before10}");
        Console.WriteLine(" ");
        return true;
    }

    private void cratePessoa(int i)
    {
        var pessoa1 = new Pessoa(i, "Ce");
        var pessoa2 = new Pessoa(i, "Ce2");
        var pessoa3 = new Pessoa(i, "Ce3");
        var pessoa4 = new Pessoa(i, "Ce4");
        var pessoa5 = new Pessoa(i, "Ce5");
    }

    private void crateMemoryStream(int i)
    {
        string fileToWriteTo = @"c:/temp/teste.txt";
        //"d:/Repos-Estudo-Gr/CacaCaracteres/CacaCaracteres/CacaCaracteres/teste.txt";
        //"c:/temp/test.txt";
        byte[] test = Encoding.ASCII.GetBytes("C# Stream to File Example " + i);

        using (MemoryStream memoryStream = new MemoryStream(test))
        {
            using Stream streamToWriteTo0 = File.Open(fileToWriteTo, FileMode.Create);

            memoryStream.Position = 0;
        }
    }
    private void c02(int i)
    {
        if (i < 500)
        {
            string path = @"c:\temp\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");

                    sw.Dispose();
                }
            }

            // Open the file to read from.
            var tot = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(s);
                    tot ++;
                }
            }
        }
    }
}

public class Pessoa
{
    public Pessoa(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
}
