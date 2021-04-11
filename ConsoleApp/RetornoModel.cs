
namespace CalculadoraApp
{
    public class RetornoModel
    {
        public bool CalculadoEfetuado { get; set; }
        public decimal Valor { get; set; }
        public string MensagemErro { get; set; }

        public RetornoModel(decimal valor)
        {
            CalculadoEfetuado = true;
            Valor = valor;
        }

        public RetornoModel(string mensagemErro)
        {
            CalculadoEfetuado = false;
            MensagemErro = mensagemErro;
        }

        public static RetornoModel Sucesso(decimal valor)
        {
            return new RetornoModel(valor);
        }

        public static RetornoModel Erro(string mensagemErro)
        {
            return new RetornoModel(mensagemErro);
        }
    }
}
