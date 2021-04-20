using System;
using System.Collections.Generic;
using System.Linq;

namespace PessoaApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var pessoas = new List<Pessoa>();

            int opcao = ExibirMenu();

            while (opcao >= (int)OpcaoEnum.Adicionar && opcao <= (int)OpcaoEnum.Listar)
            {
                Executar(pessoas, (OpcaoEnum)opcao);

                Console.Clear();
                opcao = ExibirMenu();
            }
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar nova pessoa");
            Console.WriteLine("2 - Listar pessoas");
            Console.WriteLine();
            Console.WriteLine("Digite 0 para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static void Executar(List<Pessoa> pessoas, OpcaoEnum opcao)
        {
            switch (opcao)
            {
                case OpcaoEnum.Adicionar:
                    Adicionar(pessoas);
                    break;
                case OpcaoEnum.Listar:
                    Listar(pessoas);
                    break;
                default:
                    break;
            }
        }

        private static void Adicionar(List<Pessoa> pessoas)
        {
            ConsoleKeyInfo tecla;
            do
            {
                var pessoa = new Pessoa();
                Console.Clear();
                Console.Write("Digite o nome : ");
                pessoa.Nome = Console.ReadLine();

                Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
                pessoa.DataNascimento = Console.ReadLine();

                Console.Write("Digite a altura: ");
                decimal.TryParse(Console.ReadLine(), out var altura);
                pessoa.Altura = altura;

                pessoas.Add(pessoa);

                Console.WriteLine();
                Console.WriteLine("Pressione ESQ para voltar para o menu");
                Console.WriteLine("Pressione ENTER para continuar adicionando");

                Console.WriteLine();
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Escape);
        }

        private static void Listar(List<Pessoa> pessoas)
        {
            Console.Clear();
            if (pessoas.Count > 0)
            {
                Console.WriteLine("Lista de pessoas");
                Console.WriteLine("------------------");

                pessoas.Sort();
                foreach (var pessoa in pessoas)
                {
                    Console.WriteLine(pessoa.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nenhuma pessoa adicionada");
            }

            Console.ReadKey();
        }
    }
}
