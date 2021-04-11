using System;
using System.Collections.Generic;
using System.Linq;

namespace AlunosApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var alunos = new List<Aluno>();

            int opcao = ExibirMenu();

            while (opcao >= 1 && opcao <= 2)
            {
                Executar(alunos, (OpcaoEnum)opcao);

                Console.Clear();
                opcao = ExibirMenu();
            }
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar novo aluno");
            Console.WriteLine("2 - Listar com média maior que 7");
            Console.WriteLine();
            Console.WriteLine("Digite qualquer outro valor para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static void Executar(List<Aluno> alunos, OpcaoEnum opcao)
        {
            switch (opcao)
            {
                case OpcaoEnum.Adicionar:
                    AdicionaNovo(alunos);
                    break;
                case OpcaoEnum.ListarAprovados:
                    ExibirAlunosAprovados(alunos);
                    break;
                default:
                    break;
            }
        }

        private static void AdicionaNovo(List<Aluno> alunos)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                Console.Write("Digite o nome do aluno: ");
                var nome = Console.ReadLine();

                Console.Write("Digite a nota do aluno: ");
                var nota = Console.ReadLine();

                alunos.Add(new Aluno(nome, nota));

                Console.WriteLine();
                Console.WriteLine("Pressione ESQ para voltar para o menu");
                Console.WriteLine("Pressione ENTER para continuar adicionando");

                Console.WriteLine();
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Escape);
        }

        private static void ExibirAlunosAprovados(List<Aluno> alunos)
        {
            Console.Clear();
            if (alunos.Count > 0)
            {
                Console.WriteLine("Alunos com médias superiores a 7");
                Console.WriteLine("--------------------------------");

                foreach (var aluno in alunos.OrderBy(x => x.Nome))
                {
                    if (aluno.Nota > 7)
                    {
                        Console.WriteLine($"Nome: {aluno.Nome} - Nota: {aluno.Nota}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum aluno adicionado");
            }

            Console.ReadKey();
        }
    }
}
