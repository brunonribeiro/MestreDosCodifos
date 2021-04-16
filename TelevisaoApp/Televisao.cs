namespace TelevisaoApp
{
    public class Televisao
    {
        public int Volume { get; set; }
        public int Canal { get; set; }

        public override string ToString()
        {
            return $"Canal: {Canal}\nVolume: {Volume}";
        }
    }
}
