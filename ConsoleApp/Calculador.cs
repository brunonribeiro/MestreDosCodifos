
namespace CalculadoraApp
{
    public static class Calculador
    {
        public static RetornoModel Somar(int numero1, int numero2)
        {
            return RetornoModel.Sucesso(numero1 + numero2);
        }

        public static RetornoModel Subtrair(int numero1, int numero2)
        {
            return RetornoModel.Sucesso(numero1 - numero2);
        }

        public static RetornoModel Dividir(int numero1, int numero2)
        {
            var erro = ValidarNumeroDeveSerMaiorQueZero(numero2);
            return erro ?? RetornoModel.Sucesso(numero1 / numero2);
        }

        public static RetornoModel Multiplicar(int numero1, int numero2)
        {
            return RetornoModel.Sucesso(numero1 * numero2);
        }

        private static RetornoModel ValidarNumeroDeveSerMaiorQueZero(int numero)
        {
            if (numero <= 0)
                return RetornoModel.Erro($"O Número deve ser maior que zero!");

            return null;
        }
    }
}
