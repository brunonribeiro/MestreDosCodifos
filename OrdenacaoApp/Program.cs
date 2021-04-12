using System;
using System.Collections.Generic;

namespace OrdenacaoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var valores = new List<decimal>();

            int opcao = ExibirMenu();

            while (opcao >= 1 && opcao <= 3)
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
            Console.WriteLine("1 - Adicionar um novo valor");
            Console.WriteLine("2 - Listar em ordem crescente");
            Console.WriteLine("3 - Listar em ordem decrescente");
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
            switch (opcao)
            {
                case OpcaoEnum.Incluir:
                    AdicionaNovo(valores);
                    break;
                case OpcaoEnum.ListarCrescente:
                    ListarCrescente(valores);
                    break;
                case OpcaoEnum.ListarDecrescente:
                    ListarDecrescente(valores);
                    break;
                default:
                    break;
            }
        }
        private static void AdicionaNovo(List<decimal> valores)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                Console.Write("Digite um valor: ");
                decimal.TryParse(Console.ReadLine(), out var valor);

                valores.Add(valor);

                Console.WriteLine();
                Console.WriteLine("Pressione ESQ para voltar para o menu");
                Console.WriteLine("Pressione ENTER para continuar adicionando");

                Console.WriteLine();
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Escape);
        }

        private static void ListarCrescente(List<decimal> valores)
        {
            valores.Sort();
            Listar(valores, "Crescente");
        }

        private static void ListarDecrescente(List<decimal> valores)
        {
            valores.Sort(delegate (decimal x, decimal y)
            {
                return y.CompareTo(x);
            });

            Listar(valores, "Descrescente");
        }

        private static void Listar(List<decimal> valores, string ordem)
        {
            Console.Clear();

            if (valores.Count > 0)
            {
                Console.WriteLine($"Lista em ordem {ordem}");
                Console.WriteLine("---------------------");

                foreach (var item in valores)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Nenhum valor adicionado");
            }

            Console.ReadKey();
        }

    }
}
