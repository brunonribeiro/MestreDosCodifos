using System;
using System.Collections.Generic;
using System.Linq;

namespace SalarioApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var funcionarios = new List<Funcionario>();

            int opcao = ExibirMenu();

            while (opcao >= 1 && opcao <= 4)
            {
                Executar(funcionarios, (OpcaoEnum)opcao);

                Console.Clear();
                opcao = ExibirMenu();
            }
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar novo funcionario");
            Console.WriteLine("2 - Visualizar maior salário");
            Console.WriteLine("3 - Visualizar menor salário");
            Console.WriteLine("4 - Listar todos");
            Console.WriteLine("Digite qualquer outro valor para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static void Executar(List<Funcionario> funcionarios, OpcaoEnum opcao)
        {
            switch (opcao)
            {
                case OpcaoEnum.Adicionar:
                    AdicionaNovo(funcionarios);
                    break;
                case OpcaoEnum.MaiorSalario:
                    ExibirMaiorSalario(funcionarios);
                    break;
                case OpcaoEnum.MenorSalario:
                    ExibirMenorSalario(funcionarios);
                    break;
                case OpcaoEnum.ListarTodos:
                    ListarTodos(funcionarios);
                    break;
                default:
                    break;
            }
        }

        private static void AdicionaNovo(List<Funcionario> funcionarios)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                Console.Write("Digite o nome do funcionário: ");
                var nome = Console.ReadLine();

                Console.Write("Digite o salário do funcionário: ");
                var salario = Console.ReadLine();

                funcionarios.Add(new Funcionario(nome, salario));

                Console.WriteLine();
                Console.WriteLine("Preciose ESQ para voltar para o menu");
                Console.WriteLine("Preciose ENTER para continuar adicionando");

                Console.WriteLine();
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Escape);
        }

        private static void ExibirMaiorSalario(List<Funcionario> funcionarios)
        {
            Console.Clear();
            if (funcionarios.Count > 0)
            {
                Console.WriteLine("Maior Salário");
                Console.WriteLine("--------------");

                var funcionarioComMaiorSalario = new Funcionario();
                for (int i = 0; i < funcionarios.Count; i++)
                {
                    if (funcionarios[i].Salario > funcionarioComMaiorSalario.Salario)
                    {
                        funcionarioComMaiorSalario = funcionarios[i];
                    }
                }

                Console.WriteLine($"{funcionarioComMaiorSalario.Nome} - Salário: {funcionarioComMaiorSalario.Salario}");
            }
            else
            {
                Console.WriteLine("Nenhum funcionário adicionado");
            }

            Console.ReadKey();
        }

        private static void ExibirMenorSalario(List<Funcionario> funcionarios)
        {
            Console.Clear();
            if (funcionarios.Count > 0)
            {
                Console.WriteLine("Menor Salário");
                Console.WriteLine("--------------");

                var funcionarioComMenorSalario = funcionarios.FirstOrDefault();
                for (int i = 0; i < funcionarios.Count; i++)
                {
                    if (funcionarios[i].Salario < funcionarioComMenorSalario.Salario)
                    {
                        funcionarioComMenorSalario = funcionarios[i];
                    }
                }

                Console.WriteLine($"{funcionarioComMenorSalario.Nome} - Salário: {funcionarioComMenorSalario.Salario}");
            }
            else
            {
                Console.WriteLine("Nenhum funcionário adicionado");
            }

            Console.ReadKey();
        }

        private static void ListarTodos(List<Funcionario> funcionarios)
        {
            Console.Clear();

            if (funcionarios.Count > 0)
            {
                Console.WriteLine("Lista de Funcionarios");
                Console.WriteLine("---------------------");

                for (int i = 0; i < funcionarios.Count; i++)
                {
                    Console.WriteLine($"Nome: {funcionarios[i].Nome} - Salário: {funcionarios[i].Salario}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário adicionado");
            }

            Console.ReadKey();
        }

    }
}
