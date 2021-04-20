using System;

namespace TelevisaoApp
{
    public class Televisao : ICloneable
    {
        public int Volume { get; set; }
        public int Canal { get; set; }
       
        public override string ToString()
        {
            return $"Canal: {Canal}\nVolume: {Volume}";
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
