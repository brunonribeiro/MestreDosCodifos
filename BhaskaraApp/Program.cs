using System;

namespace BhaskaraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                Console.WriteLine("Calculador da Fórmula de Bhaskara");
                Console.WriteLine("---------------------------------");

                Console.Write("Digite o valor de A: ");
                double.TryParse(Console.ReadLine(), out var a);
                Console.WriteLine();

                Console.Write("Digite o valor de B: ");
                double.TryParse(Console.ReadLine(), out var b);
                Console.WriteLine();

                Console.Write("Digite o valor de C: ");
                double.TryParse(Console.ReadLine(), out var c);
                Console.WriteLine();

                Console.WriteLine("-----------------------------");

                var delta = CalcularDelta(a, b, c);

                if (delta < 0)
                {
                    Console.WriteLine($"Delta menor que zero");
                }
                else
                {
                    var resultados = CalcularBhaskara(a, b, delta);

                    Console.WriteLine($"Resultado de R1: {resultados.Item1}");
                    Console.WriteLine($"Resultado de R2: {resultados.Item2}");
                }

                Console.WriteLine();
                Console.WriteLine("Pressione ESQ para sair");
                Console.WriteLine("Pressione ENTER para continuar");

                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Escape);
        }

        private static double CalcularDelta(double a, double b, double c)
        {
            return Math.Pow(b, 2) - (4 * a * c);
        }

        private static (double, double) CalcularBhaskara(double a, double b, double delta)
        {
            var r1 = ((-b) + Math.Sqrt(delta)) / (2 * a);
            var r2 = ((-b) - Math.Sqrt(delta)) / (2 * a);
            return (r1, r2);
        }
    }
}
