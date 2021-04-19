using ContaBancariaApp.Models;
using Xunit;

namespace XUnit.Tests
{
    public class ContaCorrenteTests
    {
        private readonly ContaCorrente _contaCorrente;

        public ContaCorrenteTests()
        {
            _contaCorrente = new ContaCorrente();
        }

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        public void DeveTerSucessoAoDepositar(double valor)
        {
           var resultado = _contaCorrente.Depositar(valor);

            Assert.True(resultado.TransacaoEfetuada);
        }

        [Theory]
        [InlineData(0.5)]
        [InlineData(1)]
        [InlineData(2)]
        public void DeveTerFalhaAoDepositarSemSaldo(double valor)
        {
            var erroEsperado = string.Format(Mensagens.ContaNaoPossuiSaldoSuficiente, "Taxa de Operação");
            var resultado = _contaCorrente.Depositar(valor);

            Assert.False(resultado.TransacaoEfetuada);
            Assert.Contains(resultado.Erro, erroEsperado);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(50)]
        public void DeveValidarSaldoAoDepositar(double valor)
        {
            var saldoEsperado = valor - _contaCorrente.TaxaDeOperacao;

            _contaCorrente.Depositar(valor);

            Assert.Equal(_contaCorrente.Saldo, saldoEsperado);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        public void DeveTerSucessoAoSacar(double valor)
        {
            _contaCorrente.Depositar(100);

            var resultado = _contaCorrente.Sacar(valor);

            Assert.True(resultado.TransacaoEfetuada);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(50)]
        public void DeveTerFalhaAoSacarSemSaldo(double valor)
        {
            var saldoMinimo = _contaCorrente.TaxaDeOperacao + valor;
            var erroEsperado = string.Format(Mensagens.ContaNaoPossuiSaldoSuficiente, "Saque");

            _contaCorrente.Depositar(saldoMinimo - 1);
            var resultado = _contaCorrente.Sacar(valor);

            Assert.False(resultado.TransacaoEfetuada);
            Assert.Contains(resultado.Erro, erroEsperado);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        public void DeveValidarSaldoAoSacar(double valor)
        {
            var valorDeposito = 100;
            _contaCorrente.Depositar(valorDeposito);
            var saldoEsperado = valorDeposito - _contaCorrente.TaxaDeOperacao - valor - _contaCorrente.TaxaDeOperacao;

            _contaCorrente.Sacar(valor);

            Assert.Equal(_contaCorrente.Saldo, saldoEsperado);
        }

        [Fact]
        public void DeveMostarDados()
        {
            var resultado = "Número da Conta: 1321\nSaldo: R$ 100,00";
            _contaCorrente.NumeroDaConta = 1321;
            _contaCorrente.Depositar(100 + _contaCorrente.TaxaDeOperacao);

            Assert.Equal(_contaCorrente.MostrarDados(), resultado);
        }
    }
}
