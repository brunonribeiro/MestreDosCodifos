using ContaBancariaApp.Interfaces;
using ContaBancariaApp.Models;

namespace ContaBancariaApp.Base
{
    public abstract class ContaBancaria : IImprimivel
    {
        public long NumeroDaConta { get; set; }
        public double Saldo { get; protected set; }
        public string SaldoFormatado => $"{Saldo:c}";

        public ContaBancaria()
        {
            Saldo = 0;
        }

        public virtual Retorno Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;

                return Retorno.Sucesso();
            }

            return Retorno.Falha(string.Format(Mensagens.ValorDaOperacaoDeveSerMaiorQueZero, "Depósito"));
        }

        public virtual Retorno Sacar(double valor)
        {
            if (valor > 0)
            {
                Saldo -= valor;

                return Retorno.Sucesso();
            }

            return Retorno.Falha(string.Format(Mensagens.ValorDaOperacaoDeveSerMaiorQueZero, "Saque"));
        }



        public virtual string MostrarDados()
        {
            return $"Número da Conta: {NumeroDaConta}\nSaldo: {SaldoFormatado}";
        }

        protected virtual bool ValidarSePossuiSaldo(double valorARetirar)
        {
            return Saldo >= valorARetirar;
        }
    }
}

