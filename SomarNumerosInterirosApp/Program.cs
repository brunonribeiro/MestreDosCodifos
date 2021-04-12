using System;

namespace SomarInterirosApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Somar os que forem pares");
            Console.WriteLine("-------------------------");


            Console.Write("Digite o 1º valor inteiro: ");
            int.TryParse(Console.ReadLine(), out var numero1);
            Console.WriteLine();

            Console.Write("Digite o 2º valor inteiro: ");
            int.TryParse(Console.ReadLine(), out var numero2);
            Console.WriteLine();

            Console.Write("Digite o 3º valor inteiro: ");
            int.TryParse(Console.ReadLine(), out var numero3);
            Console.WriteLine();

            Console.Write("Digite o 4º valor inteiro: ");
            int.TryParse(Console.ReadLine(), out var numero4);
            Console.WriteLine();

            int total = 0;
            Somar(numero1, ref total);
            Somar(numero2, ref total);
            Somar(numero3, ref total);
            Somar(numero4, ref total);

            Console.WriteLine($"Resultado: {total}");
            Console.ReadKey();
        }

        private static void Somar(int numero, ref int total)
        {
            total += numero % 2 == 0 ? numero : 0;
        }
    }
}
