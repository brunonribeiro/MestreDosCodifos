namespace TelevisaoApp
{
    public class ControleRemoto
    {
        public void AumentarVolume(Televisao televisao)
        {
            televisao.Volume++;
        }

        public void DiminuirVolume(Televisao televisao)
        {
            if (ValidarSePodeTroca(televisao.Volume))
            {
                televisao.Volume--;
            }
        }

        public void AumentarCanal(Televisao televisao)
        {
            televisao.Canal++;
        }

        public void DiminuirCanal(Televisao televisao)
        {
            if (ValidarSePodeTroca(televisao.Canal))
            {
                televisao.Canal--;
            }
        }

        public void TrocarCanal(Televisao televisao, int canal)
        {
            if (ValidarSePodeTroca(canal))
            {
                televisao.Canal = canal;
            }
        }

        public int ConsultarVolume(Televisao televisao)
        {
            return televisao.Volume;
        }

        public int ConsultarCanal(Televisao televisao)
        {
            return televisao.Canal;
        }

        private bool ValidarSePodeTroca(int valor)
        {
            return valor > 0;
        }
    }
}
