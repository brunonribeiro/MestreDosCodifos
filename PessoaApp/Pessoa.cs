using System;

namespace PessoaApp
{
    public class Pessoa
    {
        private string _nome;
        private DateTime _dataNascimento;
        private decimal _altura;

        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim();
        }

        public string DataNascimento
        {
            get => _dataNascimento.ToShortDateString();
            set
            {
                DateTime.TryParse(value, out _dataNascimento);
            }
        }

        public decimal Altura
        {
            get => _altura;
            set => _altura = value;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} - Idade: {ObterIdade()} - Altura: {Altura}";
        }

        public int ObterIdade()
        {
            var idade = DateTime.Now.Year - _dataNascimento.Year;

            if (DateTime.Now.DayOfYear < _dataNascimento.DayOfYear)
            {
                idade--;
            }
            return idade;
        }
    }
}
