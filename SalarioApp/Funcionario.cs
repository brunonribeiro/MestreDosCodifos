namespace SalarioApp
{
    public class Funcionario
    {
        public Funcionario(string nome, string salario)
        {
            Nome = nome;

            decimal.TryParse(salario, out var valorConvertido);
            Salario = valorConvertido;
        }

        public Funcionario()
        {
            Salario = 0;
        }

        public string Nome { get; private set; }
        public decimal? Salario { get; private set; }

    }
}
