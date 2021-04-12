using System;
using System.Collections.Generic;

namespace LinqApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var valores = new List<decimal>();

            int opcao = ExibirMenu();

            while (opcao >= 1 && opcao <= 2)
            {
                Executar(valores, (OpcaoEnum)opcao);

                Console.Clear();
                opcao = ExibirMenu();
            }
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar um valor no inicio");
            Console.WriteLine("2 - Adicionar um valor no final");
            Console.WriteLine("Digite qualquer outro valor para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static void Executar(List<decimal> valores, OpcaoEnum opcao)
        {
            throw new NotImplementedException();
        }
    }
}
