using ContaBancariaApp.Base;

namespace ContaBancariaApp.Models
{
    public class ContaEspecial : ContaBancaria
    {
        private const double _limite = 100.00;

        public double Limite
        {
            get
            {
                return _limite;
            }
        }

        public override Retorno Depositar(double valor)
        {
            return base.Depositar(valor);
        }

        public override Retorno Sacar(double valor)
        {
            if (!ValidarSePossuiSaldo(valor))
                return Retorno.Falha(string.Format(Mensagens.ContaNaoPossuiSaldoSuficiente, "Saque"));

            return base.Sacar(valor);
        }

        protected override bool ValidarSePossuiSaldo(double valorARetirar)
        {
            return Saldo + Limite >= valorARetirar;
        }
    }
}
