using ContaBancariaApp.Models;
using Xunit;

namespace XUnit.Tests
{
    public class ContaEspecialTests
    {
        private readonly ContaEspecial _contaEspecial;

        public ContaEspecialTests()
        {
            _contaEspecial = new ContaEspecial();
        }

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        public void DeveTerSucessoAoDepositar(double valor)
        {
            var resultado = _contaEspecial.Depositar(valor);

            Assert.True(resultado.TransacaoEfetuada);
        }


        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(50)]
        public void DeveValidarSaldoAoDepositar(double valor)
        {
            var saldoEsperado = valor;

            _contaEspecial.Depositar(valor);

            Assert.Equal(_contaEspecial.Saldo, saldoEsperado);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        public void DeveTerSucessoAoSacar(double valor)
        {
            _contaEspecial.Depositar(valor);

            var resultado = _contaEspecial.Sacar(valor);

            Assert.True(resultado.TransacaoEfetuada);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(60)]
        [InlineData(90)]
        public void DeveTerSucessoAoSacarUsandoLimite(double valor)
        {
            var resultado = _contaEspecial.Sacar(valor);

            Assert.True(resultado.TransacaoEfetuada);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(50)]
        public void DeveTerFalhaAoSacarSemSaldo(double valor)
        {
            var sacar = valor + _contaEspecial.Limite;
            var erroEsperado = string.Format(Mensagens.ContaNaoPossuiSaldoSuficiente, "Saque");

            var resultado = _contaEspecial.Sacar(sacar);

            Assert.False(resultado.TransacaoEfetuada);
            Assert.Contains(resultado.Erro, erroEsperado);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(120)]
        [InlineData(200)]
        public void DeveValidarSaldoAoSacar(double valor)
        {
            var valorDeposito = 100;
            _contaEspecial.Depositar(valorDeposito);
            var saldoEsperado = valorDeposito -  valor;

            _contaEspecial.Sacar(valor);

            Assert.Equal(_contaEspecial.Saldo, saldoEsperado);
        }

        [Fact]
        public void DeveMostarDados()
        {
            var resultado = "Número da Conta: 1321\nSaldo: R$ 100,00";
            _contaEspecial.NumeroDaConta = 1321;
            _contaEspecial.Depositar(100);

            Assert.Equal(_contaEspecial.MostrarDados(), resultado);
        }
    }
}
