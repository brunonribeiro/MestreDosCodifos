using System;

namespace ParametrosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Diferença entre OUT e REF");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Vamos somar 100 a um valor, usando o OUT e o REF");


            Console.Write("Digite um valor: ");
            int.TryParse(Console.ReadLine(), out var a);
            Console.WriteLine();

            Somar100Ref(ref a);
            Console.WriteLine($"Com o REF a variável mantém o valor que tinha quando foi passado na função, " +
                $"e não precisa ser inicilizada dentro do método.");
            Console.WriteLine($"Resultado fica: {a}");
            Console.WriteLine();

            Somar100Out(out a);
            Console.WriteLine($"Com o OUT a variável deve ser incializada dentro do método e só recebe o resultado, " +
                $"não levando em conta o valor que tinha antes de chegar na função.");
            Console.WriteLine($"Resultado fica: {a}");

            Console.ReadKey();
        }

        private static void Somar100Out(out int valor)
        {
            valor = 0;
            valor += 100;
        }

        private static void Somar100Ref(ref int valor)
        {
            valor += 100;
        }
    }
}
