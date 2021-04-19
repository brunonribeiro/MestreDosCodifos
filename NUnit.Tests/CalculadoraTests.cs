using CalculadoraApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnit.Tests
{
    [TestFixture]
    public class CalculadoraTests
    {
        [Test]
        public void TestSomar()
        {
            var result = Calculador.Somar(3, 3);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(6, result.Valor);

            result = Calculador.Somar(5, 5);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(10, result.Valor);

            result = Calculador.Somar(15, 30);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(45, result.Valor);
        }

        [Test]
        public void TestSubtrair()
        {
            var result = Calculador.Subtrair(3, 3);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(0, result.Valor);

            result = Calculador.Subtrair(15, 5);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(10, result.Valor);

            result = Calculador.Subtrair(30, 10);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(20, result.Valor);
        }

        [Test]
        public void TestMultiplicar()
        {
            var result = Calculador.Multiplicar(3, 3);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(9, result.Valor);

            result = Calculador.Multiplicar(10, 4);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(40, result.Valor);

            result = Calculador.Multiplicar(30, 15);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(450, result.Valor);
        }

        [Test]
        public void TestDividir()
        {
            var result = Calculador.Dividir(3, 3);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(1, result.Valor);

            result = Calculador.Dividir(12, 4);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(3, result.Valor);

            result = Calculador.Dividir(30, 15);
            Assert.IsTrue(result.CalculadoEfetuado);
            Assert.AreEqual(2, result.Valor);
        }

        [Test]
        public void TestDuividirComDivisorZero()
        {
            const string erroEsperado = "O Número deve ser maior que zero!";

            var result = Calculador.Dividir(3, 0);
            Assert.IsFalse(result.CalculadoEfetuado);
            Assert.AreEqual(erroEsperado, result.MensagemErro);

            result = Calculador.Dividir(12, 0);
            Assert.IsFalse(result.CalculadoEfetuado);
            Assert.AreEqual(erroEsperado, result.MensagemErro);

            result = Calculador.Dividir(30, 0);
            Assert.IsFalse(result.CalculadoEfetuado);
            Assert.AreEqual(erroEsperado, result.MensagemErro);
        }
    }
}
