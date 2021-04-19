using NUnit.Framework;
using PessoaApp;
using System;

namespace NUnit.Tests
{
    [TestFixture]
    public class PessoaTests
    {
        [Test]
        public void TestPreencherNome()
        {
            var nome = " Nome Teste ";
            var pessoa = new Pessoa();
            pessoa.Nome = nome;

            Assert.AreEqual(pessoa.Nome, nome.Trim());
        }

        [Test]
        public void TestPreencherDataNascimento()
        {
            var data = "10/10/1990";
            var pessoa = new Pessoa();
            pessoa.DataNascimento = data;

            Assert.AreEqual(pessoa.DataNascimento, data);
        }

        [Test]
        public void TestPreencherAltura()
        {
            var altura = 1.90m;
            var pessoa = new Pessoa();
            pessoa.Altura = altura;

            Assert.AreEqual(pessoa.Altura, altura);
        }

        [Test]
        public void TestObterIdade()
        {
            var data = "10/12/1990";
            var pessoa = new Pessoa();
            pessoa.DataNascimento = data;

            Assert.AreEqual(pessoa.ObterIdade(), 30);
        }

        [Test]
        public void TestToString()
        {
            var resultadoEsperado = "Nome: Nome Teste - Idade: 30 - Altura: 1,90";

            var pessoa = new Pessoa
            {
                Nome = "Nome Teste",
                DataNascimento = "10/12/1990",
                Altura = 1.90m
            };

            Assert.AreEqual(pessoa.ToString(), resultadoEsperado);
        }

    }
}
