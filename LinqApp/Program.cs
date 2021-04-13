using System;
using System.Collections.Generic;

namespace LinqApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manipulador = new ManipulardorDeLista();
            //Transforme todos os números da lista em um Array.

            int opcao = ExibirMenu();

            while (opcao >= (int)OpcaoEnum.IncluirNoInicio && opcao <= (int)OpcaoEnum.ExibirNumeroInformado)
            {
                Executar(manipulador, (OpcaoEnum)opcao);

                Console.Clear();
                opcao = ExibirMenu();
            }
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar um número no inicio");
            Console.WriteLine("2 - Adicionar um número no final");
            Console.WriteLine("3 - Remover o primeiro número");
            Console.WriteLine("4 - Remover o último número");
            Console.WriteLine("5 - Imprimir todos os números da lista");
            Console.WriteLine("6 - Imprimir todos os números da lista na ordem crescente");
            Console.WriteLine("7 - Imprimir todos os números da lista na ordem decrescente");
            Console.WriteLine("8 - Imprima apenas o primeiro número da lista");
            Console.WriteLine("9 - Imprima apenas o ultimo número da lista");
            Console.WriteLine("10 - Retorne apenas números pares");
            Console.WriteLine("11 - Retorne apenas números impares");
            Console.WriteLine("12 - Recupere um número específico");

            Console.WriteLine();
            Console.WriteLine("Digite 0 para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static void Executar(ManipulardorDeLista manipulador, OpcaoEnum opcao)
        {
            switch (opcao)
            {
                case OpcaoEnum.IncluirNoInicio:
                    ReceberValor(manipulador.AdicionarNoInicio);
                    break;
                case OpcaoEnum.IncluirNoFinal:
                    ReceberValor(manipulador.AdicionarNoFinal);
                    break;
                case OpcaoEnum.RemoverPrimeiro:
                    manipulador.RemoverPrimeiro();
                    ExibirMensagem("O primeiro número da lista foi removido!");
                    break;
                case OpcaoEnum.RemoverUltimo:
                    manipulador.RemoverUltimo();
                    ExibirMensagem("O último número da lista foi removido!");
                    break;
                case OpcaoEnum.ListarTodos:
                    ExibirResultado("Listar todos os números", string.Join(",", manipulador.ListarTodos()));
                    break;
                case OpcaoEnum.ListaOrdemCrescente:
                    Listar("Listar números em ordem crescente", manipulador.ListarEmOrdemCrescente());
                    break;
                case OpcaoEnum.ListaOrdemDecrescente:
                    Listar("Listar números em ordem decrescente", manipulador.ListarEmOrdemDecrescente());
                    break;
                case OpcaoEnum.ExibirApenasPrimeiro:
                    ExibirResultado("Exibir primeiro número", manipulador.ExibirPrimeiro()?.ToString());
                    break;
                case OpcaoEnum.ExibirApenasUltimo:
                    ExibirResultado("Exibir último número", manipulador.ExibirUltimo()?.ToString());
                    break;
                case OpcaoEnum.ListarApenasPares:
                    Listar("Listar números em ordem crescente", manipulador.ListarPares());
                    break;
                case OpcaoEnum.ListarApenasImpares:
                    Listar("Listar números em ordem decrescente", manipulador.ListarImpares());
                    break;
                case OpcaoEnum.ExibirNumeroInformado:
                    int numero = ReceberValor();
                    ExibirResultado("Exibir número informado", manipulador.ExibirNumeroInformado(numero)?.ToString());
                    break;
                default:
                    break;
            }
        }

        private static void ReceberValor(Action<int> adicionar)
        {
            ConsoleKeyInfo tecla;
            do
            {
                int valor = ReceberValor();

                adicionar(valor);

                Console.WriteLine();
                Console.WriteLine("Pressione ESQ para voltar para o menu");
                Console.WriteLine("Pressione ENTER para continuar adicionando");

                Console.WriteLine();
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Escape);
        }

        private static int ReceberValor()
        {
            Console.Clear();
            Console.Write("Digite um valor: ");
            int.TryParse(Console.ReadLine(), out var valor);
            return valor;
        }

        private static void Listar(string titulo, List<int?> valores)
        {
            Console.Clear();

            if (valores.Count > 0)
            {
                Console.WriteLine($"{titulo}");
                Console.WriteLine("------------------------");

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

        private static void ExibirResultado(string titulo, string valor)
        {
            Console.Clear();

            if (valor != null)
            {
                Console.WriteLine($"{titulo}");
                Console.WriteLine("------------------------");
                Console.WriteLine(valor);
            }
            else
            {
                Console.WriteLine("O número não foi encontrado");
            }

            Console.ReadKey();
        }

        private static void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
