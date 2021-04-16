
namespace ContaBancariaApp.Models
{
    public class Retorno
    {
        public bool TransacaoEfetuada { get; set; }
        public string Erro { get; set; }

        public Retorno(bool transacaoEfetuada, string erro = null)
        {
            TransacaoEfetuada = transacaoEfetuada;
            Erro = erro;
        }

        public static Retorno Sucesso()
        {
            return new Retorno(true);
        }

        public static Retorno Falha(string mensagem)
        {
            return new Retorno(false, mensagem);
        }
    }
}
