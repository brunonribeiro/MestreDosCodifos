using ContaBancariaApp.Base;
using ContaBancariaApp.Enums;
using ContaBancariaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContaBancariaApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaBancaria>();

            int opcao = ExibirMenu();

            while (opcao >= (int)OpcaoEnum.AdicionarConta && opcao <= (int)OpcaoEnum.Listar)
            {
                Executar(contas, (OpcaoEnum)opcao);

                Console.Clear();
                opcao = ExibirMenu();
            }
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar nova conta");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Listar contas");
            Console.WriteLine();
            Console.WriteLine("Digite 0 para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static void Executar(List<ContaBancaria> contas, OpcaoEnum opcao)
        {
            switch (opcao)
            {
                case OpcaoEnum.AdicionarConta:
                    Adicionar(contas);
                    break;
                case OpcaoEnum.Sacar:
                    var contaParaSaque = SelecionarConta(contas);

                    if (contaParaSaque != null)
                    {
                        Console.WriteLine($"Saldo da conta: {contaParaSaque.SaldoFormatado}");
                        Console.WriteLine();
                       
                        if (contaParaSaque is ContaEspecial)
                        {
                            var contaEspecial = contaParaSaque as ContaEspecial;
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine($"Limite para saque da Conta Especial: {contaEspecial.Limite:c}");
                            Console.WriteLine();
                        }

                        ExecutarTransacao(contaParaSaque, "Saque", contaParaSaque.Sacar);
                    }
                    else
                    {
                        ContaNaoEncontrada();
                    }
                    break;
                case OpcaoEnum.Depositar:
                    var contaParaDeposito = SelecionarConta(contas);

                    if (contaParaDeposito != null)
                    {
                        ExecutarTransacao(contaParaDeposito, "Depósito", contaParaDeposito.Depositar);
                    }
                    else
                    {
                        ContaNaoEncontrada();
                    }
                    break;
                case OpcaoEnum.Listar:
                    Listar(contas);
                    break;
                default:
                    break;
            }
        }

        private static void Adicionar(List<ContaBancaria> contas)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Conta Corrente");
                Console.WriteLine("2 - Conta Especial");
                Console.WriteLine();
                Console.Write("Selecione o tipo da conta: ");
                int.TryParse(Console.ReadLine(), out var tipo);
                Console.WriteLine();

                var conta = CriarConta(tipo);

                if (conta != null)
                {
                    Console.Write("Digite o número da conta: ");
                    long.TryParse(Console.ReadLine(), out var numero);
                    conta.NumeroDaConta = numero;

                    contas.Add(conta);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Tipo da conta inválido");
                    Console.WriteLine();
                }

                Console.WriteLine("Pressione ESQ para voltar para o menu");
                Console.WriteLine("Pressione ENTER para continuar adicionando");

                Console.WriteLine();
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Escape);
        }

        private static ContaBancaria SelecionarConta(List<ContaBancaria> contas)
        {
            Console.Clear();
            Console.Write("Digite o número da conta: ");
            long.TryParse(Console.ReadLine(), out var numero);
            Console.WriteLine();
            return contas.FirstOrDefault(x => x.NumeroDaConta.Equals(numero));
        }

        private static void ExecutarTransacao(ContaBancaria conta, string transacao, Func<double, Retorno> acao)
        {
            if (conta is ContaCorrente)
            {
                var contaCorrente = conta as ContaCorrente;
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Taxa da Operação para Conta Corrente: {contaCorrente.TaxaDeOperacao:c}");
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------------");
            Console.Write($"Digite o valor do {transacao}: ");
            double.TryParse(Console.ReadLine(), out var valor);
            var resultado = acao(valor);
            Console.WriteLine();

            if (resultado.TransacaoEfetuada)
            {
                Console.WriteLine($"O {transacao} foi efetuado com sucesso.\nSaldo da conta: {conta.SaldoFormatado}");
            }
            else
            {
                Console.WriteLine(resultado.Erro);
            }

            Console.ReadKey();
        }

        private static void ContaNaoEncontrada()
        {
            Console.WriteLine("Conta não encontrada");
            Console.ReadKey();
        }

        private static ContaBancaria CriarConta(int tipo)
        {
            if (tipo == (int)TipoContaBancariaEnum.ContaCorrente)
            {
                return new ContaCorrente();
            }
            else if (tipo == (int)TipoContaBancariaEnum.ContaEspecial)
            {
                return new ContaEspecial();
            }

            return null;
        }

        private static void Listar(List<ContaBancaria> contas)
        {
            Console.Clear();
            if (contas.Count > 0)
            {
                Console.WriteLine("Lista de Contas Bancárias");
                Console.WriteLine("--------------------------");

                foreach (var conta in contas.OrderBy(x => x.NumeroDaConta))
                {
                    Console.WriteLine(conta.MostrarDados());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nenhuma conta adicionada");
            }

            Console.ReadKey();
        }
    }
}

//Via console, abra 2 contas de cada tipo e execute todas as operações.
