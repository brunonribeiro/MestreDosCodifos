using TelevisaoApp;
using Xunit;

namespace XUnit.Tests
{
    public class ControleRemotoTests
    {
        private readonly ControleRemoto _controleRemoto;
        private readonly Televisao _televisao;

        private const int CanalInicial = 10;
        private const int VolumeInicial = 30;
        private const int ValorZero = 0;

        public ControleRemotoTests()
        {
            _controleRemoto = new ControleRemoto();
            _televisao = CriarTelevisao();
        }

        private Televisao CriarTelevisao()
        {
            return new Televisao
            {
                Canal = CanalInicial,
                Volume = VolumeInicial
            };
        }

        [Fact]
        public void DeveAumentarVolume()
        {
            _controleRemoto.AumentarVolume(_televisao);
            _controleRemoto.AumentarVolume(_televisao);

            Assert.Equal(_televisao.Volume, VolumeInicial + 2);
        }

        [Fact]
        public void DeveDiminuirVolume()
        {
            _controleRemoto.DiminuirVolume(_televisao);
            _controleRemoto.DiminuirVolume(_televisao);
            _controleRemoto.DiminuirVolume(_televisao);

            Assert.Equal(_televisao.Volume, VolumeInicial - 3);
        }

        [Fact]
        public void NaoDeveDiminuirVolume()
        {
            _televisao.Volume = ValorZero;
            _controleRemoto.DiminuirVolume(_televisao);
            _controleRemoto.DiminuirVolume(_televisao);
            _controleRemoto.DiminuirVolume(_televisao);

            Assert.Equal(_televisao.Volume, ValorZero);
        }

        [Fact]
        public void DeveConsultarVolume()
        {
            var volume = _controleRemoto.ConsultarVolume(_televisao);
            Assert.Equal(volume, VolumeInicial);
        }

        [Fact]
        public void DeveAumentarCanal()
        {
            _controleRemoto.AumentarCanal(_televisao);
            _controleRemoto.AumentarCanal(_televisao);

            Assert.Equal(_televisao.Canal, CanalInicial + 2);
        }

        [Fact]
        public void DeveDiminuirCanal()
        {
            _controleRemoto.DiminuirCanal(_televisao);
            _controleRemoto.DiminuirCanal(_televisao);
            _controleRemoto.DiminuirCanal(_televisao);

            Assert.Equal(_televisao.Canal, CanalInicial - 3);
        }

        [Fact]
        public void NaoDeveDiminuirCanal()
        {
            _televisao.Canal = ValorZero;
            _controleRemoto.DiminuirCanal(_televisao);
            _controleRemoto.DiminuirCanal(_televisao);
            _controleRemoto.DiminuirCanal(_televisao);

            Assert.Equal(_televisao.Canal, ValorZero);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(30)]
        public void DeveTrocarCanal(int canalSelecionado)
        {
            _controleRemoto.TrocarCanal(_televisao, canalSelecionado);
            Assert.Equal(_televisao.Canal, canalSelecionado);
        }

        [Fact]
        public void NaoDeveTrocarCanalQuandoZero()
        {
            _controleRemoto.TrocarCanal(_televisao, ValorZero);
            Assert.Equal(_televisao.Canal, CanalInicial);
        }

        [Fact]
        public void DeveConsultarCanal()
        {
            var canal = _controleRemoto.ConsultarCanal(_televisao);
            Assert.Equal(canal, CanalInicial);
        }
    }
}
