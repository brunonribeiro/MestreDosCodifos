using System;

namespace CalculadoraApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opcaoEscolhida = ExibirMenu();
            while (opcaoEscolhida >= 1 && opcaoEscolhida <= 4)
            {
                Console.Write("Digite primeiro número: ");
                int.TryParse(Console.ReadLine(), out var numero1);
                Console.WriteLine(RetornarSeNumeroEhParOuImpar(numero1));
                Console.WriteLine();

                Console.Write("Digite segundo número: ");
                int.TryParse(Console.ReadLine(), out var numero2);
                Console.WriteLine(RetornarSeNumeroEhParOuImpar(numero2));
                Console.WriteLine();

                ExecutarCalculo((OpcaoEnum)opcaoEscolhida, numero1, numero2);
                Console.ReadKey();
                Console.Clear();
                opcaoEscolhida = ExibirMenu();
            } 
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicar");
            Console.WriteLine("4 - Dividir");
            Console.WriteLine("Digite qualquer outro valor para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static string RetornarSeNumeroEhParOuImpar(int numero2)
        {
            return "Numero é: " + (numero2 % 2 == 0 ? "Par" : "Ímpar");
        }

        private static void ExecutarCalculo(OpcaoEnum opcao, int numero1, int numero2)
        {
            RetornoModel resultado;
            switch (opcao)
            {
                case OpcaoEnum.Somar:
                    resultado = Calculador.Somar(numero1, numero2);
                    ExibirResultado(resultado);
                    break;
                case OpcaoEnum.Subtrair:
                    resultado = Calculador.Subtrair(numero1, numero2);
                    ExibirResultado(resultado);
                    break;
                case OpcaoEnum.Multiplicar:
                    resultado = Calculador.Multiplicar(numero1, numero2);
                    ExibirResultado(resultado);
                    break;
                case OpcaoEnum.Dividir:
                    resultado = Calculador.Dividir(numero1, numero2);
                    ExibirResultado(resultado);
                    break;
                default:
                    ExibirErro("Opção escolhida está inválida");
                    break;
            }
        }

        private static void ExibirResultado(RetornoModel resultado)
        {
            if (resultado.CalculadoEfetuado)
            {
                ExibirCalculo(resultado.Valor);
            }
            else
            {
                ExibirErro(resultado.MensagemErro);
            }
        }

        private static void ExibirCalculo(decimal valor)
        {
            Console.WriteLine($"Resultado: {valor}");
        }

        private static void ExibirErro(string mensagem)
        {
            Console.WriteLine($"Erro: {mensagem}");
        }
    }
}
