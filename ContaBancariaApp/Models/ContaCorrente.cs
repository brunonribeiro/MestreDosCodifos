using ContaBancariaApp.Base;
using ContaBancariaApp.Interfaces;
using System;

namespace ContaBancariaApp.Models
{
    public class ContaCorrente : ContaBancaria
    {
        private const double _taxaDeOperacao = 2.5;

        public double TaxaDeOperacao
        {
            get
            {
                return _taxaDeOperacao;
            }
        }

        public override Retorno Depositar(double valor)
        {
            if (!ValidarSePossuiSaldo(TaxaDeOperacao - valor))
                return Retorno.Falha(string.Format(Mensagens.ContaNaoPossuiSaldoSuficiente, "Taxa de Operação"));

            DescontarTaxaDeOperacao();
            return base.Depositar(valor);
        }

        public override Retorno Sacar(double valor)
        {
            if (!ValidarSePossuiSaldo(TaxaDeOperacao + valor))
                return Retorno.Falha(string.Format(Mensagens.ContaNaoPossuiSaldoSuficiente, "Saque"));

            DescontarTaxaDeOperacao();
            return base.Sacar(valor);
        }      

        private void DescontarTaxaDeOperacao()
        {
            Saldo -= TaxaDeOperacao;
        }
    }
}
