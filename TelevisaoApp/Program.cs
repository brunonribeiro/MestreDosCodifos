using System;

namespace TelevisaoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var televisao = new Televisao();
            var controle = new ControleRemoto();

            int opcao = ExibirMenu();

            while (opcao >= (int)OpcaoEnum.AumentarVolume && opcao <= (int)OpcaoEnum.ExibirDadosTV)
            {
                Executar(televisao, controle, (OpcaoEnum)opcao);

                Console.Clear();
                opcao = ExibirMenu();
            }
        }

        private static int ExibirMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1 - Aumentar Volume");
            Console.WriteLine("2 - Diminuir Volume");
            Console.WriteLine("3 - Consultar Volume");
            Console.WriteLine("4 - Aumentar Canal");
            Console.WriteLine("5 - Diminuir Canal");
            Console.WriteLine("6 - Trocar para Canal");
            Console.WriteLine("7 - Consultar para Canal");
            Console.WriteLine("8 - Exibir dados da TV");
            Console.WriteLine();
            Console.WriteLine("Digite 0 para sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int.TryParse(Console.ReadLine(), out var opcao);
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            return opcao;
        }

        private static void Executar(Televisao televisao, ControleRemoto controle, OpcaoEnum opcao)
        {
            switch (opcao)
            {
                case OpcaoEnum.AumentarVolume:
                    controle.AumentarVolume(televisao);
                    ExibirVolume(televisao.Volume);
                    break;
                case OpcaoEnum.DiminuirVolume:
                    controle.DiminuirVolume(televisao);
                    ExibirVolume(televisao.Volume);
                    break;
                case OpcaoEnum.ConsultarVolume:
                    var volume = controle.ConsultarVolume(televisao);
                    ExibirVolume(volume);
                    break;
                case OpcaoEnum.AumentarCanal:
                    controle.AumentarCanal(televisao);
                    ExibirCanal(televisao.Canal);
                    break;
                case OpcaoEnum.DiminuirCanal:
                    controle.DiminuirCanal(televisao);
                    ExibirCanal(televisao.Canal);
                    break;
                case OpcaoEnum.TrocarCanal:
                    Console.Write("Digite o canal desejado: ");
                    int.TryParse(Console.ReadLine(), out var canalSelecionado);
                    controle.TrocarCanal(televisao, canalSelecionado);
                    break;
                case OpcaoEnum.ConsultarCanal:
                    var canal = controle.ConsultarCanal(televisao);
                    ExibirCanal(canal);
                    break;
                case OpcaoEnum.ExibirDadosTV:
                    ExibirTV(televisao);
                    break;
            }
        }

        
        private static void ExibirVolume(int volume)
        {
            Console.WriteLine($"Volume: {volume}");
            Console.ReadKey();
        }
        private static void ExibirCanal(int canal)
        {
            Console.WriteLine($"Canal: {canal}");
            Console.ReadKey();
        }

        private static void ExibirTV(Televisao televisao)
        {
            var copiaTelevisao = televisao.Clone();
            Console.WriteLine(copiaTelevisao.ToString());
            Console.ReadKey();
        }
    }
}
