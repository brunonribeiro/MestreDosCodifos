namespace AlunosApp
{
    public class Aluno
    {
        public Aluno(string nome, string nota)
        {
            Nome = nome;

            decimal.TryParse(nota, out var valorConvertido);
            Nota = valorConvertido;
        }

        public string Nome { get; set; }
        public decimal Nota { get; set; }
    }
}
