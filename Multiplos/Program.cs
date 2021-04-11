using System;

namespace MultiplosApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Números múltiplos de 3, entre 1 e 100");
            Console.WriteLine();

            var numero = 1;
            while (numero <= 100)
            {
                if (numero % 3 == 0)
                {
                    Console.WriteLine(numero);
                }

                numero++;
            }

            Console.ReadKey();
        }
    }
}
